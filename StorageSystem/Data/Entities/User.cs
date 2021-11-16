using Microsoft.AspNetCore.Identity;
using StorageSystem.Data.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Data.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            CreatedOrders = new HashSet<Order>();
            CompletedOrders = new HashSet<Order>();
            AcceptedDeliveries = new HashSet<Delivery>();
        }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public UserRole Role { get; set; }

        public ICollection<Order> CreatedOrders { get; set; }

        public ICollection<Order> CompletedOrders { get; set; }

        public ICollection<Delivery> AcceptedDeliveries { get; set; }
    }
}
