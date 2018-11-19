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
    public class TransportationTypesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public TransportationTypesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/TransportationTypes
        [HttpGet]
        public IEnumerable<transportation_types> Gettransportation_types()
        {
            return _context.transportation_types;
        }

        // GET: api/TransportationTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Gettransportation_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transportation_types = await _context.transportation_types.FindAsync(id);

            if (transportation_types == null)
            {
                return NotFound();
            }

            return Ok(transportation_types);
        }

        // PUT: api/TransportationTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttransportation_types([FromRoute] int id, [FromBody] transportation_types transportation_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transportation_types.id)
            {
                return BadRequest();
            }

            _context.Entry(transportation_types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!transportation_typesExists(id))
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

        // POST: api/TransportationTypes
        [HttpPost]
        public async Task<IActionResult> Posttransportation_types([FromBody] transportation_types transportation_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.transportation_types.Add(transportation_types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettransportation_types", new { id = transportation_types.id }, transportation_types);
        }

        // DELETE: api/TransportationTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetransportation_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transportation_types = await _context.transportation_types.FindAsync(id);
            if (transportation_types == null)
            {
                return NotFound();
            }

            _context.transportation_types.Remove(transportation_types);
            await _context.SaveChangesAsync();

            return Ok(transportation_types);
        }

        private bool transportation_typesExists(int id)
        {
            return _context.transportation_types.Any(e => e.id == id);
        }
    }
}