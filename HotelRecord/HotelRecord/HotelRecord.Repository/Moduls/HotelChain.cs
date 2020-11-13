using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelRecord.Repository.Moduls
{
    public class HotelChain
    {
        [Key]
        public int HotelChainId { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string Name { get; set; }

        [Range(typeof(DateTime), "1950-01-01", "2010-01-01")]
        public DateTime YearOfEstablishment { get; set; }

        
        public  virtual ICollection<Hotel>  Hotels { get; set; }


    }
}
