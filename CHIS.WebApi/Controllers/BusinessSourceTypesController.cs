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
    public class BusinessSourceTypesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public BusinessSourceTypesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/BusinessSourceTypes
        [HttpGet]
        public IEnumerable<business_source_types> Getbusiness_source_types()
        {
            return _context.business_source_types;
        }

        // GET: api/BusinessSourceTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getbusiness_source_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var business_source_types = await _context.business_source_types.FindAsync(id);

            if (business_source_types == null)
            {
                return NotFound();
            }

            return Ok(business_source_types);
        }

        // PUT: api/BusinessSourceTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putbusiness_source_types([FromRoute] int id, [FromBody] business_source_types business_source_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != business_source_types.id)
            {
                return BadRequest();
            }

            _context.Entry(business_source_types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!business_source_typesExists(id))
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

        // POST: api/BusinessSourceTypes
        [HttpPost]
        public async Task<IActionResult> Postbusiness_source_types([FromBody] business_source_types business_source_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.business_source_types.Add(business_source_types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getbusiness_source_types", new { id = business_source_types.id }, business_source_types);
        }

        // DELETE: api/BusinessSourceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletebusiness_source_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var business_source_types = await _context.business_source_types.FindAsync(id);
            if (business_source_types == null)
            {
                return NotFound();
            }

            _context.business_source_types.Remove(business_source_types);
            await _context.SaveChangesAsync();

            return Ok(business_source_types);
        }

        private bool business_source_typesExists(int id)
        {
            return _context.business_source_types.Any(e => e.id == id);
        }
    }
}