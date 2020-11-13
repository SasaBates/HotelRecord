using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ChainController : ControllerBase
    {
        private IHotelChainService _hotelChainService;

        private IHotelService _hotelRepository;

        private IMapper _mapper;

        public ChainController(IHotelChainService hotelChainService, IHotelService hotelRepository, IMapper mapper)
        {
            this._hotelChainService = hotelChainService;
            this._hotelRepository = hotelRepository;
            this._mapper = mapper;

        }

        // GET: api/Chain
        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<HotelChain> hotelChain = _hotelChainService.GetAllHotelChains();
            IEnumerable<HotelChainDTO> hotelChainDTOs = _mapper.Map<IEnumerable<HotelChainDTO>>(hotelChain);

            return Ok(hotelChainDTOs);

        }

        // GET: api/Chain/5
        [HttpGet("{id}")]
        public ActionResult<HotelChainDTO> GetById(int id)
        {
            var hotelChain = _hotelChainService.GetHotelChain(id);
            if (hotelChain == null)
            {
                return NotFound("Ne postoji taj lanac hotela");
            }
            return Ok(_mapper.Map<HotelChainDTO>(hotelChain));

        }

        // POST: api/Chain
        [HttpPost]
        public ActionResult Post(HotelChainForSaveDTO hotelChainForSaveDTO)
        {
            IEnumerable<HotelChain> hotelChains = _hotelChainService.GetAllHotelChains();

            foreach (var hotelChain in hotelChains)
            {
                if (hotelChainForSaveDTO.Name == hotelChain.Name)
                {
                    return BadRequest("We ollready have the Hotel Chain under that name");
                }

            }
            _hotelChainService.SaveHotelChain(_mapper.Map<HotelChain>(hotelChainForSaveDTO));
            return Ok("Save");
        }

        // PUT: api/Chain/body
        [HttpPut]
        public ActionResult<HotelChainDTO> Put(HotelChainForUpdateDTO hotelChainForUpdateDTO)
        {
            var hotelChainForSave = _hotelChainService.UpdateHotelChain(_mapper.Map<HotelChain>(hotelChainForUpdateDTO));

            return Ok(_mapper.Map<HotelChainDTO>(hotelChainForSave));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var forDelete = _hotelChainService.GetHotelChain(id);

            if (forDelete == null)
            {
                return NotFound("Lanac hotela sa zadatim id ne postopji");
            }

            _hotelChainService.DeleteHotelChain(id);
            return Ok("Uspesno obrisano");
        }
    }
}
