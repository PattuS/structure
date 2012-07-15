using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Structure.Web.Models.Users;

namespace Structure.Web.Controllers
{
    public class UsersController : BaseController
    {

        [HttpGet] // GET: /Users/
        public ActionResult Index()
        {
            var userResponse = this.ModelService.GetAllUsers();
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
            var response = this.ModelService.GetUser(id);
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
            var response = this.ModelService.SaveUser(model.User);
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
            var response = this.ModelService.DeleteUser(id);
            if (response.HasError)
            {
                TempData["Error"] = "Could not delete user.";
            }

            TempData["Success"] = "User was successfully deleted.";
            return this.RedirectToAction("Index");
        }
    }
}
