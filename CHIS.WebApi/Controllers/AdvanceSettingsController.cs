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
    public class AdvanceSettingsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public AdvanceSettingsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/AdvanceSettings
        [HttpGet]
        public IEnumerable<advancesetting> Getadvancesetting()
        {
            return _context.advancesetting;
        }

        // GET: api/AdvanceSettings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getadvancesetting([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var advancesetting = await _context.advancesetting.FindAsync(id);

            if (advancesetting == null)
            {
                return NotFound();
            }

            return Ok(advancesetting);
        }

        // PUT: api/AdvanceSettings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putadvancesetting([FromRoute] int id, [FromBody] advancesetting advancesetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != advancesetting.id)
            {
                return BadRequest();
            }

            _context.Entry(advancesetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!advancesettingExists(id))
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

        // POST: api/AdvanceSettings
        [HttpPost]
        public async Task<IActionResult> Postadvancesetting([FromBody] advancesetting advancesetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.advancesetting.Add(advancesetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getadvancesetting", new { id = advancesetting.id }, advancesetting);
        }

        // DELETE: api/AdvanceSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteadvancesetting([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var advancesetting = await _context.advancesetting.FindAsync(id);
            if (advancesetting == null)
            {
                return NotFound();
            }

            _context.advancesetting.Remove(advancesetting);
            await _context.SaveChangesAsync();

            return Ok(advancesetting);
        }

        private bool advancesettingExists(int id)
        {
            return _context.advancesetting.Any(e => e.id == id);
        }
    }
}