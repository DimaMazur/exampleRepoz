using CityInfo_.NetCore.Entities;
using System.Collections.Generic;

namespace CityInfo_.NetCore.Services
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> GetCities();
        City GetCity(int cityId, bool includePointsOfInterest);
        bool Exist(int cityId);
    }
}
