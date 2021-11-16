using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using StorageSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StorageSystem.Common.GlobalConstants;

namespace StorageSystem.Data.Seeding
{
    public class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(StorageSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            User userFromDb = await userManager.FindByNameAsync(Admin.Username);

            if(userFromDb!=null)
            {
                return;
            }

            var user = new User
            {
                UserName = Admin.Username,
                Email = Admin.Email,
                Name = Admin.Name,
                Surname = Admin.Surname,
                PhoneNumber = Admin.PhoneNumber
            };

            await userManager.CreateAsync(user, Admin.Password);
            IdentityResult result = await userManager.AddToRoleAsync(user, Roles.Admninistrator);
        }
    }
}
