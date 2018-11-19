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
    public class SeasonTypesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public SeasonTypesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/SeasonTypes
        [HttpGet]
        public IEnumerable<season_types> Getseason_types()
        {
            return _context.season_types;
        }

        // GET: api/SeasonTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getseason_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var season_types = await _context.season_types.FindAsync(id);

            if (season_types == null)
            {
                return NotFound();
            }

            return Ok(season_types);
        }

        // PUT: api/SeasonTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putseason_types([FromRoute] int id, [FromBody] season_types season_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != season_types.id)
            {
                return BadRequest();
            }

            _context.Entry(season_types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!season_typesExists(id))
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

        // POST: api/SeasonTypes
        [HttpPost]
        public async Task<IActionResult> Postseason_types([FromBody] season_types season_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.season_types.Add(season_types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getseason_types", new { id = season_types.id }, season_types);
        }

        // DELETE: api/SeasonTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteseason_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var season_types = await _context.season_types.FindAsync(id);
            if (season_types == null)
            {
                return NotFound();
            }

            _context.season_types.Remove(season_types);
            await _context.SaveChangesAsync();

            return Ok(season_types);
        }

        private bool season_typesExists(int id)
        {
            return _context.season_types.Any(e => e.id == id);
        }
    }
}