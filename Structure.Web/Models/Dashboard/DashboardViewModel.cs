using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Structure.Models;

namespace Structure.Web.Models.Dashboard
{
    public class DashboardViewModel
    {
        /// <summary>
        /// Gets or sets the list of clients
        /// </summary>
        public List<Client> Clients { get; set; }
        
        /// <summary>
        /// Gets or sets the list of users
        /// </summary>
        public List<User> Users { get; set; }
        
    }
}