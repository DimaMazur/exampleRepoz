using System.Collections.Generic;
using System.Linq;

namespace CityInfo_.NetCore.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPointsOfInterst => PointsOfInterest.Count();
        public IList<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();
    }
}
