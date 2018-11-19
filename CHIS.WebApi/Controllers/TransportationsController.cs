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
    public class TransportationsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public TransportationsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Transportations
        [HttpGet]
        public IEnumerable<transportations> Gettransportations()
        {
            return _context.transportations;
        }

        // GET: api/Transportations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Gettransportations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transportations = await _context.transportations.FindAsync(id);

            if (transportations == null)
            {
                return NotFound();
            }

            return Ok(transportations);
        }

        // PUT: api/Transportations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttransportations([FromRoute] int id, [FromBody] transportations transportations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transportations.id)
            {
                return BadRequest();
            }

            _context.Entry(transportations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!transportationsExists(id))
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

        // POST: api/Transportations
        [HttpPost]
        public async Task<IActionResult> Posttransportations([FromBody] transportations transportations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.transportations.Add(transportations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettransportations", new { id = transportations.id }, transportations);
        }

        // DELETE: api/Transportations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetransportations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transportations = await _context.transportations.FindAsync(id);
            if (transportations == null)
            {
                return NotFound();
            }

            _context.transportations.Remove(transportations);
            await _context.SaveChangesAsync();

            return Ok(transportations);
        }

        private bool transportationsExists(int id)
        {
            return _context.transportations.Any(e => e.id == id);
        }
    }
}