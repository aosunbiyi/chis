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
    public class DiscountPlansController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public DiscountPlansController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/DiscountPlans
        [HttpGet]
        public IEnumerable<discount_plans> Getdiscount_plans()
        {
            return _context.discount_plans;
        }

        // GET: api/DiscountPlans/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getdiscount_plans([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var discount_plans = await _context.discount_plans.FindAsync(id);

            if (discount_plans == null)
            {
                return NotFound();
            }

            return Ok(discount_plans);
        }

        // PUT: api/DiscountPlans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putdiscount_plans([FromRoute] int id, [FromBody] discount_plans discount_plans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != discount_plans.id)
            {
                return BadRequest();
            }

            _context.Entry(discount_plans).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!discount_plansExists(id))
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

        // POST: api/DiscountPlans
        [HttpPost]
        public async Task<IActionResult> Postdiscount_plans([FromBody] discount_plans discount_plans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.discount_plans.Add(discount_plans);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdiscount_plans", new { id = discount_plans.id }, discount_plans);
        }

        // DELETE: api/DiscountPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletediscount_plans([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var discount_plans = await _context.discount_plans.FindAsync(id);
            if (discount_plans == null)
            {
                return NotFound();
            }

            _context.discount_plans.Remove(discount_plans);
            await _context.SaveChangesAsync();

            return Ok(discount_plans);
        }

        private bool discount_plansExists(int id)
        {
            return _context.discount_plans.Any(e => e.id == id);
        }
    }
}