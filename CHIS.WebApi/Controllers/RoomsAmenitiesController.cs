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
    public class RoomsAmenitiesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public RoomsAmenitiesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/RoomsAmenities
        [HttpGet]
        public IEnumerable<rooms_amenities> Getrooms_amenities()
        {
            return _context.rooms_amenities;
        }

        // GET: api/RoomsAmenities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getrooms_amenities([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rooms_amenities = await _context.rooms_amenities.FindAsync(id);

            if (rooms_amenities == null)
            {
                return NotFound();
            }

            return Ok(rooms_amenities);
        }

        // PUT: api/RoomsAmenities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrooms_amenities([FromRoute] int id, [FromBody] rooms_amenities rooms_amenities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rooms_amenities.room_id)
            {
                return BadRequest();
            }

            _context.Entry(rooms_amenities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rooms_amenitiesExists(id))
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

        // POST: api/RoomsAmenities
        [HttpPost]
        public async Task<IActionResult> Postrooms_amenities([FromBody] rooms_amenities rooms_amenities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.rooms_amenities.Add(rooms_amenities);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (rooms_amenitiesExists(rooms_amenities.room_id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getrooms_amenities", new { id = rooms_amenities.room_id }, rooms_amenities);
        }

        // DELETE: api/RoomsAmenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterooms_amenities([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rooms_amenities = await _context.rooms_amenities.FindAsync(id);
            if (rooms_amenities == null)
            {
                return NotFound();
            }

            _context.rooms_amenities.Remove(rooms_amenities);
            await _context.SaveChangesAsync();

            return Ok(rooms_amenities);
        }

        private bool rooms_amenitiesExists(int id)
        {
            return _context.rooms_amenities.Any(e => e.room_id == id);
        }
    }
}