using CityInfo_.NetCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CityInfo_.NetCore.Services
{
    class CityInfoRepository : ICityInfoRepository
    {
        private CityInfoDBContext _context { get; }

        public bool CityExist(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }

        public CityInfoRepository(CityInfoDBContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest = false)
        {
            if (includePointsOfInterest)
            {
                return _context.Cities.Where(c => c.Id == cityId).Include(c => c.PointsOfInterest).FirstOrDefault();
            }

            return _context.Cities.Where(c => c.Id == cityId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterst(int cityId)
        {
            if (!CityExist(cityId))
            {
                return null;
            }

            return _context.PointsOfInterest.Where(p => p.CityId == cityId).ToList();
        }

        public PointOfInterest GetPointOfInterst(int cityId, int pointId)
        {
            if (!CityExist(cityId))
            {
                return null;
            }

            return _context.PointsOfInterest.Where(p => p.CityId == cityId && p.Id == pointId).FirstOrDefault();
        }

        public void AddPointOfInterst(int cityId, PointOfInterest interest)
        {
            if (!CityExist(cityId))
            {
                throw new Exception("City with this Id isn't found");
            }

            GetCity(cityId).PointsOfInterest.Add(interest);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }       
    }
}
