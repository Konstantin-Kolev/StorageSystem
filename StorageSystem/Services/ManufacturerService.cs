using StorageSystem.Data;
using StorageSystem.Data.Entities;
using StorageSystem.Models.Manufacturer;
using StorageSystem.Services.Contracts;
using StorageSystem.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly StorageSystemDbContext context;

        public ManufacturerService(StorageSystemDbContext context)
        {
            this.context = context;
        }

        public async Task Create(ManufacturerInputModel model)
        {
            Manufacturer manufacturer = model.To<Manufacturer>();
            await context.Manufacturers.AddAsync(manufacturer);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Manufacturer manufacturer = context.Manufacturers.Find(id);
            context.Manufacturers.Remove(manufacturer);
            await context.SaveChangesAsync();
        }

        public T FindById<T>(int id) =>
            context
            .Manufacturers
            .Where(m => m.Id == id)
            .To<T>()
            .FirstOrDefault();

        public IEnumerable<ManufacturerViewModel> GetAll() =>
            context.Manufacturers.To<ManufacturerViewModel>().ToList();

        public async Task Update(ManufacturerEditInputModel model)
        {
            Manufacturer manufacturer = model.To<Manufacturer>();
            context.Update(manufacturer);
            await context.SaveChangesAsync();
        }
    }
}
