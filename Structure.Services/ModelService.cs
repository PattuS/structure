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

    }
}
