using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CHIS.Core.Domain;

namespace CHIS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public FloorsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Floors
        [HttpGet]
        public IEnumerable<floors> Getfloors()
        {
            return _context.floors;
        }

        // GET: api/Floors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getfloors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var floors = await _context.floors.FindAsync(id);

            if (floors == null)
            {
                return NotFound();
            }

            return Ok(floors);
        }

        [HttpGet("getFloorByWingId/{id}")]
        public async Task<IActionResult> getFloorByWingId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var floors = await _context.floors.Where(a => a.wing_id == id).ToListAsync();

            if (floors == null)
                return NotFound();
            return Ok(floors);

        }

        // PUT: api/Floors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfloors([FromRoute] int id, [FromBody] floors floors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != floors.id)
            {
                return BadRequest();
            }

            _context.Entry(floors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!floorsExists(id))
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

        // POST: api/Floors
        [HttpPost]
        public async Task<IActionResult> Postfloors([FromBody] floors floors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.floors.Add(floors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfloors", new { id = floors.id }, floors);
        }

        // DELETE: api/Floors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletefloors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var floors = await _context.floors.FindAsync(id);
            if (floors == null)
            {
                return NotFound();
            }

            _context.floors.Remove(floors);
            await _context.SaveChangesAsync();

            return Ok(floors);
        }

        private bool floorsExists(int id)
        {
            return _context.floors.Any(e => e.id == id);
        }
    }
}