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
    public class BusinessSourcesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public BusinessSourcesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/BusinessSources
        [HttpGet]
        public IEnumerable<business_sources> Getbusiness_sources()
        {
            return _context.business_sources;
        }

        [HttpGet("getByBusinessSourceType/{id}")]
        public async Task<IActionResult> getByBusinessSourceType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var business_sources = await _context.business_sources.Where(a => a.business_source_types_id == id).ToListAsync();
            if (business_sources == null)
                return NotFound();
            return Ok(business_sources);
        }

        // GET: api/BusinessSources/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getbusiness_sources([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var business_sources = await _context.business_sources.FindAsync(id);

            if (business_sources == null)
            {
                return NotFound();
            }

            return Ok(business_sources);
        }

        // PUT: api/BusinessSources/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbusiness_sources([FromRoute] int id, [FromBody] business_sources business_sources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != business_sources.id)
            {
                return BadRequest();
            }

            _context.Entry(business_sources).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!business_sourcesExists(id))
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

        // POST: api/BusinessSources
        [HttpPost]
        public async Task<IActionResult> Postbusiness_sources([FromBody] business_sources business_sources)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.business_sources.Add(business_sources);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbusiness_sources", new { id = business_sources.id }, business_sources);
        }

        // DELETE: api/BusinessSources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletebusiness_sources([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var business_sources = await _context.business_sources.FindAsync(id);
            if (business_sources == null)
            {
                return NotFound();
            }

            _context.business_sources.Remove(business_sources);
            await _context.SaveChangesAsync();

            return Ok(business_sources);
        }

        private bool business_sourcesExists(int id)
        {
            return _context.business_sources.Any(e => e.id == id);
        }
    }
}