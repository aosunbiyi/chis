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
    public class RoomStatusColorsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public RoomStatusColorsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/RoomStatusColors
        [HttpGet]
        public IEnumerable<room_status_colors> Getroom_status_colors()
        {
            return _context.room_status_colors;
        }

        // GET: api/RoomStatusColors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getroom_status_colors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room_status_colors = await _context.room_status_colors.FindAsync(id);

            if (room_status_colors == null)
            {
                return NotFound();
            }

            return Ok(room_status_colors);
        }

        // PUT: api/RoomStatusColors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putroom_status_colors([FromRoute] int id, [FromBody] room_status_colors room_status_colors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room_status_colors.id)
            {
                return BadRequest();
            }

            _context.Entry(room_status_colors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!room_status_colorsExists(id))
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

        // POST: api/RoomStatusColors
        [HttpPost]
        public async Task<IActionResult> Postroom_status_colors([FromBody] room_status_colors room_status_colors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.room_status_colors.Add(room_status_colors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getroom_status_colors", new { id = room_status_colors.id }, room_status_colors);
        }

        // DELETE: api/RoomStatusColors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteroom_status_colors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room_status_colors = await _context.room_status_colors.FindAsync(id);
            if (room_status_colors == null)
            {
                return NotFound();
            }

            _context.room_status_colors.Remove(room_status_colors);
            await _context.SaveChangesAsync();

            return Ok(room_status_colors);
        }

        private bool room_status_colorsExists(int id)
        {
            return _context.room_status_colors.Any(e => e.id == id);
        }
    }
}