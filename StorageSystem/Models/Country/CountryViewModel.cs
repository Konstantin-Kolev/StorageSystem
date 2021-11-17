using StorageSystem.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Models.Country
{
    public class CountryViewModel : IMapFrom<Data.Entities.Country>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
