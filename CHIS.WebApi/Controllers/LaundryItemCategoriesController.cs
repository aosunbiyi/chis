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
    public class LaundryItemCategoriesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public LaundryItemCategoriesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/LaundryItemCategories
        [HttpGet]
        public IEnumerable<laundry_item_categories> Getlaundry_item_categories()
        {
            return _context.laundry_item_categories;
        }

        // GET: api/LaundryItemCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getlaundry_item_categories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_item_categories = await _context.laundry_item_categories.FindAsync(id);

            if (laundry_item_categories == null)
            {
                return NotFound();
            }

            return Ok(laundry_item_categories);
        }

        // PUT: api/LaundryItemCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlaundry_item_categories([FromRoute] int id, [FromBody] laundry_item_categories laundry_item_categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laundry_item_categories.id)
            {
                return BadRequest();
            }

            _context.Entry(laundry_item_categories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!laundry_item_categoriesExists(id))
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

        // POST: api/LaundryItemCategories
        [HttpPost]
        public async Task<IActionResult> Postlaundry_item_categories([FromBody] laundry_item_categories laundry_item_categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.laundry_item_categories.Add(laundry_item_categories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlaundry_item_categories", new { id = laundry_item_categories.id }, laundry_item_categories);
        }

        // DELETE: api/LaundryItemCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelaundry_item_categories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_item_categories = await _context.laundry_item_categories.FindAsync(id);
            if (laundry_item_categories == null)
            {
                return NotFound();
            }

            _context.laundry_item_categories.Remove(laundry_item_categories);
            await _context.SaveChangesAsync();

            return Ok(laundry_item_categories);
        }

        private bool laundry_item_categoriesExists(int id)
        {
            return _context.laundry_item_categories.Any(e => e.id == id);
        }
    }
}