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
    public class RemarksController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public RemarksController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Remarks
        [HttpGet]
        public IEnumerable<remarks> Getremarks()
        {
            return _context.remarks;
        }

        // GET: api/Remarks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getremarks([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var remarks = await _context.remarks.FindAsync(id);

            if (remarks == null)
            {
                return NotFound();
            }

            return Ok(remarks);
        }

        // PUT: api/Remarks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putremarks([FromRoute] int id, [FromBody] remarks remarks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != remarks.id)
            {
                return BadRequest();
            }

            _context.Entry(remarks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!remarksExists(id))
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

        // POST: api/Remarks
        [HttpPost]
        public async Task<IActionResult> Postremarks([FromBody] remarks remarks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.remarks.Add(remarks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getremarks", new { id = remarks.id }, remarks);
        }

        // DELETE: api/Remarks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteremarks([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var remarks = await _context.remarks.FindAsync(id);
            if (remarks == null)
            {
                return NotFound();
            }

            _context.remarks.Remove(remarks);
            await _context.SaveChangesAsync();

            return Ok(remarks);
        }

        private bool remarksExists(int id)
        {
            return _context.remarks.Any(e => e.id == id);
        }
    }
}