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
    public class ExtraChargeCategoriesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public ExtraChargeCategoriesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/ExtraChargeCategories
        [HttpGet]
        public IEnumerable<extra_charge_categories> Getextra_charge_categories()
        {
            return _context.extra_charge_categories;
        }

        // GET: api/ExtraChargeCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getextra_charge_categories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extra_charge_categories = await _context.extra_charge_categories.FindAsync(id);

            if (extra_charge_categories == null)
            {
                return NotFound();
            }

            return Ok(extra_charge_categories);
        }

        // PUT: api/ExtraChargeCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putextra_charge_categories([FromRoute] int id, [FromBody] extra_charge_categories extra_charge_categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != extra_charge_categories.id)
            {
                return BadRequest();
            }

            _context.Entry(extra_charge_categories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!extra_charge_categoriesExists(id))
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

        // POST: api/ExtraChargeCategories
        [HttpPost]
        public async Task<IActionResult> Postextra_charge_categories([FromBody] extra_charge_categories extra_charge_categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.extra_charge_categories.Add(extra_charge_categories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getextra_charge_categories", new { id = extra_charge_categories.id }, extra_charge_categories);
        }

        // DELETE: api/ExtraChargeCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteextra_charge_categories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extra_charge_categories = await _context.extra_charge_categories.FindAsync(id);
            if (extra_charge_categories == null)
            {
                return NotFound();
            }

            _context.extra_charge_categories.Remove(extra_charge_categories);
            await _context.SaveChangesAsync();

            return Ok(extra_charge_categories);
        }

        private bool extra_charge_categoriesExists(int id)
        {
            return _context.extra_charge_categories.Any(e => e.id == id);
        }
    }
}