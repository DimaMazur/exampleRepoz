using System.ComponentModel.DataAnnotations;

namespace CityInfo_.NetCore.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required(ErrorMessage = "Name should be required", AllowEmptyStrings = false)]
        [MaxLength(50)]
        public string Name { get; set; }


        [MaxLength(200)]
        public string Description { get; set; }
    }
}
