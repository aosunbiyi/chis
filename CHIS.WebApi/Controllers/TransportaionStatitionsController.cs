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
    public class TransportaionStatitionsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public TransportaionStatitionsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/TransportaionStatitions
        [HttpGet]
        public IEnumerable<transportaion_statitions> Gettransportaion_statitions()
        {
            return _context.transportaion_statitions;
        }

        // GET: api/TransportaionStatitions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Gettransportaion_statitions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transportaion_statitions = await _context.transportaion_statitions.FindAsync(id);

            if (transportaion_statitions == null)
            {
                return NotFound();
            }

            return Ok(transportaion_statitions);
        }

        // PUT: api/TransportaionStatitions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttransportaion_statitions([FromRoute] int id, [FromBody] transportaion_statitions transportaion_statitions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transportaion_statitions.id)
            {
                return BadRequest();
            }

            _context.Entry(transportaion_statitions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!transportaion_statitionsExists(id))
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

        // POST: api/TransportaionStatitions
        [HttpPost]
        public async Task<IActionResult> Posttransportaion_statitions([FromBody] transportaion_statitions transportaion_statitions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.transportaion_statitions.Add(transportaion_statitions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettransportaion_statitions", new { id = transportaion_statitions.id }, transportaion_statitions);
        }

        // DELETE: api/TransportaionStatitions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetransportaion_statitions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transportaion_statitions = await _context.transportaion_statitions.FindAsync(id);
            if (transportaion_statitions == null)
            {
                return NotFound();
            }

            _context.transportaion_statitions.Remove(transportaion_statitions);
            await _context.SaveChangesAsync();

            return Ok(transportaion_statitions);
        }

        private bool transportaion_statitionsExists(int id)
        {
            return _context.transportaion_statitions.Any(e => e.id == id);
        }
    }
}