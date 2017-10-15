using System.Collections.Generic;
using CityInfo_.NetCore.Models;

namespace CityInfo_.NetCore
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityWithoutPointsOfInterestDto> Cities { get; set; }

        public CitiesDataStore()
        { }
    }
}
