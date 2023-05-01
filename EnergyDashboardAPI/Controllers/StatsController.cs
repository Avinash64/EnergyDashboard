using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergyDashboardAPI.Models;

namespace EnergyDashboardAPI.Controllers
{
    [Route("api/stats")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly EnergyContext _context;

        public StatsController(EnergyContext context)
        {
            _context = context;
        }

        [HttpGet("min")]
        public Building min()
        {
            return _context.Buildings.ToList().MinBy(x => x.EnergyUsage);
        }
        [HttpGet("max")]
        public Building max()
        {
            return _context.Buildings.ToList().MaxBy(x => x.EnergyUsage);
        }       

        [HttpGet("average")]
        public double? average()
        {
            return _context.Buildings.ToList().Select(x => x.EnergyUsage).DefaultIfEmpty(0).Average();
        }        
        
        [HttpGet("total")]
        public double? total()
        {
            return _context.Buildings.ToList().Select(x => x.EnergyUsage).DefaultIfEmpty(0).Sum();
        }
        
        [HttpGet("top/{num}")]
        public IEnumerable<Building> top(int num)
        {
            return _context.Buildings.ToList().OrderByDescending(o=>o.EnergyUsage).Take(num);
        }

    }
}
