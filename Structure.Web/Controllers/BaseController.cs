using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Structure.Controllers
{
    /// <summary>
    /// Common controller methods and properties for all controllers
    /// </summary>
    public class BaseController : Controller
    {
        public BaseController() { }

        /// <summary>
        /// Gets or sets the Logger for application logging
        /// </summary>
        [Microsoft.Practices.Unity.Dependency]
        public Structure.Services.ILogger Logger { get; set; }

        /// <summary>
        /// Gets or sets the ModelService for business operations
        /// </summary>
        [Microsoft.Practices.Unity.Dependency]
        public Structure.Services.ModelService ModelService { get; set; }

    }
}
