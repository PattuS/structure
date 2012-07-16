namespace Structure.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;

    public class User : Entity
    {

        /// <summary>
        /// Constructs a new instance of a <see cref="User"/>
        /// </summary>
        public User() { }

        /// <summary>
        /// Gets or sets the email address of this <see cref="User"/>
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name of this <see cref="User"/>
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the hashed password of this <see cref="User"/>
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }
    }
}
