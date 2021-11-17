using StorageSystem.Services.Mappings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StorageSystem.Models.Country
{
    public class CountryEditInputModel : IMapTo<Data.Entities.Country>, IMapFrom<Data.Entities.Country>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 2, ErrorMessage = "The Country code must be 2 or 3 letters")]
        [RegularExpression(@"^[A-Z]+$", ErrorMessage = "The Country code must be in capital letter only")]
        public string Code { get; set; }
    }
}
