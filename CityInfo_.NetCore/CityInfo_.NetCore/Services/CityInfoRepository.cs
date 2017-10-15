using CityInfo_.NetCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CityInfo_.NetCore.Services
{
    class CityInfoRepository : ICityInfoRepository
    {
        private CityInfoDBContext _context { get; }

        public CityInfoRepository(CityInfoDBContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return _context.Cities.Where(c => c.Id == cityId).Include(c => c.PointsOfInterest).FirstOrDefault();
            }

            return _context.Cities.Where(c => c.Id == cityId).FirstOrDefault();
        }

        public bool Exist(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }
    }
}
