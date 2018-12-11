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
    public class LaundryPackagingTypesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public LaundryPackagingTypesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/LaundryPackagingTypes
        [HttpGet]
        public IEnumerable<laundry_packaging_types> Getlaundry_packaging_types()
        {
            return _context.laundry_packaging_types;
        }

        // GET: api/LaundryPackagingTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getlaundry_packaging_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_packaging_types = await _context.laundry_packaging_types.FindAsync(id);

            if (laundry_packaging_types == null)
            {
                return NotFound();
            }

            return Ok(laundry_packaging_types);
        }

        // PUT: api/LaundryPackagingTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlaundry_packaging_types([FromRoute] int id, [FromBody] laundry_packaging_types laundry_packaging_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laundry_packaging_types.id)
            {
                return BadRequest();
            }

            _context.Entry(laundry_packaging_types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!laundry_packaging_typesExists(id))
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

        // POST: api/LaundryPackagingTypes
        [HttpPost]
        public async Task<IActionResult> Postlaundry_packaging_types([FromBody] laundry_packaging_types laundry_packaging_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.laundry_packaging_types.Add(laundry_packaging_types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlaundry_packaging_types", new { id = laundry_packaging_types.id }, laundry_packaging_types);
        }

        // DELETE: api/LaundryPackagingTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelaundry_packaging_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_packaging_types = await _context.laundry_packaging_types.FindAsync(id);
            if (laundry_packaging_types == null)
            {
                return NotFound();
            }

            _context.laundry_packaging_types.Remove(laundry_packaging_types);
            await _context.SaveChangesAsync();

            return Ok(laundry_packaging_types);
        }

        private bool laundry_packaging_typesExists(int id)
        {
            return _context.laundry_packaging_types.Any(e => e.id == id);
        }
    }
}