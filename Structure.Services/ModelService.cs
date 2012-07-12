using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Structure.Models;

namespace Structure.Services
{
    public class ModelService : BaseService
    {
        private IModelContext context;

        /// <summary>
        /// Constructs a new instance of <see cref="ModelService"/>
        /// </summary>
        /// <param name="context">An instance of an <see cref="IModelContext"/></param>
        /// <param name="log">An instance of an <see cref="ILog"/></param>
        public ModelService(IModelContext context, ILog log) : base(log)
        {
            this.context = context;
        }

        /// <summary>
        /// Authenticate a user against the data store
        /// </summary>
        /// <param name="email">The email address of the user</param>
        /// <param name="password">The password of the user</param>
        /// <returns><see cref="ServiceResponse<LoginResult>"/></returns>
        public ServiceResponse<LoginResult> Authenticate(string email, string password)
        {
            Func<LoginResult> func = delegate
            {
                // lookup user
                var user = context.AsQueryable<User>().SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
                if (user == null)
                    throw new Exception("No user found at " + email);
                
                // check password
                if (DevOne.Security.Cryptography.BCrypt.BCryptHelper.CheckPassword(password, user.PasswordHash))
                    return LoginResult.Success;
                else
                    return LoginResult.Failed;
                
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Returns a list of all users in the data store
        /// </summary>
        /// <returns></returns>
        public ServiceResponse<List<User>> GetAllUsers()
        {
            Func<List<User>> func = delegate
            {
                return this.context.AsQueryable<User>().ToList();
            };
            return this.Execute(func);
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
        /// Returns a user for the given id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns><see cref="User"/></returns>
        public ServiceResponse<User> GetUser(int id)
        {
            Func<User> func = delegate
            {
                return this.context.Get<User>(id);
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
    }
}
