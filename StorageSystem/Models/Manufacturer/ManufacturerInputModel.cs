using StorageSystem.Services.Mappings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Models.Manufacturer
{
    public class ManufacturerInputModel : IMapTo<Data.Entities.Manufacturer>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
    }
}
