using System;
using System.Linq;
using CityInfo_.NetCore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CityInfo_.NetCore.Services;
using AutoMapper;
using System.Collections.Generic;
using CityInfo_.NetCore.Entities;

namespace CityInfo_.NetCore.Controllers
{
    [Route("api/cities")]
    public class PointOfInterestController : Controller
    {
        private readonly ILogger<PointOfInterestDto> _logger;
        private readonly ICityInfoRepository _repository;
        private readonly IMailService _mailService;

        public PointOfInterestController(IMailService mailService, ILogger<PointOfInterestDto> logger,
            ICityInfoRepository repository)
        {
            _logger = logger;
            _mailService = mailService;
            _repository = repository;
        }

        [HttpGet("{cityId}/pointsOfInterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            if (!_repository.CityExist(cityId))
            {
                return NotFound();
            }

            var pointsOfInterest = _repository.GetPointsOfInterst(cityId);
            var pointsToReturn = Mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterest);
            return Ok(pointsToReturn);
        }

        [HttpGet("{cityId}/pointsOfInterest/{interestId}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int interestId)
        {
            if (!_repository.CityExist(cityId))
            {
                return NotFound();
            }

            var interest = _repository.GetPointOfInterst(cityId, interestId);
            if (interest == null)
            {
                return NotFound();
            }

            var interestToReturn = Mapper.Map<PointOfInterestDto>(interest);
            return Ok(interestToReturn);
        }

        [HttpPost("{cityId}/pointOfInterest")]
        public IActionResult CreatePointOfInterest(int cityId,
            [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_repository.CityExist(cityId))
            {
                return NotFound();
            }

            var newPointOfInterest = Mapper.Map<PointOfInterest>(pointOfInterest);
            _repository.AddPointOfInterst(cityId, newPointOfInterest);
            if (!_repository.Save())
            {
                return StatusCode(500, "Something went wrong in server");
            }

            var pointOfInterestToReturn = Mapper.Map<PointOfInterestDto>(newPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new { cityId = cityId, interestId = pointOfInterestToReturn.Id },
                pointOfInterestToReturn);
        }

        //[HttpPut("{cityId}/pointofinterest/{interestId}")]
        //public IActionResult UpdatePointOfInterest(int cityId, int interestId,
        //    [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        //{
        //    if (pointOfInterest == null)
        //    {
        //        return BadRequest();
        //    }

        //    if (pointOfInterest.Name == pointOfInterest.Description)
        //    {
        //        ModelState.AddModelError("Description6", "Name can't be the same as description");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var city = CitiesDataStore.Current.Cities.FirstOrDefault();
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    var interestPointToUpdate = city.PointsOfInterest.FirstOrDefault(p => p.Id == interestId);

        //    if (interestPointToUpdate == null)
        //    {
        //        return NotFound();
        //    }

        //    interestPointToUpdate.Name = interestPointToUpdate.Name;
        //    interestPointToUpdate.Description = interestPointToUpdate.Description;

        //    return NoContent();
        //}

        //[HttpPatch("{cityId}/pointsOfInterest/{interestId}")]
        //public IActionResult PartiallyUpdatePointOfInterest(int cityId, int interestId,
        //    [FromBody] JsonPatchDocument<PointOfInterestDto> pathDoc)
        //{
        //    if (pathDoc == null)
        //    {
        //        return BadRequest();
        //    }

        //    var city = CitiesDataStore.Current.Cities.FirstOrDefault();
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    var interestFromDb = city.PointsOfInterest.FirstOrDefault(i => i.Id == interestId);
        //    if (interestFromDb == null)
        //    {
        //        return NotFound();
        //    }

        //    var pointOfInterstToPatch = new PointOfInterestDto
        //    {
        //        Name = interestFromDb.Name,
        //        Description = interestFromDb.Description
        //    };

        //    pathDoc.ApplyTo(pointOfInterstToPatch, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    interestFromDb.Description = pointOfInterstToPatch.Description;
        //    interestFromDb.Name = pointOfInterstToPatch.Name;

        //    return NoContent();
        //}

        //[HttpDelete("{cityId}/pointsOfInterest/{interestId}")]
        //public IActionResult DeletePoitOfInterest(int cityId, int interestId)
        //{
        //    var city = CitiesDataStore.Current.Cities.FirstOrDefault();
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    var interest = city.PointsOfInterest.FirstOrDefault(i => i.Id == interestId);
        //    if (interest == null)
        //    {
        //        return NotFound();
        //    }

        //    city.PointsOfInterest.Remove(interest);

        //    return NoContent();
        //}
    }
}
