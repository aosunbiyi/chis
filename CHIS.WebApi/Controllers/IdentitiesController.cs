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
    public class IdentitiesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public IdentitiesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Identities
        [HttpGet]
        public IEnumerable<identities> Getidentities()
        {
            return _context.identities;
        }

        // GET: api/Identities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getidentities([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identities = await _context.identities.FindAsync(id);

            if (identities == null)
            {
                return NotFound();
            }

            return Ok(identities);
        }

        // PUT: api/Identities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putidentities([FromRoute] int id, [FromBody] identities identities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != identities.id)
            {
                return BadRequest();
            }

            _context.Entry(identities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!identitiesExists(id))
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

        // POST: api/Identities
        [HttpPost]
        public async Task<IActionResult> Postidentities([FromBody] identities identities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.identities.Add(identities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getidentities", new { id = identities.id }, identities);
        }

        // DELETE: api/Identities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteidentities([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identities = await _context.identities.FindAsync(id);
            if (identities == null)
            {
                return NotFound();
            }

            _context.identities.Remove(identities);
            await _context.SaveChangesAsync();

            return Ok(identities);
        }

        private bool identitiesExists(int id)
        {
            return _context.identities.Any(e => e.id == id);
        }
    }
}