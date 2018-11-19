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
    public class TaxSettingTypesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public TaxSettingTypesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/TaxSettingTypes
        [HttpGet]
        public IEnumerable<tax_setting_types> Gettax_setting_types()
        {
            return _context.tax_setting_types;
        }

        // GET: api/TaxSettingTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Gettax_setting_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tax_setting_types = await _context.tax_setting_types.FindAsync(id);

            if (tax_setting_types == null)
            {
                return NotFound();
            }

            return Ok(tax_setting_types);
        }

        // PUT: api/TaxSettingTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttax_setting_types([FromRoute] int id, [FromBody] tax_setting_types tax_setting_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tax_setting_types.id)
            {
                return BadRequest();
            }

            _context.Entry(tax_setting_types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tax_setting_typesExists(id))
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

        // POST: api/TaxSettingTypes
        [HttpPost]
        public async Task<IActionResult> Posttax_setting_types([FromBody] tax_setting_types tax_setting_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tax_setting_types.Add(tax_setting_types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettax_setting_types", new { id = tax_setting_types.id }, tax_setting_types);
        }

        // DELETE: api/TaxSettingTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetax_setting_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tax_setting_types = await _context.tax_setting_types.FindAsync(id);
            if (tax_setting_types == null)
            {
                return NotFound();
            }

            _context.tax_setting_types.Remove(tax_setting_types);
            await _context.SaveChangesAsync();

            return Ok(tax_setting_types);
        }

        private bool tax_setting_typesExists(int id)
        {
            return _context.tax_setting_types.Any(e => e.id == id);
        }
    }
}