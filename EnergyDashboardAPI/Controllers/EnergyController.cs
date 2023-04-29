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
        public List<Energy2015> Get()
        {
            return _context.Energy2015s.ToList();
        }

        [HttpGet("{id}")]
        public  ActionResult<Energy2015> Get(int bbl)
        {
            var energy =  _context.Energy2015s.FirstOrDefaultAsync(m => m.Bbl == bbl);
            if (energy == null){

                return NotFound();
            }
            return Ok(energy);

        }

        [HttpPost]
        public  ActionResult<Energy2015> Post(Energy2015 energy)
        {
            _context.Add(energy);
            _context.SaveChangesAsync();
            return Ok();
        }

        // [HttpPut]
        // public ActionResult<Energy2015> Put(Energy2015 energyData)
        // {
        //     if (energyData == null || energyData.Id == 0)
        //         return BadRequest();

        //     var energy = _context.Energy2015s.FindAsync(energyData.Id);
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
            var energy = await _context.Energy2015s.FindAsync(id);
            if (energy == null) return NotFound();
            _context.Energy2015s.Remove(energy);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
