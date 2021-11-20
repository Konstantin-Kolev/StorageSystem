using StorageSystem.Data.Entities;
using StorageSystem.Models.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Services.Contracts
{
    public interface ICountryService
    {
        public Task Create(CountryInputModel model);

        public Task Update(CountryEditInputModel model);

        public IEnumerable<CountryViewModel> GetAllViewModel();

        public IEnumerable<Country> GetAll();

        public Task Delete(int id);

        public T FindById<T>(int id);

        public Country GetById(int id);
    }
}
