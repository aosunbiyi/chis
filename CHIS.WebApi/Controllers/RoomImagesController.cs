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
    public class RoomImagesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public RoomImagesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/RoomImages
        [HttpGet]
        public IEnumerable<room_images> Getroom_images()
        {
            return _context.room_images;
        }

        // GET: api/RoomImages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getroom_images([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room_images = await _context.room_images.FindAsync(id);

            if (room_images == null)
            {
                return NotFound();
            }

            return Ok(room_images);
        }

        // PUT: api/RoomImages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putroom_images([FromRoute] int id, [FromBody] room_images room_images)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room_images.id)
            {
                return BadRequest();
            }

            _context.Entry(room_images).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!room_imagesExists(id))
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

        // POST: api/RoomImages
        [HttpPost]
        public async Task<IActionResult> Postroom_images([FromBody] room_images room_images)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.room_images.Add(room_images);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getroom_images", new { id = room_images.id }, room_images);
        }

        // DELETE: api/RoomImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteroom_images([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room_images = await _context.room_images.FindAsync(id);
            if (room_images == null)
            {
                return NotFound();
            }

            _context.room_images.Remove(room_images);
            await _context.SaveChangesAsync();

            return Ok(room_images);
        }

        private bool room_imagesExists(int id)
        {
            return _context.room_images.Any(e => e.id == id);
        }
    }
}