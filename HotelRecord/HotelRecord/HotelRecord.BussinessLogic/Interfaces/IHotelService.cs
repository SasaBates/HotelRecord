using HotelRecord.Repository.Moduls;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRecord.BussinessLogic.Interfaces
{
    public interface IHotelService
    {
        IEnumerable<Hotel> GetAllHotels();

        Hotel GetHotel(int id);

        IEnumerable<Hotel> GetHotelsStaffMin(int min);

        void SaveHotel(Hotel hotel);

        Hotel UpdateHotel(Hotel hotel);

        void DeleteHotel(int id);
    }
}
