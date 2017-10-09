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
            Cities = new List<CityDto>
            {
                new CityDto
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "Big park at least"
                },
                new CityDto
                {
                    Id = 2,
                    Name = "Antwerpen",
                    Description = "The one with the cathedral that wes never really finished"
                },
                new CityDto
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower"
                }
            };
        }
    }
}
