using Microsoft.EntityFrameworkCore;

namespace CityInfo_.NetCore.Entities
{
    public class CityInfoDBContext : DbContext
    {
        public CityInfoDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }
    }
}
