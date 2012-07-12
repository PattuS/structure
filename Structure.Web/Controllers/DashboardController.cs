using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Structure.Web.Models.Dashboard;

namespace Structure.Web.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
    {
        
        // GET: /Dashboard/
        [HttpGet]
        public ActionResult Index()
        {
            var userResponse = this.ModelService.GetAllUsers();
            var users = userResponse.Result;

            var clientResponse = this.ModelService.GetAllClients();
            var clients = clientResponse.Result;

            var model = new DashboardViewModel()
            {
                Users = users,
                Clients = clients
            };
            return View(model);
        }

    }
}
