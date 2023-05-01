using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergyDashboardAPI.Models;

namespace EnergyDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly EnergyContext _context;

        public StatsController(EnergyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Building> Get()
        {
            return _context.Buildings.ToList();
        }

        [HttpGet("{bbl}")]
        public async Task<ActionResult<Building>> Get(long bbl)
        {
            var energy = await _context.Buildings.FirstOrDefaultAsync(m => m.Bbl == bbl);
            if (energy == null){

                return NotFound();
            }
            return Ok(energy);

        }

        [HttpPost]
        public  async Task<ActionResult<Building>> Post(Building energy)
        {
            _context.Add(energy);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Building buildingData)
        {
            if (buildingData == null || buildingData.Bbl == 0)
                return BadRequest();

            var building = await _context.Buildings.FindAsync(buildingData.Bbl);
            if (building == null)
                return NotFound();
            building.BoroughNumber = buildingData.BoroughNumber;
            building.BuildingName = buildingData.BuildingName;
            building.BuildingAddress = buildingData.BuildingAddress;
            building.Borough = buildingData.Borough;
            building.State = buildingData.State;
            building.Postcode = buildingData.Postcode;
            building.Block = buildingData.Block;
            building.Lot = buildingData.Lot;
            building.EnergyUsage = buildingData.EnergyUsage;
            building.Latitude = buildingData.Latitude;
            building.Longitude = buildingData.Longitude;
            building.CommunityBoard = buildingData.CommunityBoard;
            building.CouncilDistrict = buildingData.CouncilDistrict;
            building.CensusTract = buildingData.CensusTract;
            building.Bin = buildingData.Bin;
            building.Nta = buildingData.Nta;
             await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{bbl}")]
        public async Task<IActionResult> Delete(long bbl)
        {
            var energy = await _context.Buildings.FindAsync(bbl);
            if (energy == null) return NotFound();
            _context.Buildings.Remove(energy);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
