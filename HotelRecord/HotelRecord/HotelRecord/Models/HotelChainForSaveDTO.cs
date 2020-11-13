using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRecord.Models
{
    public class HotelChainForSaveDTO
    {
        [Required]
        [MaxLength(75)]
        public string Name { get; set; }

        [Range(typeof(DateTime), "1850-01-01", "2010,01-01",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime YearOfEstablishment { get; set; }
    }
}
