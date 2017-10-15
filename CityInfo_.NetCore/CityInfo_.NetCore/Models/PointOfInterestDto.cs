using System.ComponentModel.DataAnnotations;

namespace CityInfo_.NetCore.Models
{
    public class PointOfInterestDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Description { get; set; }
    }
}
