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
    public class RoomsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public RoomsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public IEnumerable<rooms> Getrooms()
        {
            return _context.rooms;
        }

        [HttpGet("getRoomsByRoomTypeId/{id}")]
        public async Task<IActionResult> getRoomsByRoomTypeId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rooms = await _context.rooms.Where(a => a.room_type_id == id).Include(a => a.room_images).Include(a => a.reserved_rooms).ToListAsync();
        
            if (rooms == null)
                return NotFound();
            return Ok(rooms);

        }

        [HttpGet("getRoomsByFloorId/{id}")]
        public async Task<IActionResult> getRoomsByFloorId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rooms = await _context.rooms.Where(a => a.floor_id == id).Include(a => a.room_images).Include(a => a.reserved_rooms).ToListAsync();

            if (rooms == null)
                return NotFound();
            return Ok(rooms);

        }



        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getrooms([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rooms = await _context.rooms.FindAsync(id);

            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);
        }


   



        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrooms([FromRoute] int id, [FromBody] rooms rooms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rooms.id)
            {
                return BadRequest();
            }

            _context.Entry(rooms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roomsExists(id))
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

        // POST: api/Rooms
        [HttpPost]
        public async Task<IActionResult> Postrooms([FromBody] rooms rooms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.rooms.Add(rooms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrooms", new { id = rooms.id }, rooms);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterooms([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rooms = await _context.rooms.FindAsync(id);
            if (rooms == null)
            {
                return NotFound();
            }

            _context.rooms.Remove(rooms);
            await _context.SaveChangesAsync();

            return Ok(rooms);
        }

        private bool roomsExists(int id)
        {
            return _context.rooms.Any(e => e.id == id);
        }
    }
}