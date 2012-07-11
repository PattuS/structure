using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Structure.Web.Models.Public
{
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets the email address of the user to log in
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user to log in
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}