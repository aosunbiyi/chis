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
    public class AmenitiesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public AmenitiesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Amenities
        [HttpGet]
        public IEnumerable<amenities> Getamenities()
        {
            return _context.amenities;
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getamenities([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var amenities = await _context.amenities.FindAsync(id);

            if (amenities == null)
            {
                return NotFound();
            }

            return Ok(amenities);
        }

        // PUT: api/Amenities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putamenities([FromRoute] int id, [FromBody] amenities amenities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != amenities.id)
            {
                return BadRequest();
            }

            _context.Entry(amenities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!amenitiesExists(id))
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

        // POST: api/Amenities
        [HttpPost]
        public async Task<IActionResult> Postamenities([FromBody] amenities amenities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.amenities.Add(amenities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getamenities", new { id = amenities.id }, amenities);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteamenities([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var amenities = await _context.amenities.FindAsync(id);
            if (amenities == null)
            {
                return NotFound();
            }

            _context.amenities.Remove(amenities);
            await _context.SaveChangesAsync();

            return Ok(amenities);
        }

        private bool amenitiesExists(int id)
        {
            return _context.amenities.Any(e => e.id == id);
        }
    }
}