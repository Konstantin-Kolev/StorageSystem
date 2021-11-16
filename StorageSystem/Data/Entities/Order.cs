using StorageSystem.Data.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Data.Entities
{
    public class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItems>();
            CreatedOn = DateTime.Now;
        }
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public string ManagerId { get; set; }
        public User Manager { get; set; }

        public string WorkerId { get; set; }
        public User Worker { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime CompletedOn { get; set; }

        public OrderStatus Status { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
