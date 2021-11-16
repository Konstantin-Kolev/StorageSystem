using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Data.Entities
{
    public class Delivery
    {
        public Delivery()
        {
            DeliveryItems = new HashSet<DeliveryItems>();
        }

        public int Id { get; set; }

        public DateTime ArrivalDate { get; set; }

        public string WorkerId { get; set; }
        public User Worker { get; set; }

        public ICollection<DeliveryItems> DeliveryItems { get; set; }
    }
}
