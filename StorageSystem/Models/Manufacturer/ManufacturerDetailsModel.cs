using StorageSystem.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Models.Manufacturer
{
    public class ManufacturerDetailsModel : IMapFrom<Data.Entities.Manufacturer>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }
    }
}
