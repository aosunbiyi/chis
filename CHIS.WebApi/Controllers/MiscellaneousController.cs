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
    public class MiscellaneousController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public MiscellaneousController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Miscellaneous
        [HttpGet]
        public IEnumerable<miscellaneous> Getmiscellaneous()
        {
            return _context.miscellaneous;
        }

        // GET: api/Miscellaneous/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getmiscellaneous([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var miscellaneous = await _context.miscellaneous.FindAsync(id);

            if (miscellaneous == null)
            {
                return NotFound();
            }

            return Ok(miscellaneous);
        }

        // PUT: api/Miscellaneous/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmiscellaneous([FromRoute] int id, [FromBody] miscellaneous miscellaneous)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != miscellaneous.id)
            {
                return BadRequest();
            }

            _context.Entry(miscellaneous).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!miscellaneousExists(id))
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

        // POST: api/Miscellaneous
        [HttpPost]
        public async Task<IActionResult> Postmiscellaneous([FromBody] miscellaneous miscellaneous)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.miscellaneous.Add(miscellaneous);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmiscellaneous", new { id = miscellaneous.id }, miscellaneous);
        }

        // DELETE: api/Miscellaneous/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemiscellaneous([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var miscellaneous = await _context.miscellaneous.FindAsync(id);
            if (miscellaneous == null)
            {
                return NotFound();
            }

            _context.miscellaneous.Remove(miscellaneous);
            await _context.SaveChangesAsync();

            return Ok(miscellaneous);
        }

        private bool miscellaneousExists(int id)
        {
            return _context.miscellaneous.Any(e => e.id == id);
        }
    }
}