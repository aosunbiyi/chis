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
    public class ReservationLogEntriesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public ReservationLogEntriesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/ReservationLogEntries
        [HttpGet]
        public IEnumerable<reservation_log_entries> Getreservation_log_entries()
        {
            return _context.reservation_log_entries;
        }

        // GET: api/ReservationLogEntries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getreservation_log_entries([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservation_log_entries = await _context.reservation_log_entries.FindAsync(id);

            if (reservation_log_entries == null)
            {
                return NotFound();
            }

            return Ok(reservation_log_entries);
        }

        // PUT: api/ReservationLogEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putreservation_log_entries([FromRoute] int id, [FromBody] reservation_log_entries reservation_log_entries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservation_log_entries.id)
            {
                return BadRequest();
            }

            _context.Entry(reservation_log_entries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reservation_log_entriesExists(id))
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

        // POST: api/ReservationLogEntries
        [HttpPost]
        public async Task<IActionResult> Postreservation_log_entries([FromBody] reservation_log_entries reservation_log_entries)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.reservation_log_entries.Add(reservation_log_entries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getreservation_log_entries", new { id = reservation_log_entries.id }, reservation_log_entries);
        }

        // DELETE: api/ReservationLogEntries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletereservation_log_entries([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservation_log_entries = await _context.reservation_log_entries.FindAsync(id);
            if (reservation_log_entries == null)
            {
                return NotFound();
            }

            _context.reservation_log_entries.Remove(reservation_log_entries);
            await _context.SaveChangesAsync();

            return Ok(reservation_log_entries);
        }

        private bool reservation_log_entriesExists(int id)
        {
            return _context.reservation_log_entries.Any(e => e.id == id);
        }
    }
}