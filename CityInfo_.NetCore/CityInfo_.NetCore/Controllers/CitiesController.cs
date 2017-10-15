using System.Linq;
using CityInfo_.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using CityInfo_.NetCore.Services;
using System.Collections.Generic;
using AutoMapper;

namespace CityInfo_.NetCore.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private readonly ICityInfoRepository repository;

        public CitiesController(ICityInfoRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = repository.GetCities();
            var result = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cities);

            return Ok(result);
        }

        // GET api/values/5?includePointsOfInterest=true
        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = repository.GetCity(id, includePointsOfInterest);
            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {
                var cityDto = Mapper.Map<CityDto>(city);
                return Ok(cityDto);
            }


            var cityWithoutPointsOfInterest = Mapper.Map<CityWithoutPointsOfInterestDto>(city);
            return Ok(cityWithoutPointsOfInterest);
        }
    }
}
