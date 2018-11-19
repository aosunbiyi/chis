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
    public class WeekDaysController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public WeekDaysController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/WeekDays
        [HttpGet]
        public IEnumerable<week_days> Getweek_days()
        {
            return _context.week_days;
        }

        // GET: api/WeekDays/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getweek_days([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var week_days = await _context.week_days.FindAsync(id);

            if (week_days == null)
            {
                return NotFound();
            }

            return Ok(week_days);
        }

        // PUT: api/WeekDays/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putweek_days([FromRoute] int id, [FromBody] week_days week_days)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != week_days.id)
            {
                return BadRequest();
            }

            _context.Entry(week_days).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!week_daysExists(id))
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

        // POST: api/WeekDays
        [HttpPost]
        public async Task<IActionResult> Postweek_days([FromBody] week_days week_days)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.week_days.Add(week_days);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getweek_days", new { id = week_days.id }, week_days);
        }

        // DELETE: api/WeekDays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteweek_days([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var week_days = await _context.week_days.FindAsync(id);
            if (week_days == null)
            {
                return NotFound();
            }

            _context.week_days.Remove(week_days);
            await _context.SaveChangesAsync();

            return Ok(week_days);
        }

        private bool week_daysExists(int id)
        {
            return _context.week_days.Any(e => e.id == id);
        }
    }
}