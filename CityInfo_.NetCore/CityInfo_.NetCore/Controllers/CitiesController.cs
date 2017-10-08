using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo_.NetCore.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(new List<object>
            {
                new { id = 1, Name = "New York city" },
                new { id = 2, Name = "Antwerpen" }
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
