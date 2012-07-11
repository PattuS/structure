namespace Structure.Models
{
    using System;

    public class Entity
    {
        public Entity()
        {
            this.Id = -1;
            this.CreatedDate = DateTime.Now;
            this.ChangedDate = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the Id of this <see cref="Entity"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the last Changed Date of this <see cref="Entity"/>
        /// </summary>
        public DateTime ChangedDate { get; set; }

        /// <summary>
        /// Gets or sets the Created Date of this <see cref="Entity"/>
        /// </summary>
        public DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// Returns true if the primary key and createddate match
        /// </summary>
        /// <param name="other">The entity to compare</param>
        /// <returns><see cref="bool"/></returns>
        public bool Equals(Entity other)
        {
            return (this.Id == other.Id
                && this.CreatedDate == other.CreatedDate);
        }

    }
}
