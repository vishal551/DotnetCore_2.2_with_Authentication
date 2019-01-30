using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthCoreWEBAPI.DTO;
using AuthCoreWEBAPI.Helpers;
using AuthCoreWEBAPI.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthCoreWEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        //GET: api/<controller>
        private ICity _icityservice;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public CityController(ICity icityservice, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _icityservice = icityservice;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        [HttpGet]
        //[HttpGet("getallcitylist")]
        public IActionResult GetAllCityList()
        {
            var citys = _icityservice.GetAllCity();
            var cityDtos = _mapper.Map<IList<CityDTO>>(citys);
            return Ok(cityDtos);
        }

    }
}
