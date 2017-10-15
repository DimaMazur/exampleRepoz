using CityInfo_.NetCore.Entities;
using System.Collections.Generic;

namespace CityInfo_.NetCore.Services
{
    public interface ICityInfoRepository
    {
        bool CityExist(int cityId);
        IEnumerable<City> GetCities();
        City GetCity(int cityId, bool includePointsOfInterest = false);
        IEnumerable<PointOfInterest> GetPointsOfInterst(int cityId);
        PointOfInterest GetPointOfInterst(int cityId, int pointId);
        void AddPointOfInterst(int cityId, PointOfInterest interest);
        bool Save();
    }
}
