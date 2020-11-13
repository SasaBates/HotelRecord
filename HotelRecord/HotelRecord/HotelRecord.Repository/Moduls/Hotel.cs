using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text;

namespace HotelRecord.Repository.Moduls
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        [Column(TypeName = "varchar(80)")]
        public string Name { get; set; }

        [Range(typeof(DateTime), "1950-01-01", "2020-01-01")]
        public DateTime OpeningYear { get; set; }
        
        public int NumberOfEmployees { get; set; }

        [Range( 9, 1000, ErrorMessage = "NumberOfRooms must be between 9 and 1000")]
        public int NumberOfRooms { get; set; }

        [ForeignKey("HotelChain")]
        public int?  HotelChainId { get; set; }

        public virtual HotelChain  HotelChain { get; set; }
        
    }
}
