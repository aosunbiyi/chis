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
    public class FollowUpTypesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public FollowUpTypesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/FollowUpTypes
        [HttpGet]
        public IEnumerable<follow_up_types> Getfollow_up_types()
        {
            return _context.follow_up_types;
        }

        // GET: api/FollowUpTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getfollow_up_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var follow_up_types = await _context.follow_up_types.FindAsync(id);

            if (follow_up_types == null)
            {
                return NotFound();
            }

            return Ok(follow_up_types);
        }

        // PUT: api/FollowUpTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfollow_up_types([FromRoute] int id, [FromBody] follow_up_types follow_up_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != follow_up_types.id)
            {
                return BadRequest();
            }

            _context.Entry(follow_up_types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!follow_up_typesExists(id))
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

        // POST: api/FollowUpTypes
        [HttpPost]
        public async Task<IActionResult> Postfollow_up_types([FromBody] follow_up_types follow_up_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.follow_up_types.Add(follow_up_types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfollow_up_types", new { id = follow_up_types.id }, follow_up_types);
        }

        // DELETE: api/FollowUpTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletefollow_up_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var follow_up_types = await _context.follow_up_types.FindAsync(id);
            if (follow_up_types == null)
            {
                return NotFound();
            }

            _context.follow_up_types.Remove(follow_up_types);
            await _context.SaveChangesAsync();

            return Ok(follow_up_types);
        }

        private bool follow_up_typesExists(int id)
        {
            return _context.follow_up_types.Any(e => e.id == id);
        }
    }
}