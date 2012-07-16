using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Structure.Web.Models.Users
{
    public class ChangePasswordViewModel
    {
        
        /// <summary>
        /// Gets or sets the previous user password
        /// </summary>
        [Required]
        public string OldPassword { get; set; }

        /// <summary>
        /// Gets or sets the new user password
        /// </summary>
        [Required]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets the new user password check
        /// </summary>
        [Required, Compare("NewPassword")]
        public string NewPasswordCheck { get; set; }
    }
}