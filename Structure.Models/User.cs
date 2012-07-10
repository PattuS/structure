namespace Structure.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class User : Entity
    {

        /// <summary>
        /// Constructs a new instance of a <see cref="User"/>
        /// </summary>
        public User() { }

        /// <summary>
        /// Gets or sets the email address of this <see cref="User"/>
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name of this <see cref="User"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the hashed password of this <see cref="User"/>
        /// </summary>
        public string PasswordHash { get; set; }
    }
}
