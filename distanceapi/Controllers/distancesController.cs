using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using distanceapi.Models;

namespace distanceapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class distancesController : ControllerBase
    {
        private readonly DistanceDbContext _context;

        public distancesController(DistanceDbContext context)
        {
            _context = context;
        }

        // GET: api/distances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<distance>>> GetGetDistances()
        {
            return await _context.GetDistances.ToListAsync();
        }

        // GET: api/distances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<distance>> Getdistance(int id)
        {
            var distance = await _context.GetDistances.FindAsync(id);

            if (distance == null)
            {
                return NotFound();
            }

            return distance;
        }

        // PUT: api/distances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putdistance(int id, distance distance)
        {
            if (id != distance.distance_id)
            {
                return BadRequest();
            }

            _context.Entry(distance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!distanceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/distances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<distance>> Postdistance(distance distance)
        {
            distance.date = DateTime.Now;
            _context.GetDistances.Add(distance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdistance", new { id = distance.distance_id }, distance);
        }

        // DELETE: api/distances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletedistance(int id)
        {
            var distance = await _context.GetDistances.FindAsync(id);
            if (distance == null)
            {
                return NotFound();
            }

            _context.GetDistances.Remove(distance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool distanceExists(int id)
        {
            return _context.GetDistances.Any(e => e.distance_id == id);
        }
    }
}
