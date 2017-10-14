using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo_.NetCore.Entities
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name{ get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public IList<PointOfInterest> PointsOfInterest { get; set; } = new List<PointOfInterest>();
    }
}
