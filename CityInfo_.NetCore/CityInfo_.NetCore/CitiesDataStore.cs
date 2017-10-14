using System.Collections.Generic;
using CityInfo_.NetCore.Models;

namespace CityInfo_.NetCore
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            
        }
    }
}
