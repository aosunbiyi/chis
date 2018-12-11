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
    public class LaundryGuestLaundryTransactionsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public LaundryGuestLaundryTransactionsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/LaundryGuestLaundryTransactions
        [HttpGet]
        public IEnumerable<laundry_guest_laundry_transactions> Getlaundry_guest_laundry_transactions()
        {
            return _context.laundry_guest_laundry_transactions;
        }

        // GET: api/LaundryGuestLaundryTransactions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getlaundry_guest_laundry_transactions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_guest_laundry_transactions = await _context.laundry_guest_laundry_transactions.FindAsync(id);

            if (laundry_guest_laundry_transactions == null)
            {
                return NotFound();
            }

            return Ok(laundry_guest_laundry_transactions);
        }

        // PUT: api/LaundryGuestLaundryTransactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlaundry_guest_laundry_transactions([FromRoute] int id, [FromBody] laundry_guest_laundry_transactions laundry_guest_laundry_transactions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laundry_guest_laundry_transactions.id)
            {
                return BadRequest();
            }

            _context.Entry(laundry_guest_laundry_transactions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!laundry_guest_laundry_transactionsExists(id))
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

        // POST: api/LaundryGuestLaundryTransactions
        [HttpPost]
        public async Task<IActionResult> Postlaundry_guest_laundry_transactions([FromBody] laundry_guest_laundry_transactions laundry_guest_laundry_transactions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.laundry_guest_laundry_transactions.Add(laundry_guest_laundry_transactions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlaundry_guest_laundry_transactions", new { id = laundry_guest_laundry_transactions.id }, laundry_guest_laundry_transactions);
        }

        // DELETE: api/LaundryGuestLaundryTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelaundry_guest_laundry_transactions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_guest_laundry_transactions = await _context.laundry_guest_laundry_transactions.FindAsync(id);
            if (laundry_guest_laundry_transactions == null)
            {
                return NotFound();
            }

            _context.laundry_guest_laundry_transactions.Remove(laundry_guest_laundry_transactions);
            await _context.SaveChangesAsync();

            return Ok(laundry_guest_laundry_transactions);
        }

        private bool laundry_guest_laundry_transactionsExists(int id)
        {
            return _context.laundry_guest_laundry_transactions.Any(e => e.id == id);
        }
    }
}