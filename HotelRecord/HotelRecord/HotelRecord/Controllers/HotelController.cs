using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Threading.Tasks;
using AutoMapper;
using HotelRecord.BussinessLogic.Interfaces;
using HotelRecord.Models;
using HotelRecord.Repository.Moduls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {

        private IHotelService _hotelService;
        private IMapper _mapper;

        public HotelController(IHotelService hotelService, IMapper mapper)
        {
            this._hotelService = hotelService;
            this._mapper = mapper;
        }
        // GET: api/Hotel
        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Hotel> hotels = _hotelService.GetAllHotels();
            IEnumerable<HotelDTO> hotelDTOs = _mapper.Map<IEnumerable<HotelDTO>>(hotels);

            return Ok(hotelDTOs);
        }

        // GET: api/Hotel/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        { 
            return Ok(_mapper.Map<HotelDTO>(_hotelService.GetHotel(id)));
        }

       
        // POST: api/Hotel
        [HttpPost]
        public void Post(HotelForSaveDTO hotelForSaveDTO)
        {
            IEnumerable<Hotel> hotels = _hotelService.GetAllHotels();

            foreach (var hotel in hotels)
            {
                if (hotelForSaveDTO.Name == hotel.Name)
                {
                    //return BadRequest("We ollready have the Hotel under that name");
                    

                }
               
            }
            _hotelService.SaveHotel(_mapper.Map<Hotel>(hotelForSaveDTO));
           // return Ok();

        }

        // PUT: api/Hotel
        [HttpPut]
        public void Put(HotelForUpdateDTO hotelForUpdateDTO)
        {
            var hotelUpdate = _hotelService.UpdateHotel(_mapper.Map<Hotel>(hotelForUpdateDTO));
            _mapper.Map<HotelDTO>(hotelUpdate);

           // return Ok(_mapper.Map<HotelDTO>(hotelUpdate));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deletedHotel = _hotelService.GetHotel(id);

            if (deletedHotel == null)
            {
                return NotFound("Hotel sa zadatim id ne postoji");
            }

            _hotelService.DeleteHotel(id);
            return Ok("Uspesno obrisano");
        }
    }
}
