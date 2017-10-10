using System.Linq;
using CityInfo_.NetCore.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPatch("{cityId}/pointsOfInterest/{interestId}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int interestId,
            [FromBody] JsonPatchDocument<PointOfInterestDto> pathDoc)
        {
            if (pathDoc == null)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var interestFromDb = city.PointsOfInterest.FirstOrDefault(i => i.Id == interestId);
            if (interestFromDb == null)
            {
                return NotFound();
            }

            var pointOfInterstToPatch = new PointOfInterestDto
            {
                Name = interestFromDb.Name,
                Description = interestFromDb.Description
            };

            pathDoc.ApplyTo(pointOfInterstToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            interestFromDb.Description = pointOfInterstToPatch.Description;
            interestFromDb.Name = pointOfInterstToPatch.Name;

            return NoContent();
        }

        [HttpDelete("{cityId}/pointsOfInterest/{interestId}")]
        public IActionResult DeletePoitOfInterest(int cityId, int interestId)
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

            city.PointsOfInterest.Remove(interest);

            return NoContent();
        }
    }
}
