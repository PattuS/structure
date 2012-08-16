namespace Structure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Structure.Models;

    public class UserService : BaseService
    {
        /// <summary>
        /// Constructs a new instance of <see cref="UserService"/>
        /// </summary>
        /// <param name="context">An instance of an <see cref="IModelContext"/></param>
        /// <param name="log">An instance of an <see cref="ILog"/></param>
        public UserService(IModelContext context, ILog log)
            : base(context, log)
        {
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
        /// Returns a user for the given id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns><see cref="User"/></returns>
        public ServiceResponse<User> GetUser(string email)
        {
            Func<User> func = delegate
            {
                var user = this.context.AsQueryable<User>().FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
                if (user == null)
                    throw new ArgumentOutOfRangeException("Email address not found");

                return user;
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Persists changes to the data store
        /// </summary>
        /// <param name="entity">User</param>
        /// <returns><see cref="User"/></returns>
        public ServiceResponse<User> SaveUser(User entity)
        {
            Func<User> func = delegate
            {
                return this.context.Save(entity);
            };
            return this.Execute(func);
        }
        
        /// <summary>
        /// Deletes a user from the data store
        /// </summary>
        /// <param name="entity">User</param>
        /// <returns><see cref="bool"/></returns>
        public ServiceResponse<bool> DeleteUser(int id)
        {
            Func<bool> func = delegate
            {
                return this.context.Delete<User>(id);
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Generate a new password for a user
        /// </summary>
        /// <param name="email">The users email</param>
        /// <returns>A new strong password</returns>
        public ServiceResponse<string> ResetPassword(string email)
        {
            Func<string> func = delegate
            {
                // lookup password
                var user = this.context.AsQueryable<User>().FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
                if (user == null)
                    throw new ArgumentOutOfRangeException("Email address not found");

                // create a new password
                var password = generatePassword(12);
                user.PasswordHash = hashPassword(password);
                context.Save(user);

                return password;
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Change the users password in the data store
        /// </summary>
        /// <param name="email">The users email address</param>
        /// <param name="password">The new password</param>
        public ServiceResponse<User> ChangePassword(string email, string oldPassword, string newPassword)
        {
            Func<User> func = delegate
            {
                // lookup user
                var user = this.context.AsQueryable<User>().FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
                if (user == null)
                    throw new ArgumentOutOfRangeException("Email address not found");

                // check old password
                if (checkPassword(oldPassword, user.PasswordHash))
                    throw new ArgumentOutOfRangeException("Incorrect password");

                user.PasswordHash = hashPassword(newPassword);
                return context.Save(user);
            };
            return this.Execute(func);
        }

        /// <summary>
        /// Randomly generate 8 characters password
        /// </summary>
        /// <returns></returns>
        private string generatePassword(int length)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            string rawChars = "0123456789abcdefghijklmnopqrstuwvxyz*$-+?_&=!%{}/ABCDEFGHJKLMNPQRSTWXYZ";
            char[] newChars = rawChars.ToCharArray();
            for (int i = 0; i < length; i++)
            {
                int iPosition = random.Next(0, rawChars.Length - 1);
                sb.Append(newChars[iPosition]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Check a password against its hash
        /// </summary>
        /// <param name="password">The password to confirm</param>
        /// <param name="hash">The hash to check against</param>
        /// <returns>True if the hash is correct for this password</returns>
        private bool checkPassword(string password, string hash)
        {
            return DevOne.Security.Cryptography.BCrypt.BCryptHelper.CheckPassword(password, hash);
        }

        /// <summary>
        /// Hash a given password
        /// </summary>
        /// <param name="password">The password to hash</param>
        /// <returns>The cryptographic hash of a password</returns>
        private string hashPassword(string password)
        {
            var salt = DevOne.Security.Cryptography.BCrypt.BCryptHelper.GenerateSalt();
            return DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword(password, salt);
        }


    }
}
