namespace Structure.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Client : Entity
    {
        /// <summary>
        /// Constructs a new instance of a <see cref="Client"/>
        /// </summary>
        public Client() { }

        /// <summary>
        /// Gets or sets the name of this <see cref="Client"/>
        /// </summary>
        public string Name { get; set; }
    }
}
