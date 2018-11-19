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
    public class SeasonsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public SeasonsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Seasons
        [HttpGet]
        public IEnumerable<seasons> Getseasons()
        {
            return _context.seasons;
        }

        // GET: api/Seasons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getseasons([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seasons = await _context.seasons.FindAsync(id);

            if (seasons == null)
            {
                return NotFound();
            }

            return Ok(seasons);
        }

        // PUT: api/Seasons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putseasons([FromRoute] int id, [FromBody] seasons seasons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seasons.id)
            {
                return BadRequest();
            }

            _context.Entry(seasons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!seasonsExists(id))
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

        // POST: api/Seasons
        [HttpPost]
        public async Task<IActionResult> Postseasons([FromBody] seasons seasons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.seasons.Add(seasons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getseasons", new { id = seasons.id }, seasons);
        }

        // DELETE: api/Seasons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteseasons([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seasons = await _context.seasons.FindAsync(id);
            if (seasons == null)
            {
                return NotFound();
            }

            _context.seasons.Remove(seasons);
            await _context.SaveChangesAsync();

            return Ok(seasons);
        }

        private bool seasonsExists(int id)
        {
            return _context.seasons.Any(e => e.id == id);
        }
    }
}