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
    public class ReservedRoomsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public ReservedRoomsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/ReservedRooms
        [HttpGet]
        public IEnumerable<reserved_rooms> Getreserved_rooms()
        {
            return _context.reserved_rooms;
        }

        // GET: api/ReservedRooms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getreserved_rooms([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reserved_rooms = await _context.reserved_rooms.FindAsync(id);

            if (reserved_rooms == null)
            {
                return NotFound();
            }

            return Ok(reserved_rooms);
        }

        // PUT: api/ReservedRooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putreserved_rooms([FromRoute] int id, [FromBody] reserved_rooms reserved_rooms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reserved_rooms.id)
            {
                return BadRequest();
            }

            _context.Entry(reserved_rooms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reserved_roomsExists(id))
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

        // POST: api/ReservedRooms
        [HttpPost]
        public async Task<IActionResult> Postreserved_rooms([FromBody] reserved_rooms reserved_rooms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.reserved_rooms.Add(reserved_rooms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getreserved_rooms", new { id = reserved_rooms.id }, reserved_rooms);
        }

        // DELETE: api/ReservedRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletereserved_rooms([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reserved_rooms = await _context.reserved_rooms.FindAsync(id);
            if (reserved_rooms == null)
            {
                return NotFound();
            }

            _context.reserved_rooms.Remove(reserved_rooms);
            await _context.SaveChangesAsync();

            return Ok(reserved_rooms);
        }

        private bool reserved_roomsExists(int id)
        {
            return _context.reserved_rooms.Any(e => e.id == id);
        }
    }
}