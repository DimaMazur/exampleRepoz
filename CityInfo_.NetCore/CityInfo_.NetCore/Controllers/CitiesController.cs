using System.Linq;
using CityInfo_.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using CityInfo_.NetCore.Services;
using System.Collections.Generic;

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
            var result = new List<CityWithoutPointsOfInterestDto>();

            foreach(var c in cities)
            {
                result.Add(new CityWithoutPointsOfInterestDto
                {
                    Name = c.Name,
                    Description = c.Description
                });
            }

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
                var result = new CityDto
                {
                    Description = city.Description,
                    Name = city.Name,
                };

                foreach (var point in city.PointsOfInterest)
                {
                    result.PointsOfInterest.Add(
                        new PointOfInterestDto
                        {
                            Description = point.Description,
                            Name = point.Name
                        }
                    );
                }

                return Ok(result);
            }

            return Ok(new CityWithoutPointsOfInterestDto
            {
                Name = city.Name,
                Description = city.Description
            });
        }
    }
}
