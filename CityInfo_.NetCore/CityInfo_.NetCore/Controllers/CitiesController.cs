using System.Linq;
using CityInfo_.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo_.NetCore.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (city == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(city);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
