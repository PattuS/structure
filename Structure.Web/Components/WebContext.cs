using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Structure.Models;
using Structure.Services;
using System.Web.Security;

namespace Structure.Web.Components
{
    public class UserContext
    {

        private User _currentUser = null;

        /// <summary>
        /// Gets the current web context for this request
        /// </summary>
        public static UserContext Current
        {
            get
            {
                return DependencyResolver.Current.GetService<UserContext>();
            }
        }

        /// <summary>
        /// Gets the currently logged in user
        /// </summary>
        public Structure.Models.User User
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (_currentUser == null)
                    {
                        var userService = DependencyResolver.Current.GetService<UserService>();
                        _currentUser = userService.GetUser(HttpContext.Current.User.Identity.Name).Result;
                    }
                    return _currentUser;
                }
                return null;
            }
        }

        /// <summary>
        /// Returns true if authenticated
        /// </summary>
        public bool IsAuthenticated
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
        }

        /// <summary>
        /// Login an authenticated user
        /// </summary>
        /// <param name="user"></param>
        public void BeginSession(Structure.Models.User user, bool persistLogin = true)
        {
            FormsAuthentication.SetAuthCookie(user.Email, persistLogin);
            _currentUser = user;
        }

        /// <summary>
        /// Logout the current user and clear the session
        /// </summary>
        public void EndSession()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Clear();
        }

    }
}