using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelRecord.BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private IHotelChainService _hotelChainService;
        private IMapper _mapper;

        public WorkersController(IHotelChainService hotelChainService, IMapper mapper)
        {
            this._hotelChainService = hotelChainService;
            this._mapper = mapper;
        }

        // GET: api/Workers
        public ActionResult Get()
        {
            return Ok(_hotelChainService.GetWorkers());
        }
    }
}