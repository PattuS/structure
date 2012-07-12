using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Structure.Models;

namespace Structure.Web.Models.Users
{
    public class ListViewModel
    {
   
        /// <summary>
        /// Gets or sets the list of users
        /// </summary>
        public List<User> Users { get; set; }
    }
}