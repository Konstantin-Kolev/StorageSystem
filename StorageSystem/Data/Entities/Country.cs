using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Data.Entities
{
    public class Country
    {
        public Country()
        {
            Clients = new HashSet<Client>();
            Manufacturers = new HashSet<Manufacturer>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public ICollection<Client> Clients { get; set; }

        public ICollection<Manufacturer> Manufacturers { get; set; }
    }
}
