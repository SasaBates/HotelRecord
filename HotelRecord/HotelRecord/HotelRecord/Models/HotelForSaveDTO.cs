using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRecord.Models
{
    public class HotelForSaveDTO
    {

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Range(typeof(DateTime), "1950-01-01", "2020,01-01",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime OpeningYear { get; set; }
        [Required]
        public int NumberOfEmployees { get; set; }

        [Required]
        public int NumberOfRooms { get; set; }

        
        public int? HotelChainId { get; set; }

        
    }
}
