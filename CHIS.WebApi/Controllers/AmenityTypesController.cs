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
    public class AmenityTypesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public AmenityTypesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/AmenityTypes
        [HttpGet]
        public IEnumerable<amenity_types> Getamenity_types()
        {
            return _context.amenity_types;
        }

        // GET: api/AmenityTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getamenity_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var amenity_types = await _context.amenity_types.FindAsync(id);

            if (amenity_types == null)
            {
                return NotFound();
            }

            return Ok(amenity_types);
        }

        // PUT: api/AmenityTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putamenity_types([FromRoute] int id, [FromBody] amenity_types amenity_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != amenity_types.id)
            {
                return BadRequest();
            }

            _context.Entry(amenity_types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!amenity_typesExists(id))
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

        // POST: api/AmenityTypes
        [HttpPost]
        public async Task<IActionResult> Postamenity_types([FromBody] amenity_types amenity_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.amenity_types.Add(amenity_types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getamenity_types", new { id = amenity_types.id }, amenity_types);
        }

        // DELETE: api/AmenityTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteamenity_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var amenity_types = await _context.amenity_types.FindAsync(id);
            if (amenity_types == null)
            {
                return NotFound();
            }

            _context.amenity_types.Remove(amenity_types);
            await _context.SaveChangesAsync();

            return Ok(amenity_types);
        }

        private bool amenity_typesExists(int id)
        {
            return _context.amenity_types.Any(e => e.id == id);
        }
    }
}