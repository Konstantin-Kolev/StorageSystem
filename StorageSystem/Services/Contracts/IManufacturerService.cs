using StorageSystem.Models.Manufacturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Services.Contracts
{
    public interface IManufacturerService
    {
        public Task Create(ManufacturerInputModel model);

        public Task Update(ManufacturerEditInputModel model);

        public IEnumerable<ManufacturerViewModel> GetAll();

        public Task Delete(int id);

        public T FindById<T>(int id);
    }
}
