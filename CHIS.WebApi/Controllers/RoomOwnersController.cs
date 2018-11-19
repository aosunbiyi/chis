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
    public class RoomOwnersController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public RoomOwnersController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/RoomOwners
        [HttpGet]
        public IEnumerable<room_owners> Getroom_owners()
        {
            return _context.room_owners;
        }

        // GET: api/RoomOwners/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getroom_owners([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room_owners = await _context.room_owners.FindAsync(id);

            if (room_owners == null)
            {
                return NotFound();
            }

            return Ok(room_owners);
        }

        // PUT: api/RoomOwners/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putroom_owners([FromRoute] int id, [FromBody] room_owners room_owners)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room_owners.id)
            {
                return BadRequest();
            }

            _context.Entry(room_owners).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!room_ownersExists(id))
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

        // POST: api/RoomOwners
        [HttpPost]
        public async Task<IActionResult> Postroom_owners([FromBody] room_owners room_owners)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.room_owners.Add(room_owners);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getroom_owners", new { id = room_owners.id }, room_owners);
        }

        // DELETE: api/RoomOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteroom_owners([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room_owners = await _context.room_owners.FindAsync(id);
            if (room_owners == null)
            {
                return NotFound();
            }

            _context.room_owners.Remove(room_owners);
            await _context.SaveChangesAsync();

            return Ok(room_owners);
        }

        private bool room_ownersExists(int id)
        {
            return _context.room_owners.Any(e => e.id == id);
        }
    }
}