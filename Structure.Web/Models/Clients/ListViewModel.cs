using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Structure.Models;

namespace Structure.Web.Models.Clients
{
    public class ListViewModel
    {
        /// <summary>
        /// Gets or sets the list of clients
        /// </summary>
        public List<Client> Clients { get; set; }

    }
}