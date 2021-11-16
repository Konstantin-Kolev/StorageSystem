using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageSystem.Data.Seeding
{
    public class StorageSystemDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(StorageSystemDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            ILogger logger = serviceProvider.GetService<ILoggerFactory>()
                                            .CreateLogger(typeof(StorageSystemDbContextSeeder));
               
            var seeders = new List<ISeeder>
                          {
                              new RoleSeeder(),
                              new AdminSeeder()
                          };

            foreach (ISeeder seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
