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
    public class LaundryGuestLaundryTransactionItemsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public LaundryGuestLaundryTransactionItemsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/LaundryGuestLaundryTransactionItems
        [HttpGet]
        public IEnumerable<laundry_guest_laundry_transaction_items> Getlaundry_guest_laundry_transaction_items()
        {
            return _context.laundry_guest_laundry_transaction_items;
        }

        // GET: api/LaundryGuestLaundryTransactionItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getlaundry_guest_laundry_transaction_items([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_guest_laundry_transaction_items = await _context.laundry_guest_laundry_transaction_items.FindAsync(id);

            if (laundry_guest_laundry_transaction_items == null)
            {
                return NotFound();
            }

            return Ok(laundry_guest_laundry_transaction_items);
        }

        // PUT: api/LaundryGuestLaundryTransactionItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlaundry_guest_laundry_transaction_items([FromRoute] int id, [FromBody] laundry_guest_laundry_transaction_items laundry_guest_laundry_transaction_items)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laundry_guest_laundry_transaction_items.id)
            {
                return BadRequest();
            }

            _context.Entry(laundry_guest_laundry_transaction_items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!laundry_guest_laundry_transaction_itemsExists(id))
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

        // POST: api/LaundryGuestLaundryTransactionItems
        [HttpPost]
        public async Task<IActionResult> Postlaundry_guest_laundry_transaction_items([FromBody] laundry_guest_laundry_transaction_items laundry_guest_laundry_transaction_items)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.laundry_guest_laundry_transaction_items.Add(laundry_guest_laundry_transaction_items);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlaundry_guest_laundry_transaction_items", new { id = laundry_guest_laundry_transaction_items.id }, laundry_guest_laundry_transaction_items);
        }

        // DELETE: api/LaundryGuestLaundryTransactionItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelaundry_guest_laundry_transaction_items([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_guest_laundry_transaction_items = await _context.laundry_guest_laundry_transaction_items.FindAsync(id);
            if (laundry_guest_laundry_transaction_items == null)
            {
                return NotFound();
            }

            _context.laundry_guest_laundry_transaction_items.Remove(laundry_guest_laundry_transaction_items);
            await _context.SaveChangesAsync();

            return Ok(laundry_guest_laundry_transaction_items);
        }

        private bool laundry_guest_laundry_transaction_itemsExists(int id)
        {
            return _context.laundry_guest_laundry_transaction_items.Any(e => e.id == id);
        }
    }
}