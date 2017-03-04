

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
    public class IssueController :Controller
    {
        private LogInManager manager;
        private IssueService service;

        public IssueController()
        {
            this.manager = new LogInManager();
            this.service = new IssueService();
        }

        [HttpGet]
        public IActionResult All ()
        {
           return View();
        }
        [HttpGet]
        public IActionResult New (HttpSession session, HttpResponse response)
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(NewIssueBM model,HttpSession session, HttpResponse response)
        {
            this.service.AddNewIssue(model,session);
            Redirect(response,"issue/all");
            return null;
        }
        [HttpGet]
        public IActionResult<EditIssueVM> Edit(int id,HttpSession session,HttpResponse response)
        {
            var viewModel = new EditIssueVM();
            viewModel.Id = id;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(EditIssueBM model, HttpSession session, HttpResponse response)
        {
           this.service.EditIssue(model);
           Redirect(response,"/issue/all");
            return null;
        }
        [HttpGet]
        public IActionResult Delete(int id, HttpSession session, HttpResponse response)
        {
            this.service.DeleteIssue(id);
            Redirect(response,"/issue/all");
            return null;
        }
    }
}
