

using IssueTakerApp.BindingModels;
using IssueTakerApp.Security;
using IssueTakerApp.Service;
using IssueTakerApp.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace IssueTakerApp.Controllers
{
    public class UserController :Controller
    {
        private LogInManager manager;
        private UserService service;

        public UserController()
        {
            this.manager = new LogInManager();
            this.service =new UserService();
        }
        [HttpGet]
        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (manager.IsAuthenticated(session))
            {
                Redirect(response, "/home/indexlogged");
                return null;
            }

            return View();
        }
        [HttpPost]
        public IActionResult<ErrorVM> Register(RegisterUserBM model,HttpSession session, HttpResponse response)
        {
            var errorMessage = this.service.ValidateUser(model);
            if (errorMessage == "OK")
            {
                this.service.AddUser(model);
                Redirect(response,"/home/index");
                return null;
            }
            var viewModel = new ErrorVM();
            viewModel.ErrorMessage = errorMessage;
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginBM model, HttpResponse response, HttpSession session)
        {
            
            if (service.LoginUser(model, session))
            {
                Redirect(response, "/home/indexlogged");
                return null;
            }
            return this.View();
        }
        [HttpGet]
        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            manager.Logout(response, session.Id);
            Redirect(response, "/home/index");
            return null;
        }
    }
}
