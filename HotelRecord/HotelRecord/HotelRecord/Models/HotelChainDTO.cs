using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRecord.Models
{
    public class HotelChainDTO
    {
        public int HotelChainId { get; set; }

        public string Name { get; set; }

       
        public DateTime YearOfEstablishment { get; set; }

        public List<HotelDTO> Hotel { get; set; }
    }
}
