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
    public class TaxesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public TaxesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Taxes
        [HttpGet]
        public IEnumerable<taxes> Gettaxes()
        {
            return _context.taxes;
        }

        // GET: api/Taxes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Gettaxes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taxes = await _context.taxes.FindAsync(id);

            if (taxes == null)
            {
                return NotFound();
            }

            return Ok(taxes);
        }

        // PUT: api/Taxes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttaxes([FromRoute] int id, [FromBody] taxes taxes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taxes.id)
            {
                return BadRequest();
            }

            _context.Entry(taxes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!taxesExists(id))
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

        // POST: api/Taxes
        [HttpPost]
        public async Task<IActionResult> Posttaxes([FromBody] taxes taxes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.taxes.Add(taxes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettaxes", new { id = taxes.id }, taxes);
        }

        // DELETE: api/Taxes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetaxes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taxes = await _context.taxes.FindAsync(id);
            if (taxes == null)
            {
                return NotFound();
            }

            _context.taxes.Remove(taxes);
            await _context.SaveChangesAsync();

            return Ok(taxes);
        }

        private bool taxesExists(int id)
        {
            return _context.taxes.Any(e => e.id == id);
        }
    }
}