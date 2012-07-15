using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Structure.Web.Models.Public;

namespace Structure.Web.Controllers
{
    public class PublicController : BaseController
    {
        
        [HttpGet] // GET: /
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet] // GET: /public/login
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return this.RedirectToAction("Index", "Dashboard");

            ViewBag.Users = this.ModelService.GetAllUsers().Result;
            return View(new LoginViewModel());
        }

        [HttpPost] // POST: /public/login
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

        [HttpGet] // GET/POST: /public/logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction("Index");
        }

        [HttpGet] // GET: /public/resetpassword
        public ActionResult ResetPassword()
        {
            return PartialView();
        }

        [HttpPost] // POST: /public/resetpassword
        public ActionResult ResetPassword(string email)
        {
            var response = this.Service.ResetPassword(email);
            if (response.HasError)
            {
                TempData["LoginError"] = response.Exception.Message;
            }
            else
            {
                TempData["LoginMessage"] = "An email containing a new password has been sent to " + email;
            }


            return this.RedirectToAction("Login");
        }

        [HttpGet, HttpPost] // GET/POST: /public/error
        public ActionResult Error()
        {
            return View();
        }

    }
}
