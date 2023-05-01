using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergyDashboardAPI.Models;

namespace EnergyDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly EnergyContext _context;

        public MapController(EnergyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<BuildingMap> Get()
        {
            List<BuildingMap> buildingMaps = new List<BuildingMap>();
            foreach (Building building in _context.Buildings.ToList())
            {
                BuildingMap buildingMap = new BuildingMap
                {
                    Bbl = building.Bbl,
                    BuildingName = building.BuildingName,
                    BuildingAddress = building.BuildingAddress,
                    EnergyUsage = building.EnergyUsage,
                    Latitude = building.Latitude,
                    Longitude = building.Longitude
                };

                buildingMaps.Add(buildingMap);
            }
            return buildingMaps;
        }

        [HttpGet("{bbl}")]
        public async Task<ActionResult<Building>> Get(long bbl)
        {
            var energy = await _context.Buildings.FirstOrDefaultAsync(m => m.Bbl == bbl);
            if (energy == null)
            {

                return NotFound();
            }
            return Ok(energy);

        }


    }
}
