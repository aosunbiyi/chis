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
    public class RoomTypesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public RoomTypesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/RoomTypes
        [HttpGet]
        public IEnumerable<room_types> Getroom_types()
        {
            return _context.room_types.Include(a=>a.rooms).Include(a=>a.room_types_rates).Select(a=>a).ToList();
        }

        [HttpGet("getRoomTypeRates/{id}")]
        public async Task<IActionResult> getRoomtypeRates([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roomRates = await _context.room_types_rates.Include(a=>a.rate_).Where(a => a.room_type_id == id).ToListAsync();

            var day = DateTime.Now.DayOfWeek.ToString();
            var isWeekDay = await _context.week_days.Where(a => a.day_name == day).Select(a => a.isweekday).SingleAsync();

            var rate = roomRates.Where(a => a.rate_.isweekday == isWeekDay).FirstOrDefault();

            if (rate == null)
            {
                return NotFound();
            }

            return Ok(rate);

        }

        // GET: api/RoomTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getroom_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room_types = await _context.room_types.FindAsync(id);

            if (room_types == null)
            {
                return NotFound();
            }

            return Ok(room_types);
        }


        // PUT: api/RoomTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putroom_types([FromRoute] int id, [FromBody] room_types room_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room_types.id)
            {
                return BadRequest();
            }

            _context.Entry(room_types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!room_typesExists(id))
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

        // POST: api/RoomTypes
        [HttpPost]
        public async Task<IActionResult> Postroom_types([FromBody] room_types room_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.room_types.Add(room_types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getroom_types", new { id = room_types.id }, room_types);
        }

        // DELETE: api/RoomTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteroom_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room_types = await _context.room_types.FindAsync(id);
            if (room_types == null)
            {
                return NotFound();
            }

            _context.room_types.Remove(room_types);
            await _context.SaveChangesAsync();

            return Ok(room_types);
        }

        private bool room_typesExists(int id)
        {
            return _context.room_types.Any(e => e.id == id);
        }
    }
}