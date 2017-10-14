using CityInfo_.NetCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityInfo_.NetCore.Controllers
{
    [Route("api/dummy")]
    public class DummyController : Controller
    {
        private readonly CityInfoDBContext _context;

        public DummyController(CityInfoDBContext context)
        {
            _context = context;
        }

        public IActionResult HttpGetAttribute()
        {
            return Ok();
        }
    }
}
