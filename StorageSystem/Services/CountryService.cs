using StorageSystem.Data;
using StorageSystem.Data.Entities;
using StorageSystem.Models.Country;
using StorageSystem.Services.Contracts;
using StorageSystem.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Services
{
    public class CountryService : ICountryService
    {
        private readonly StorageSystemDbContext context;

        public CountryService(StorageSystemDbContext context)
        {
            this.context = context;
        }

        public async Task Create(CountryInputModel model)
        {
            Country country = model.To<Country>();
            await context.Countries.AddAsync(country);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Country country =  await context.Countries.FindAsync(id);
            context.Countries.Remove(country);
            await context.SaveChangesAsync();
        }

        public T FindById<T>(int id) =>
            context
            .Countries
            .Where(c => c.Id == id)
            .To<T>()
            .FirstOrDefault();

        public IEnumerable<Country> GetAll() =>
            context.Countries;

        public IEnumerable<CountryViewModel> GetAllViewModel() => 
            context.Countries.To<CountryViewModel>().ToList();

        public Country GetById(int id) =>
            context.Countries.Find(id);

        public async Task Update(CountryEditInputModel model)
        {
            Country country = model.To<Country>();

            context.Update(country);
            await context.SaveChangesAsync();
        }
    }
}
