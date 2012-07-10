using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Structure.Controllers
{
    public class PublicController : BaseController
    {
        //
        // GET: /Public/
        public ActionResult Index()
        {
            return View();
        }

    }
}
