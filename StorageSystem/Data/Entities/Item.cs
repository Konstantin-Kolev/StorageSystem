using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Data.Entities
{
    public class Item
    {
        public Item()
        {
            OrderItems = new HashSet<OrderItems>();
            DeliveryItems = new HashSet<DeliveryItems>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public string Description { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; }

        public ICollection<DeliveryItems> DeliveryItems { get; set; }
    }
}
