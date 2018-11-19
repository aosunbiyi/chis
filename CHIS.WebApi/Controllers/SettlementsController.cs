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
    public class SettlementsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public SettlementsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Settlements
        [HttpGet]
        public IEnumerable<settlements> Getsettlements()
        {
            return _context.settlements;
        }

        // GET: api/Settlements/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getsettlements([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var settlements = await _context.settlements.FindAsync(id);

            if (settlements == null)
            {
                return NotFound();
            }

            return Ok(settlements);
        }

        // PUT: api/Settlements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putsettlements([FromRoute] int id, [FromBody] settlements settlements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != settlements.id)
            {
                return BadRequest();
            }

            _context.Entry(settlements).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!settlementsExists(id))
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

        // POST: api/Settlements
        [HttpPost]
        public async Task<IActionResult> Postsettlements([FromBody] settlements settlements)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.settlements.Add(settlements);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getsettlements", new { id = settlements.id }, settlements);
        }

        // DELETE: api/Settlements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletesettlements([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var settlements = await _context.settlements.FindAsync(id);
            if (settlements == null)
            {
                return NotFound();
            }

            _context.settlements.Remove(settlements);
            await _context.SaveChangesAsync();

            return Ok(settlements);
        }

        private bool settlementsExists(int id)
        {
            return _context.settlements.Any(e => e.id == id);
        }
    }
}