using HotelRecord.Repository.Interfaces;
using HotelRecord.Repository.Moduls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelRecord.Repository.Repositories
{
    public class HotelChainRepository : IHotelChainRepository
    {

        private HotelRecordDbContext _hotelRecordDbContext;
        private IHotelRepository _hotelRepository;
        public HotelChainRepository(HotelRecordDbContext hotelRecordDbContext, IHotelRepository hotelRepository)
        {
            this._hotelRecordDbContext = hotelRecordDbContext;
            this._hotelRepository = hotelRepository;

        }

        public void DeleteHotelChain(int id)
        {
            IEnumerable<Hotel> hotels = _hotelRepository.GetAllHotels();

            List<Hotel> hotelsForDelete = new List<Hotel>();

            foreach (var hotel in hotels)
            {
                if (id == hotel.HotelChain.HotelChainId)
                {
                    hotelsForDelete.Add(hotel);
                    
                }

            }

            foreach (var hotel in hotelsForDelete)
            {
                if (hotelsForDelete != null)
                {
                    _hotelRepository.DeleteHotel(hotel.HotelId);
                }

            }
            

            var hotelChainForDelete = _hotelRecordDbContext.HotelChains.FirstOrDefault(a => a.HotelChainId == id);
           _hotelRecordDbContext.Remove(hotelChainForDelete);
            _hotelRecordDbContext.SaveChanges();
           
        }

        public IEnumerable<HotelChain> GetAllHotelChains()
        {
            return _hotelRecordDbContext.HotelChains;
        }

        public HotelChain GetHotelChain(int id)
        {
            var hotelChain = _hotelRecordDbContext.HotelChains.FirstOrDefault(a => a.HotelChainId == id);
           
            return hotelChain;
        }

        public IEnumerable<HotelChain> GetTradition()
        {
            var hotelYearTradition = _hotelRecordDbContext.HotelChains.OrderBy(a => a.YearOfEstablishment).Take(2);
            return hotelYearTradition;
        }

        public IEnumerable<HotelChain> GetWorkers()
        
        {
            var avrageEmployee = _hotelRecordDbContext.HotelChains.OrderBy(b => b.Name)
                        .Include(a => a.Hotels);
            return avrageEmployee;
           
        }

        public void SaveHotelChain(HotelChain hotelChain)
        {
            _hotelRecordDbContext.HotelChains.Add(hotelChain);
            _hotelRecordDbContext.SaveChanges();
        }

        public HotelChain UpdateHotelChain(HotelChain hotelChain)
        {
            var forUpdate = _hotelRecordDbContext.HotelChains.Update(hotelChain);
            _hotelRecordDbContext.SaveChanges();

            return hotelChain;
        }
    }
}
