using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Structure.Data;

namespace Structure.DataFixtures
{
    public class ModelDataInitializer : System.Data.Entity.DropCreateDatabaseAlways<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {
            // add a test user
            context.Users.Add(new Models.User()
            {
                Name = "Administrator",
                Email = "admin@structure.org",
                PasswordHash = DevOne.Security.Cryptography.BCrypt.BCryptHelper.HashPassword("password", DevOne.Security.Cryptography.BCrypt.BCryptHelper.GenerateSalt())
            });

        }
    }
}