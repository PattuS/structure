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
            return View(new LoginViewModel());
        }

        // POST: /public/login
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        // GET: /public/logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction("Index");
        }

    }
}
