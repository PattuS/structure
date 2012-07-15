namespace Structure.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

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
        public Structure.Services.ILog Logger { get; set; }

        /// <summary>
        /// Gets or sets the ModelService for business operations
        /// </summary>
        [Microsoft.Practices.Unity.Dependency]
        public Structure.Services.ModelService ModelService { get; set; }

        /// <summary>
        /// Redirect the user to an error page
        /// </summary>
        /// <param name="message">The user friendly message to display to the user</param>
        /// <param name="exception">The exception, only shown while in debug mode</param>
        /// <returns><see cref="ActionResult"/></returns>
        public ActionResult RedirectToError(string message, Exception exception)
        {
            TempData["Error"] = message;
#if DEBUG
            TempData["Exception"] = exception.ToString();
#endif
            return this.Redirect("/public/error");
        }


    }
}
