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
    public class RemarkCategoriesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public RemarkCategoriesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/RemarkCategories
        [HttpGet]
        public IEnumerable<remark_categories> Getremark_categories()
        {
            return _context.remark_categories;
        }

        // GET: api/RemarkCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getremark_categories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var remark_categories = await _context.remark_categories.FindAsync(id);

            if (remark_categories == null)
            {
                return NotFound();
            }

            return Ok(remark_categories);
        }

        // PUT: api/RemarkCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putremark_categories([FromRoute] int id, [FromBody] remark_categories remark_categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != remark_categories.id)
            {
                return BadRequest();
            }

            _context.Entry(remark_categories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!remark_categoriesExists(id))
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

        // POST: api/RemarkCategories
        [HttpPost]
        public async Task<IActionResult> Postremark_categories([FromBody] remark_categories remark_categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.remark_categories.Add(remark_categories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getremark_categories", new { id = remark_categories.id }, remark_categories);
        }

        // DELETE: api/RemarkCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteremark_categories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var remark_categories = await _context.remark_categories.FindAsync(id);
            if (remark_categories == null)
            {
                return NotFound();
            }

            _context.remark_categories.Remove(remark_categories);
            await _context.SaveChangesAsync();

            return Ok(remark_categories);
        }

        private bool remark_categoriesExists(int id)
        {
            return _context.remark_categories.Any(e => e.id == id);
        }
    }
}