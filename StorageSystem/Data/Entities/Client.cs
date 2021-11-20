using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Data.Entities
{
    public class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
