using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CityInfo_.NetCore.Entities
{
    public static class CityInfoDBContextExtensions
    {
        public static void EnsureSeedDataForCOntext(this CityInfoDBContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }

            var cities = new List<City>
            {
                new City
                {
                    Name = "New York City",
                    Description = "Big park at least",
                    PointsOfInterest = new List<PointOfInterest>
                    {
                        new PointOfInterest
                        {
                            Name = "Central Park",
                            Description = "The most visited urban park in USA"
                        },
                        new PointOfInterest
                        {
                            Name = "Empire State Building",
                            Description = "A 102-story skyscrapper located in Midtown Manhattan"
                        }
                    }
                },
                new City
                {
                    Name = "Antwerpen",
                    Description = "The one with the cathedral that wes never really finished"
                },
                new City
                {
                    Name = "Paris",
                    Description = "The one with that big tower"
                }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
