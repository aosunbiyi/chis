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
    public class HotelRepresentativesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public HotelRepresentativesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/HotelRepresentatives
        [HttpGet]
        public IEnumerable<hotel_representatives> Gethotel_representatives()
        {
            return _context.hotel_representatives;
        }

        // GET: api/HotelRepresentatives/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Gethotel_representatives([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotel_representatives = await _context.hotel_representatives.FindAsync(id);

            if (hotel_representatives == null)
            {
                return NotFound();
            }

            return Ok(hotel_representatives);
        }

        // PUT: api/HotelRepresentatives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Puthotel_representatives([FromRoute] int id, [FromBody] hotel_representatives hotel_representatives)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotel_representatives.id)
            {
                return BadRequest();
            }

            _context.Entry(hotel_representatives).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hotel_representativesExists(id))
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

        // POST: api/HotelRepresentatives
        [HttpPost]
        public async Task<IActionResult> Posthotel_representatives([FromBody] hotel_representatives hotel_representatives)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.hotel_representatives.Add(hotel_representatives);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gethotel_representatives", new { id = hotel_representatives.id }, hotel_representatives);
        }

        // DELETE: api/HotelRepresentatives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletehotel_representatives([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hotel_representatives = await _context.hotel_representatives.FindAsync(id);
            if (hotel_representatives == null)
            {
                return NotFound();
            }

            _context.hotel_representatives.Remove(hotel_representatives);
            await _context.SaveChangesAsync();

            return Ok(hotel_representatives);
        }

        private bool hotel_representativesExists(int id)
        {
            return _context.hotel_representatives.Any(e => e.id == id);
        }
    }
}