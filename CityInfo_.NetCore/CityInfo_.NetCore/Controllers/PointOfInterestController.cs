using System.Linq;
using CityInfo_.NetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo_.NetCore.Controllers
{
    [Route("api/cities")]
    public class PointOfInterestController : Controller
    {
        [HttpGet("{cityId}/pointsOfInterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(city.PointsOfInterest);
            }
        }

        [HttpGet("{cityId}/pointsOfInterest/{interestId}")]
        public IActionResult Get(int cityId, int interestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var interest = city.PointsOfInterest.FirstOrDefault(i => i.Id == interestId);

            if (interest == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(interest);
            }
        }
    }
}
