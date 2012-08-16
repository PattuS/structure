using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Structure.Web.Models.Users;

namespace Structure.Web.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {

        [HttpGet] // GET: /Users/
        public ActionResult Index()
        {
            var userResponse = this.UserService.GetAllUsers();
            var users = userResponse.Result;
            
            var model = new ListViewModel()
            {
                Users = users
            };
            return View(model);
        }

        [HttpGet] // GET: /users/new
        public ActionResult New()
        {
            var model = new EditViewModel()
            {
                User = new Structure.Models.User()
            };
            return View("Edit", model);
        }

        [HttpGet] // GET: /users/{id}/edit
        public ActionResult Edit(int id)
        {
            var response = this.UserService.GetUser(id);
            var user = response.Result;

            var model = new EditViewModel()
            {
                User = user
            };
            return View(model);
        }

        [HttpPost] // POST: /users/edit
        public ActionResult Edit(EditViewModel model)
        {
            var response = this.UserService.SaveUser(model.User);
            if (response.HasError)
            {
                TempData["Error"] = "Could not save user.";
                return View(model);
            }

            TempData["Success"] = model.User.Name + " was successfully saved.";
            return this.RedirectToAction("Index");
        }

        [HttpPost] // POST: /users/{id}/delete
        public ActionResult Delete(int id)
        {
            var response = this.UserService.DeleteUser(id);
            if (response.HasError)
            {
                TempData["Error"] = "Could not delete user.";
            }

            TempData["Success"] = "User was successfully deleted.";
            return this.RedirectToAction("Index");
        }

        [HttpGet] // GET: /users/changepassword
        public ActionResult ChangePassword()
        {
            return PartialView("_ChangePassword", new ChangePasswordViewModel());
        }

        [HttpPost] // POST: /users/changepassword
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            var response = this.UserService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
            if (response.HasError)
                return this.JsonResult(false, response.Exception.ToString());

            return this.JsonResult(true);
        }

    }
}
