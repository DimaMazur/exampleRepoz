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

        [HttpGet("{cityId}/pointsOfInterest/{interestId}", Name = "GetPointOfInterest")]
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

        [HttpPost("{cityId}/pointofinterest")]
        public IActionResult CreatePointOfInterest(int cityId,
            [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (pointOfInterest.Name == pointOfInterest.Description)
            {
                ModelState.AddModelError("Description6", "Name can't be the same as description");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            int maxPointOfInterestId = CitiesDataStore.Current.Cities
                .SelectMany(c => c.PointsOfInterest)
                .Max(p => p.Id);

            var newPointOfInterest = new PointOfInterestDto
            {
                Id = ++maxPointOfInterestId,
                Description = pointOfInterest.Description,
                Name = pointOfInterest.Name
            };

            city.PointsOfInterest.Add(newPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new { cityId = cityId, interestId = newPointOfInterest.Id },
                newPointOfInterest);
        }

        [HttpPut("{cityId}/pointofinterest/{interestId}")]
        public IActionResult UpdatePointOfInterest(int cityId, int interestId,
            [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (pointOfInterest.Name == pointOfInterest.Description)
            {
                ModelState.AddModelError("Description6", "Name can't be the same as description");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var interestPointToUpdate = city.PointsOfInterest.FirstOrDefault(p => p.Id == interestId);

            if (interestPointToUpdate == null)
            {
                return NotFound();
            }

            interestPointToUpdate.Name = interestPointToUpdate.Name;
            interestPointToUpdate.Description = interestPointToUpdate.Description;

            return NoContent();
        }
    }
}
