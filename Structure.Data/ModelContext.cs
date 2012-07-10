namespace Structure.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Entity;
    using Structure.Models;

    public class ModelContext : DbContext, Structure.Services.IModelContext
    {
        /// <summary>
        /// Constructs a new instance of a <see cref="ModelContext"/>
        /// </summary>
        public ModelContext() { }

        /// <summary>
        /// Gets a collection of clients from the data store
        /// </summary>
        public DbSet<Client> Clients { get; protected set; }

        /// <summary>
        /// Gets a collection of users from the data store
        /// </summary>
        public DbSet<User> User { get; protected set; }

        /// <summary>
        /// Returns a queryable interface for an entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns><see cref="IQueryable"/></returns>
        public IQueryable<T> AsQueryable<T>() where T : Entity
        {
            return this.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Returns a single entity. Throws an exception if none or more than one found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <returns><see cref="Entity"/></returns>
        public T Get<T>(int id) where T : Entity
        {
            return this.Set<T>().Single(x => x.Id == id);
        }

        /// <summary>
        /// Returns a single entity or null if not found.
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <returns><see cref="Entity"/></returns>
        public T Find<T>(int id) where T : Entity
        {
            return this.Set<T>().Find(id);
        }

        /// <summary>
        /// Deletes a single entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="id">The entity key</param>
        /// <returns>True if successful</returns>
        public bool Delete<T>(int id) where T : Entity
        {
            var entity = this.Find<T>(id);
            return this.Delete(entity);
        }

        /// <summary>
        /// Deletes a single entity
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <returns>True if successful</returns>
        /// <exception cref="ArgumentNullException" />
        public bool Delete<T>(T entity) where T : Entity
        {
            if (entity == null)
                throw new ArgumentNullException("entity", "Entity can not be null when calling delete(entity)");

            this.Set<T>().Remove(entity);
            return this.SaveChanges() > 0;
        }

    }
}
