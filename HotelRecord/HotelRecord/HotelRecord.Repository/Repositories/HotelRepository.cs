using HotelRecord.Repository.Interfaces;
using HotelRecord.Repository.Moduls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelRecord.Repository.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private HotelRecordDbContext _hotelRecordDbContext;
        public HotelRepository(HotelRecordDbContext hotelRecordDbContext)
        {
            this._hotelRecordDbContext = hotelRecordDbContext;

        }

       
        public void DeleteHotel(int id)
        {

            var forDelete = _hotelRecordDbContext.Hotels.FirstOrDefault(h => h.HotelId == id);
            _hotelRecordDbContext.Hotels.Remove(forDelete);
            _hotelRecordDbContext.SaveChanges();
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            var all = _hotelRecordDbContext.Hotels.
                Include(a => a.HotelChain).
                OrderBy(b => b.OpeningYear);
            return all;
        }

        public Hotel GetHotel(int id)
        {
           var hotel = _hotelRecordDbContext.Hotels.FirstOrDefault(a => a.HotelId == id);
            return hotel;
        }

        public IEnumerable<Hotel> GetHotelsStaffMin(int min)
        {

            var staffMin = _hotelRecordDbContext.Hotels
                .Where(b => b.NumberOfEmployees >= min)
                .OrderBy(a => a.NumberOfEmployees);
            return staffMin;
        }

        public void SaveHotel(Hotel hotel)
        {
            _hotelRecordDbContext.Hotels.Add(hotel);
            _hotelRecordDbContext.SaveChanges();
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            var forUpdate = _hotelRecordDbContext.Hotels.Update(hotel);
            _hotelRecordDbContext.SaveChanges();

            return hotel;

        }
    }
}
