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
    public class NonRentalUnitsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public NonRentalUnitsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/NonRentalUnits
        [HttpGet]
        public IEnumerable<non_rental_units> Getnon_rental_units()
        {
            return _context.non_rental_units;
        }

        // GET: api/NonRentalUnits/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getnon_rental_units([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var non_rental_units = await _context.non_rental_units.FindAsync(id);

            if (non_rental_units == null)
            {
                return NotFound();
            }

            return Ok(non_rental_units);
        }

        // PUT: api/NonRentalUnits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putnon_rental_units([FromRoute] int id, [FromBody] non_rental_units non_rental_units)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != non_rental_units.id)
            {
                return BadRequest();
            }

            _context.Entry(non_rental_units).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!non_rental_unitsExists(id))
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

        // POST: api/NonRentalUnits
        [HttpPost]
        public async Task<IActionResult> Postnon_rental_units([FromBody] non_rental_units non_rental_units)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.non_rental_units.Add(non_rental_units);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getnon_rental_units", new { id = non_rental_units.id }, non_rental_units);
        }

        // DELETE: api/NonRentalUnits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletenon_rental_units([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var non_rental_units = await _context.non_rental_units.FindAsync(id);
            if (non_rental_units == null)
            {
                return NotFound();
            }

            _context.non_rental_units.Remove(non_rental_units);
            await _context.SaveChangesAsync();

            return Ok(non_rental_units);
        }

        private bool non_rental_unitsExists(int id)
        {
            return _context.non_rental_units.Any(e => e.id == id);
        }
    }
}