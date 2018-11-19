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
    public class RevenueBreakdownsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public RevenueBreakdownsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/RevenueBreakdowns
        [HttpGet]
        public IEnumerable<revenue_breakdowns> Getrevenue_breakdowns()
        {
            return _context.revenue_breakdowns;
        }

        // GET: api/RevenueBreakdowns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getrevenue_breakdowns([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var revenue_breakdowns = await _context.revenue_breakdowns.FindAsync(id);

            if (revenue_breakdowns == null)
            {
                return NotFound();
            }

            return Ok(revenue_breakdowns);
        }

        // PUT: api/RevenueBreakdowns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putrevenue_breakdowns([FromRoute] int id, [FromBody] revenue_breakdowns revenue_breakdowns)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != revenue_breakdowns.id)
            {
                return BadRequest();
            }

            _context.Entry(revenue_breakdowns).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!revenue_breakdownsExists(id))
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

        // POST: api/RevenueBreakdowns
        [HttpPost]
        public async Task<IActionResult> Postrevenue_breakdowns([FromBody] revenue_breakdowns revenue_breakdowns)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.revenue_breakdowns.Add(revenue_breakdowns);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrevenue_breakdowns", new { id = revenue_breakdowns.id }, revenue_breakdowns);
        }

        // DELETE: api/RevenueBreakdowns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterevenue_breakdowns([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var revenue_breakdowns = await _context.revenue_breakdowns.FindAsync(id);
            if (revenue_breakdowns == null)
            {
                return NotFound();
            }

            _context.revenue_breakdowns.Remove(revenue_breakdowns);
            await _context.SaveChangesAsync();

            return Ok(revenue_breakdowns);
        }

        private bool revenue_breakdownsExists(int id)
        {
            return _context.revenue_breakdowns.Any(e => e.id == id);
        }
    }
}