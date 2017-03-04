using IssueTakerApp.Security;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace IssueTakerApp.Controllers
{
    public class HomeController :Controller
    {
        private LogInManager manager;

        public HomeController()
        {
            this.manager = new LogInManager();
        }

        [HttpGet]
        public IActionResult Index(HttpSession session,HttpResponse response)
        {
            if (manager.IsAuthenticated(session))
            {
                Redirect(response,"/home/indexlogged");
                return null;
            }
            return View();
        }
        [HttpGet]
        public IActionResult Indexlogged(HttpSession session, HttpResponse response)
        {
            
            return View();
        }
    }
}
