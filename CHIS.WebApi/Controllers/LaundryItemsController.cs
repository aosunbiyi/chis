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
    public class LaundryItemsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public LaundryItemsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/LaundryItems
        [HttpGet]
        public IEnumerable<laundry_items> Getlaundry_items()
        {
            return _context.laundry_items;
        }

        // GET: api/LaundryItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getlaundry_items([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_items = await _context.laundry_items.FindAsync(id);

            if (laundry_items == null)
            {
                return NotFound();
            }

            return Ok(laundry_items);
        }

        // PUT: api/LaundryItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlaundry_items([FromRoute] int id, [FromBody] laundry_items laundry_items)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laundry_items.id)
            {
                return BadRequest();
            }

            _context.Entry(laundry_items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!laundry_itemsExists(id))
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

        // POST: api/LaundryItems
        [HttpPost]
        public async Task<IActionResult> Postlaundry_items([FromBody] laundry_items laundry_items)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.laundry_items.Add(laundry_items);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlaundry_items", new { id = laundry_items.id }, laundry_items);
        }

        // DELETE: api/LaundryItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelaundry_items([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_items = await _context.laundry_items.FindAsync(id);
            if (laundry_items == null)
            {
                return NotFound();
            }

            _context.laundry_items.Remove(laundry_items);
            await _context.SaveChangesAsync();

            return Ok(laundry_items);
        }

        private bool laundry_itemsExists(int id)
        {
            return _context.laundry_items.Any(e => e.id == id);
        }
    }
}