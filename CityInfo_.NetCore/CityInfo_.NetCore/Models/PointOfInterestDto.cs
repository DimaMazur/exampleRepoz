using System.ComponentModel.DataAnnotations;

namespace CityInfo_.NetCore.Models
{
    public class PointOfInterestDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.EmailAddress]
        public string Description { get; set; }
    }
}
