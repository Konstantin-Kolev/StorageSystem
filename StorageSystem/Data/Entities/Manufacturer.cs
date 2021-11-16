using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Data.Entities
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Items = new HashSet<Item>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
