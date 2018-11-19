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
    public class RoomTypesRatesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public RoomTypesRatesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/RoomTypesRates
        [HttpGet]
        public IEnumerable<room_types_rates> Getroom_types_rates()
        {
            return _context.room_types_rates;
        }

        // GET: api/RoomTypesRates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getroom_types_rates([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room_types_rates = await _context.room_types_rates.FindAsync(id);

            if (room_types_rates == null)
            {
                return NotFound();
            }

            return Ok(room_types_rates);
        }

        // PUT: api/RoomTypesRates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putroom_types_rates([FromRoute] int id, [FromBody] room_types_rates room_types_rates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room_types_rates.room_type_id)
            {
                return BadRequest();
            }

            _context.Entry(room_types_rates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!room_types_ratesExists(id))
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

        // POST: api/RoomTypesRates
        [HttpPost]
        public async Task<IActionResult> Postroom_types_rates([FromBody] room_types_rates room_types_rates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.room_types_rates.Add(room_types_rates);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (room_types_ratesExists(room_types_rates.room_type_id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getroom_types_rates", new { id = room_types_rates.room_type_id }, room_types_rates);
        }

        // DELETE: api/RoomTypesRates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteroom_types_rates([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var room_types_rates = await _context.room_types_rates.FindAsync(id);
            if (room_types_rates == null)
            {
                return NotFound();
            }

            _context.room_types_rates.Remove(room_types_rates);
            await _context.SaveChangesAsync();

            return Ok(room_types_rates);
        }

        private bool room_types_ratesExists(int id)
        {
            return _context.room_types_rates.Any(e => e.room_type_id == id);
        }
    }
}