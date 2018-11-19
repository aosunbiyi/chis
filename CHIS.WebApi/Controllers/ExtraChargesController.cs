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
    public class ExtraChargesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public ExtraChargesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/ExtraCharges
        [HttpGet]
        public IEnumerable<extra_charges> Getextra_charges()
        {
            return _context.extra_charges;
        }

        // GET: api/ExtraCharges/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getextra_charges([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extra_charges = await _context.extra_charges.FindAsync(id);

            if (extra_charges == null)
            {
                return NotFound();
            }

            return Ok(extra_charges);
        }

        // PUT: api/ExtraCharges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putextra_charges([FromRoute] int id, [FromBody] extra_charges extra_charges)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != extra_charges.id)
            {
                return BadRequest();
            }

            _context.Entry(extra_charges).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!extra_chargesExists(id))
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

        // POST: api/ExtraCharges
        [HttpPost]
        public async Task<IActionResult> Postextra_charges([FromBody] extra_charges extra_charges)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.extra_charges.Add(extra_charges);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getextra_charges", new { id = extra_charges.id }, extra_charges);
        }

        // DELETE: api/ExtraCharges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteextra_charges([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extra_charges = await _context.extra_charges.FindAsync(id);
            if (extra_charges == null)
            {
                return NotFound();
            }

            _context.extra_charges.Remove(extra_charges);
            await _context.SaveChangesAsync();

            return Ok(extra_charges);
        }

        private bool extra_chargesExists(int id)
        {
            return _context.extra_charges.Any(e => e.id == id);
        }
    }
}