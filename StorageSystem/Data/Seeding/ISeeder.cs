using System;
using System.Threading.Tasks;

namespace StorageSystem.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(StorageSystemDbContext dbContext, IServiceProvider serviceProvider);
    }
}
