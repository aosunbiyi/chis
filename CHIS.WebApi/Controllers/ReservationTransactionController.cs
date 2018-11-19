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
    public class ReservationTransactionController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public ReservationTransactionController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/ReservationTransaction
        [HttpGet]
        public IEnumerable<reservation_transaction> Getreservation_transaction()
        {
            return _context.reservation_transaction;
        }

        [HttpGet("GetReservationDetailsByReservationId/{id}")]
        public async Task<IActionResult> GetReservationDetailsByReservationId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservations_transactions = _context.reservation_transaction.Where(a => a.reserved_room_id == id).ToListAsync();
            return Ok(reservations_transactions);
        }

        // GET: api/ReservationTransaction/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getreservation_transaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservation_transaction = await _context.reservation_transaction.FindAsync(id);

            if (reservation_transaction == null)
            {
                return NotFound();
            }

            return Ok(reservation_transaction);
        }

        // PUT: api/ReservationTransaction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putreservation_transaction([FromRoute] int id, [FromBody] reservation_transaction reservation_transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservation_transaction.id)
            {
                return BadRequest();
            }

            _context.Entry(reservation_transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reservation_transactionExists(id))
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

        // POST: api/ReservationTransaction
        [HttpPost]
        public async Task<IActionResult> Postreservation_transaction([FromBody] reservation_transaction reservation_transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.reservation_transaction.Add(reservation_transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getreservation_transaction", new { id = reservation_transaction.id }, reservation_transaction);
        }

        // DELETE: api/ReservationTransaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletereservation_transaction([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservation_transaction = await _context.reservation_transaction.FindAsync(id);
            if (reservation_transaction == null)
            {
                return NotFound();
            }

            _context.reservation_transaction.Remove(reservation_transaction);
            await _context.SaveChangesAsync();

            return Ok(reservation_transaction);
        }

        private bool reservation_transactionExists(int id)
        {
            return _context.reservation_transaction.Any(e => e.id == id);
        }
    }
}