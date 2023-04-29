using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergyDashboardAPI.Models;

namespace EnergyDashboardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyController : ControllerBase
    {
        private readonly EnergyContext _context;

        public EnergyController(EnergyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Building> Get()
        {
            return _context.Buildings.ToList();
        }

        [HttpGet("{id}")]
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

        // [HttpPut]
        // public ActionResult<Building> Put(Building energyData)
        // {
        //     if (energyData == null || energyData.Id == 0)
        //         return BadRequest();

        //     var energy = _context.Buildings.FindAsync(energyData.Id);
        //     if (energy == null)
        //         return NotFound();
        //     energy.Name = energyData.Name;
        //     energy.Description = energyData.Description;
        //     energy.Price = energyData.Price;
        //      _context.SaveChangesAsync();
        //     return Ok();
        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var energy = await _context.Buildings.FindAsync(id);
            if (energy == null) return NotFound();
            _context.Buildings.Remove(energy);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
