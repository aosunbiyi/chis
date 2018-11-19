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
    public class PaymentMethodsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public PaymentMethodsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentMethods
        [HttpGet]
        public IEnumerable<payment_methods> Getpayment_methods()
        {
            return _context.payment_methods;
        }

        // GET: api/PaymentMethods/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getpayment_methods([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payment_methods = await _context.payment_methods.FindAsync(id);

            if (payment_methods == null)
            {
                return NotFound();
            }

            return Ok(payment_methods);
        }

        // PUT: api/PaymentMethods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpayment_methods([FromRoute] int id, [FromBody] payment_methods payment_methods)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payment_methods.id)
            {
                return BadRequest();
            }

            _context.Entry(payment_methods).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!payment_methodsExists(id))
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

        // POST: api/PaymentMethods
        [HttpPost]
        public async Task<IActionResult> Postpayment_methods([FromBody] payment_methods payment_methods)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.payment_methods.Add(payment_methods);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpayment_methods", new { id = payment_methods.id }, payment_methods);
        }

        // DELETE: api/PaymentMethods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepayment_methods([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payment_methods = await _context.payment_methods.FindAsync(id);
            if (payment_methods == null)
            {
                return NotFound();
            }

            _context.payment_methods.Remove(payment_methods);
            await _context.SaveChangesAsync();

            return Ok(payment_methods);
        }

        private bool payment_methodsExists(int id)
        {
            return _context.payment_methods.Any(e => e.id == id);
        }
    }
}