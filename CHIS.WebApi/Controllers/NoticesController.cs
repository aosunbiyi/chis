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
    public class NoticesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public NoticesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Notices
        [HttpGet]
        public IEnumerable<notices> Getnotices()
        {
            return _context.notices;
        }

        // GET: api/Notices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getnotices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notices = await _context.notices.FindAsync(id);

            if (notices == null)
            {
                return NotFound();
            }

            return Ok(notices);
        }

        // PUT: api/Notices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putnotices([FromRoute] int id, [FromBody] notices notices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notices.id)
            {
                return BadRequest();
            }

            _context.Entry(notices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!noticesExists(id))
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

        // POST: api/Notices
        [HttpPost]
        public async Task<IActionResult> Postnotices([FromBody] notices notices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.notices.Add(notices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getnotices", new { id = notices.id }, notices);
        }

        // DELETE: api/Notices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletenotices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notices = await _context.notices.FindAsync(id);
            if (notices == null)
            {
                return NotFound();
            }

            _context.notices.Remove(notices);
            await _context.SaveChangesAsync();

            return Ok(notices);
        }

        private bool noticesExists(int id)
        {
            return _context.notices.Any(e => e.id == id);
        }
    }
}