using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Structure.Web.Models.Clients;

namespace Structure.Web.Controllers
{
    [Authorize]
    public class ClientsController : BaseController
    {

        [HttpGet] // GET: /Clients/
        public ActionResult Index()
        {
            var clientResponse = this.ModelService.GetAllClients();
            var clients = clientResponse.Result;

            var model = new ListViewModel()
            {
                Clients = clients
            };
            return View(model);
        }

        [HttpGet] // GET: /clients/new
        public ActionResult New()
        {
            var model = new EditViewModel()
            {
                Client = new Structure.Models.Client()
            };
            return View("Edit", model);
        }

        [HttpGet] // GET: /clients/{id}/edit
        public ActionResult Edit(int id)
        {
            var response = this.ModelService.GetClient(id);
            var client = response.Result;

            var model = new EditViewModel()
            {
                Client = client
            };
            return View(model);
        }

        [HttpPost] // POST: /clients/edit
        public ActionResult Edit(EditViewModel model)
        {
            var response = this.ModelService.SaveClient(model.Client);
            if (response.HasError){
                TempData["Error"] = "Could not save client.";
                return View(model);
            }

            TempData["Success"] = model.Client.Name + " was successfully saved.";
            return this.RedirectToAction("Index");
        }

        [HttpPost] // POST: /clients/{id}/delete
        public ActionResult Delete(int id)
        {
            var response = this.ModelService.DeleteClient(id);
            if (response.HasError)
            {
                TempData["Error"] = "Could not delete client.";
            }

            TempData["Success"] = "Client was successfully deleted.";
            return this.RedirectToAction("Index");
        }

    }
}
