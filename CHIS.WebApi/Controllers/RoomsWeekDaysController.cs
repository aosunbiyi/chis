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
    public class RoomsWeekDaysController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public RoomsWeekDaysController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/RoomsWeekDays
        [HttpGet]
        public IEnumerable<rooms_week_days> Getrooms_week_days()
        {
            return _context.rooms_week_days;
        }

        // GET: api/RoomsWeekDays/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getrooms_week_days([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rooms_week_days = await _context.rooms_week_days.FindAsync(id);

            if (rooms_week_days == null)
            {
                return NotFound();
            }

            return Ok(rooms_week_days);
        }

        // PUT: api/RoomsWeekDays/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrooms_week_days([FromRoute] int id, [FromBody] rooms_week_days rooms_week_days)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rooms_week_days.room_id)
            {
                return BadRequest();
            }

            _context.Entry(rooms_week_days).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rooms_week_daysExists(id))
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

        // POST: api/RoomsWeekDays
        [HttpPost]
        public async Task<IActionResult> Postrooms_week_days([FromBody] rooms_week_days rooms_week_days)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.rooms_week_days.Add(rooms_week_days);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (rooms_week_daysExists(rooms_week_days.room_id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getrooms_week_days", new { id = rooms_week_days.room_id }, rooms_week_days);
        }

        // DELETE: api/RoomsWeekDays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterooms_week_days([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rooms_week_days = await _context.rooms_week_days.FindAsync(id);
            if (rooms_week_days == null)
            {
                return NotFound();
            }

            _context.rooms_week_days.Remove(rooms_week_days);
            await _context.SaveChangesAsync();

            return Ok(rooms_week_days);
        }

        private bool rooms_week_daysExists(int id)
        {
            return _context.rooms_week_days.Any(e => e.room_id == id);
        }
    }
}