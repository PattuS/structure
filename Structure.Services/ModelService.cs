namespace Structure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Structure.Models;

    public class ModelService : BaseService
    {
        /// <summary>
        /// Constructs a new instance of <see cref="ModelService"/>
        /// </summary>
        /// <param name="context">An instance of an <see cref="IModelContext"/></param>
        /// <param name="log">An instance of an <see cref="ILog"/></param>
        public ModelService(IModelContext context, ILog log) : base(context, log)
        {
        }

     
        /// <summary>
        /// Returns a list of all clients in the data store
        /// </summary>
        /// <returns></returns>
        public ServiceResponse<List<Client>> GetAllClients()
        {
            Func<List<Client>> func = delegate
            {
                return this.context.AsQueryable<Client>().ToList();
            };
            return this.Execute(func);
        }
               
        /// <summary>
        /// Returns a client for the given id
        /// </summary>
        /// <param name="id">Client id</param>
        /// <returns><see cref="Client"/></returns>
        public ServiceResponse<Client> GetClient(int id)
        {
            Func<Client> func = delegate
            {
                return this.context.Get<Client>(id);
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Persists changes to the data store
        /// </summary>
        /// <param name="entity">Client</param>
        /// <returns><see cref="Client"/></returns>
        public ServiceResponse<Client> SaveClient(Client entity)
        {
            Func<Client> func = delegate
            {
                return this.context.Save(entity);
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Deletes a client from the data store
        /// </summary>
        /// <param name="entity">Client</param>
        /// <returns><see cref="bool"/></returns>
        public ServiceResponse<bool> DeleteClient(int id)
        {
            Func<bool> func = delegate
            {
                return this.context.Delete<Client>(id);
            };
            return this.Execute(func);
        }

    }
}
