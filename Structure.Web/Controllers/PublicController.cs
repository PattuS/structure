using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Structure.Web.Models.Public;

namespace Structure.Controllers
{
    public class PublicController : BaseController
    {
        // GET: /
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: /public/login
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Users = this.ModelService.GetAllUsers().Result;
            return View(new LoginViewModel());
        }

        // POST: /public/login
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var response = this.ModelService.Authenticate(model.Email, model.Password);
            if (response.HasError || response.Result == Services.LoginResult.Failed)
            {
                // we show the same error no matter what, so attackers do not know what to change
                ViewBag.LoginError = "Email address or password incorrect.";
                return View(new LoginViewModel() { Email = model.Email });
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.Email, true);
                return this.RedirectToAction("Index", "Dashboard");
            }
        }

        // GET: /public/logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction("Index");
        }

    }
}
