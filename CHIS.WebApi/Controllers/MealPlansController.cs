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
    public class MealPlansController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public MealPlansController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/MealPlans
        [HttpGet]
        public IEnumerable<meal_plans> Getmeal_plans()
        {
            return _context.meal_plans;
        }

        // GET: api/MealPlans/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getmeal_plans([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var meal_plans = await _context.meal_plans.FindAsync(id);

            if (meal_plans == null)
            {
                return NotFound();
            }

            return Ok(meal_plans);
        }

        // PUT: api/MealPlans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmeal_plans([FromRoute] int id, [FromBody] meal_plans meal_plans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meal_plans.id)
            {
                return BadRequest();
            }

            _context.Entry(meal_plans).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!meal_plansExists(id))
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

        // POST: api/MealPlans
        [HttpPost]
        public async Task<IActionResult> Postmeal_plans([FromBody] meal_plans meal_plans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.meal_plans.Add(meal_plans);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmeal_plans", new { id = meal_plans.id }, meal_plans);
        }

        // DELETE: api/MealPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemeal_plans([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var meal_plans = await _context.meal_plans.FindAsync(id);
            if (meal_plans == null)
            {
                return NotFound();
            }

            _context.meal_plans.Remove(meal_plans);
            await _context.SaveChangesAsync();

            return Ok(meal_plans);
        }

        private bool meal_plansExists(int id)
        {
            return _context.meal_plans.Any(e => e.id == id);
        }
    }
}