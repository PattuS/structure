namespace Structure.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using Newtonsoft.Json;

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

        /// <summary>
        /// Gets the currently logged in user
        /// </summary>
        protected Structure.Models.User ActiveUser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    var user = (Structure.Models.User)Session["ActiveUser"];
                    if (user == null)
                    {
                        user = this.ModelService.GetUser(User.Identity.Name).Result;
                        Session["ActiveUser"] = user;
                    }
                    return user;
                }
                return null;
            }
            private set
            {
                Session["ActiveUser"] = value;
            }
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="message"></param>
        protected void Info(string message)
        {
            this.Logger.Info(message);
        }

        /// <summary>
        /// Returns a standard format json result
        /// </summary>
        /// <param name="result">The result to pass to the user</param>
        /// <param name="error">Any error message to pass to the user</param>
        /// <returns></returns>
        protected ActionResult JsonResult(dynamic result, string error = null)
        {
            var response = new
            {
                Result = result,
                HasError = !string.IsNullOrEmpty(error),
                Error = error
            };

            var settings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var json = JsonConvert.SerializeObject(response, settings);
            return this.Content(json, "application/json");
        }

        /// <summary>
        /// Redirects the user to a custom error page
        /// </summary>
        /// <param name="exception">The exception thrown by the calling code</param>
        /// <returns></returns>
        protected ActionResult RedirectToError(Exception exception)
        {
            // redirect
            TempData["Error"] = exception.Message;
            return this.RedirectToAction("Error", "Public");
        }

        /// <summary>
        /// Login an authenticated user
        /// </summary>
        /// <param name="user"></param>
        protected void BeginSession(Structure.Models.User user, bool persistLogin = true)
        {
            FormsAuthentication.SetAuthCookie(user.Email, persistLogin);
            this.ActiveUser = user;
        }

        /// <summary>
        /// Logout the current user and clear the session
        /// </summary>
        protected void EndSession()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
        }

    }
}
