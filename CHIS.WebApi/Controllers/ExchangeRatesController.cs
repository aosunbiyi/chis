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
    public class ExchangeRatesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public ExchangeRatesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/ExchangeRates
        [HttpGet]
        public IEnumerable<exchange_rates> Getexchange_rates()
        {
            return _context.exchange_rates;
        }

        // GET: api/ExchangeRates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getexchange_rates([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exchange_rates = await _context.exchange_rates.FindAsync(id);

            if (exchange_rates == null)
            {
                return NotFound();
            }

            return Ok(exchange_rates);
        }

        // PUT: api/ExchangeRates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putexchange_rates([FromRoute] int id, [FromBody] exchange_rates exchange_rates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exchange_rates.id)
            {
                return BadRequest();
            }

            _context.Entry(exchange_rates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!exchange_ratesExists(id))
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

        // POST: api/ExchangeRates
        [HttpPost]
        public async Task<IActionResult> Postexchange_rates([FromBody] exchange_rates exchange_rates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.exchange_rates.Add(exchange_rates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getexchange_rates", new { id = exchange_rates.id }, exchange_rates);
        }

        // DELETE: api/ExchangeRates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteexchange_rates([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exchange_rates = await _context.exchange_rates.FindAsync(id);
            if (exchange_rates == null)
            {
                return NotFound();
            }

            _context.exchange_rates.Remove(exchange_rates);
            await _context.SaveChangesAsync();

            return Ok(exchange_rates);
        }

        private bool exchange_ratesExists(int id)
        {
            return _context.exchange_rates.Any(e => e.id == id);
        }
    }
}