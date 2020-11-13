using HotelRecord.BussinessLogic.Interfaces;
using HotelRecord.Repository.Interfaces;
using HotelRecord.Repository.Moduls;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRecord.BussinessLogic.Services
{
    public class HotelChainService : IHotelChainService
    {

        private IHotelChainRepository _hotelChainRepositori;

        

        public HotelChainService(IHotelChainRepository hotelChainRepository)
        {
            this._hotelChainRepositori = hotelChainRepository;
        }
        public void DeleteHotelChain(int id)
        {
            
            _hotelChainRepositori.DeleteHotelChain(id);
        }

        public IEnumerable<HotelChain> GetAllHotelChains()
        {
            return _hotelChainRepositori. GetAllHotelChains();
        }

        public HotelChain GetHotelChain(int id)
        {
            return _hotelChainRepositori.GetHotelChain(id);
        }

        public IEnumerable<HotelChain> GetTradition()
        {
            return _hotelChainRepositori.GetTradition();
        }

        public IEnumerable<HotelChain> GetWorkers()
        {
            return _hotelChainRepositori.GetWorkers();
        }

        public void SaveHotelChain(HotelChain hotelChain)
        {
            _hotelChainRepositori.SaveHotelChain(hotelChain);
        }

        public HotelChain UpdateHotelChain(HotelChain hotelChain)
        {
            return _hotelChainRepositori.UpdateHotelChain(hotelChain);
        }
    }
}
