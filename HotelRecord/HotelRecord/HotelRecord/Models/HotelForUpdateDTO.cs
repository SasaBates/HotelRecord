using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelRecord.Models
{
    public class HotelForUpdateDTO
    {

        public int HotelId { get; set; }

        public string Name { get; set; }


        public DateTime OpeningYear { get; set; }

        public int NumberOfEmployees { get; set; }


        public int NumberOfRooms { get; set; }


        public int? HotelChainId { get; set; }


    }
}
