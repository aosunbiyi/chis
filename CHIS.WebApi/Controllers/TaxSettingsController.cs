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
    public class TaxSettingsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public TaxSettingsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/TaxSettings
        [HttpGet]
        public IEnumerable<tax_settings> Gettax_settings()
        {
            return _context.tax_settings;
        }

        // GET: api/TaxSettings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Gettax_settings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tax_settings = await _context.tax_settings.FindAsync(id);

            if (tax_settings == null)
            {
                return NotFound();
            }

            return Ok(tax_settings);
        }

        // PUT: api/TaxSettings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttax_settings([FromRoute] int id, [FromBody] tax_settings tax_settings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tax_settings.id)
            {
                return BadRequest();
            }

            _context.Entry(tax_settings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tax_settingsExists(id))
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

        // POST: api/TaxSettings
        [HttpPost]
        public async Task<IActionResult> Posttax_settings([FromBody] tax_settings tax_settings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tax_settings.Add(tax_settings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettax_settings", new { id = tax_settings.id }, tax_settings);
        }

        // DELETE: api/TaxSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetax_settings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tax_settings = await _context.tax_settings.FindAsync(id);
            if (tax_settings == null)
            {
                return NotFound();
            }

            _context.tax_settings.Remove(tax_settings);
            await _context.SaveChangesAsync();

            return Ok(tax_settings);
        }

        private bool tax_settingsExists(int id)
        {
            return _context.tax_settings.Any(e => e.id == id);
        }
    }
}