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
    public class PropertyDetailsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public PropertyDetailsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/PropertyDetails
        [HttpGet]
        public IEnumerable<property_details> Getproperty_details()
        {
            return _context.property_details;
        }

        // GET: api/PropertyDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getproperty_details([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var property_details = await _context.property_details.FindAsync(id);

            if (property_details == null)
            {
                return NotFound();
            }

            return Ok(property_details);
        }

        // PUT: api/PropertyDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putproperty_details([FromRoute] int id, [FromBody] property_details property_details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != property_details.id)
            {
                return BadRequest();
            }

            _context.Entry(property_details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!property_detailsExists(id))
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

        // POST: api/PropertyDetails
        [HttpPost]
        public async Task<IActionResult> Postproperty_details([FromBody] property_details property_details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.property_details.Add(property_details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproperty_details", new { id = property_details.id }, property_details);
        }

        // DELETE: api/PropertyDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproperty_details([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var property_details = await _context.property_details.FindAsync(id);
            if (property_details == null)
            {
                return NotFound();
            }

            _context.property_details.Remove(property_details);
            await _context.SaveChangesAsync();

            return Ok(property_details);
        }

        private bool property_detailsExists(int id)
        {
            return _context.property_details.Any(e => e.id == id);
        }
    }
}