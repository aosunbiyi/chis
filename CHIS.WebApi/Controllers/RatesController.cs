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
    public class RatesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public RatesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Rates
        [HttpGet]
        public IEnumerable<rates> Getrates()
        {
            return _context.rates;
        }

        // GET: api/Rates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getrates([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rates = await _context.rates.FindAsync(id);

            if (rates == null)
            {
                return NotFound();
            }

            return Ok(rates);
        }

        // PUT: api/Rates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrates([FromRoute] int id, [FromBody] rates rates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rates.id)
            {
                return BadRequest();
            }

            _context.Entry(rates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ratesExists(id))
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

        // POST: api/Rates
        [HttpPost]
        public async Task<IActionResult> Postrates([FromBody] rates rates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.rates.Add(rates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrates", new { id = rates.id }, rates);
        }

        // DELETE: api/Rates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterates([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rates = await _context.rates.FindAsync(id);
            if (rates == null)
            {
                return NotFound();
            }

            _context.rates.Remove(rates);
            await _context.SaveChangesAsync();

            return Ok(rates);
        }

        private bool ratesExists(int id)
        {
            return _context.rates.Any(e => e.id == id);
        }
    }
}