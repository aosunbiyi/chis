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
    public class RateTypesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public RateTypesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/RateTypes
        [HttpGet]
        public IEnumerable<rate_types> Getrate_types()
        {
            return _context.rate_types;
        }

        // GET: api/RateTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getrate_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rate_types = await _context.rate_types.FindAsync(id);

            if (rate_types == null)
            {
                return NotFound();
            }

            return Ok(rate_types);
        }

        // PUT: api/RateTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrate_types([FromRoute] int id, [FromBody] rate_types rate_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rate_types.id)
            {
                return BadRequest();
            }

            _context.Entry(rate_types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rate_typesExists(id))
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

        // POST: api/RateTypes
        [HttpPost]
        public async Task<IActionResult> Postrate_types([FromBody] rate_types rate_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.rate_types.Add(rate_types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrate_types", new { id = rate_types.id }, rate_types);
        }

        // DELETE: api/RateTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterate_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rate_types = await _context.rate_types.FindAsync(id);
            if (rate_types == null)
            {
                return NotFound();
            }

            _context.rate_types.Remove(rate_types);
            await _context.SaveChangesAsync();

            return Ok(rate_types);
        }

        private bool rate_typesExists(int id)
        {
            return _context.rate_types.Any(e => e.id == id);
        }
    }
}