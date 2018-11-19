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
    public class PropertySetupsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public PropertySetupsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/PropertySetups
        [HttpGet]
        public IEnumerable<propertysetup> Getpropertysetup()
        {
            return _context.propertysetup;
        }

        // GET: api/PropertySetups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getpropertysetup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var propertysetup = await _context.propertysetup.FindAsync(id);

            if (propertysetup == null)
            {
                return NotFound();
            }

            return Ok(propertysetup);
        }

        // PUT: api/PropertySetups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpropertysetup([FromRoute] int id, [FromBody] propertysetup propertysetup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != propertysetup.id)
            {
                return BadRequest();
            }

            _context.Entry(propertysetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!propertysetupExists(id))
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

        // POST: api/PropertySetups
        [HttpPost]
        public async Task<IActionResult> Postpropertysetup([FromBody] propertysetup propertysetup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.propertysetup.Add(propertysetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpropertysetup", new { id = propertysetup.id }, propertysetup);
        }

        // DELETE: api/PropertySetups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepropertysetup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var propertysetup = await _context.propertysetup.FindAsync(id);
            if (propertysetup == null)
            {
                return NotFound();
            }

            _context.propertysetup.Remove(propertysetup);
            await _context.SaveChangesAsync();

            return Ok(propertysetup);
        }

        private bool propertysetupExists(int id)
        {
            return _context.propertysetup.Any(e => e.id == id);
        }
    }
}