using AutoMapper;
using HotelRecord.Models;
using HotelRecord.Repository.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace HotelRecord.Helpers
{
    public class AutoMaping : Profile
    {

        public AutoMaping()
        {
            CreateMap<Hotel, HotelDTO>();
            
            CreateMap<HotelForSaveDTO, Hotel>();
            CreateMap<HotelForUpdateDTO, Hotel>();

            CreateMap<HotelChain, HotelChainDTO>();
            CreateMap<HotelChainForSaveDTO, HotelChain >();
            CreateMap<HotelChainForUpdateDTO, HotelChain >();
            CreateMap< IEnumerable<HotelChainDTO>, IEnumerable<HotelChain>>();
            CreateMap< IEnumerable<HotelDTO>, IEnumerable<Hotel>>();
           
        }
    }
}
