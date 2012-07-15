using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Structure.Web.Models.Users
{
    public class ChangePasswordViewModel
    {
        
        /// <summary>
        /// Gets or sets the previous user password
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// Gets or sets the new user password
        /// </summary>
        public string NewPassword { get; set; }

    }
}