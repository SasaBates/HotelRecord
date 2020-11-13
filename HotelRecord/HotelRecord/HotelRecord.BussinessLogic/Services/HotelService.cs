using HotelRecord.BussinessLogic.Interfaces;
using HotelRecord.Repository.Interfaces;
using HotelRecord.Repository.Moduls;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRecord.BussinessLogic.Services
{
    public class HotelService : IHotelService
    {

        private IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {

            this._hotelRepository = hotelRepository;
        }
        public void DeleteHotel(int id)
        {
            _hotelRepository.DeleteHotel(id);
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAllHotels();
        }

        public Hotel GetHotel(int id)
        {
            return _hotelRepository.GetHotel(id);
        }

        public IEnumerable<Hotel> GetHotelsStaffMin(int min)
        {
           return _hotelRepository.GetHotelsStaffMin(min);
        }

        public void SaveHotel(Hotel hotel)
        {
            _hotelRepository.SaveHotel(hotel);
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            return _hotelRepository.UpdateHotel(hotel);
        }
    }
}
