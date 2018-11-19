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
    public class WingsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public WingsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Wings
        [HttpGet]
        public IEnumerable<wings> Getwings()
        {
            return _context.wings;
        }

        // GET: api/Wings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getwings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wings = await _context.wings.FindAsync(id);

            if (wings == null)
            {
                return NotFound();
            }

            return Ok(wings);
        }

        // PUT: api/Wings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putwings([FromRoute] int id, [FromBody] wings wings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wings.id)
            {
                return BadRequest();
            }

            _context.Entry(wings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!wingsExists(id))
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

        // POST: api/Wings
        [HttpPost]
        public async Task<IActionResult> Postwings([FromBody] wings wings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.wings.Add(wings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getwings", new { id = wings.id }, wings);
        }

        // DELETE: api/Wings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletewings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wings = await _context.wings.FindAsync(id);
            if (wings == null)
            {
                return NotFound();
            }

            _context.wings.Remove(wings);
            await _context.SaveChangesAsync();

            return Ok(wings);
        }

        private bool wingsExists(int id)
        {
            return _context.wings.Any(e => e.id == id);
        }
    }
}