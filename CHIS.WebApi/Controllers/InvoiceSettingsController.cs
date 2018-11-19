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
    public class InvoiceSettingsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public InvoiceSettingsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceSettings
        [HttpGet]
        public IEnumerable<invoice_settings> Getinvoice_settings()
        {
            return _context.invoice_settings;
        }

        // GET: api/InvoiceSettings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getinvoice_settings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invoice_settings = await _context.invoice_settings.FindAsync(id);

            if (invoice_settings == null)
            {
                return NotFound();
            }

            return Ok(invoice_settings);
        }

        // PUT: api/InvoiceSettings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putinvoice_settings([FromRoute] int id, [FromBody] invoice_settings invoice_settings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invoice_settings.id)
            {
                return BadRequest();
            }

            _context.Entry(invoice_settings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!invoice_settingsExists(id))
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

        // POST: api/InvoiceSettings
        [HttpPost]
        public async Task<IActionResult> Postinvoice_settings([FromBody] invoice_settings invoice_settings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.invoice_settings.Add(invoice_settings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getinvoice_settings", new { id = invoice_settings.id }, invoice_settings);
        }

        // DELETE: api/InvoiceSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteinvoice_settings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var invoice_settings = await _context.invoice_settings.FindAsync(id);
            if (invoice_settings == null)
            {
                return NotFound();
            }

            _context.invoice_settings.Remove(invoice_settings);
            await _context.SaveChangesAsync();

            return Ok(invoice_settings);
        }

        private bool invoice_settingsExists(int id)
        {
            return _context.invoice_settings.Any(e => e.id == id);
        }
    }
}