using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using static StorageSystem.Common.GlobalConstants;

namespace StorageSystem.Data.Seeding
{
    public class RoleSeeder : ISeeder
    {
        public async Task SeedAsync(StorageSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await SeedRoleAsync(roleManager, Roles.Admninistrator);
            await SeedRoleAsync(roleManager, Roles.Manager);
            await SeedRoleAsync(roleManager, Roles.Worker);
        }

        private static async Task SeedRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            bool roleExists = await roleManager.RoleExistsAsync(roleName);
            if(!roleExists)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if(!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
