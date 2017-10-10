using System;
using System.Linq;
using CityInfo_.NetCore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityInfo_.NetCore.Controllers
{
    [Route("api/cities")]
    public class PointOfInterestController : Controller
    {
        private readonly ILogger<PointOfInterestDto> _logger;

        public PointOfInterestController(ILogger<PointOfInterestDto> logger)
        {
            _logger = logger;
        }

        [HttpGet("{cityId}/pointsOfInterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {

            try
            {
                var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

                if (city == null)
                {
                    _logger.LogInformation("City isn't found in DB");
                    return NotFound();
                }
                else
                {
                    return Ok(city.PointsOfInterest);
                }
            }
            catch (Exception)
            {
                _logger.LogCritical("Exception was occured in Get method in PointOfInterestController");
                return StatusCode(500, "Smth went wrong in server");
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
