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
    public class ArrivalDepartureInfosController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public ArrivalDepartureInfosController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/ArrivalDepartureInfos
        [HttpGet]
        public IEnumerable<arrival_departure_infos> Getarrival_departure_infos()
        {
            return _context.arrival_departure_infos;
        }

        // GET: api/ArrivalDepartureInfos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getarrival_departure_infos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var arrival_departure_infos = await _context.arrival_departure_infos.FindAsync(id);

            if (arrival_departure_infos == null)
            {
                return NotFound();
            }

            return Ok(arrival_departure_infos);
        }

        // PUT: api/ArrivalDepartureInfos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putarrival_departure_infos([FromRoute] int id, [FromBody] arrival_departure_infos arrival_departure_infos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != arrival_departure_infos.id)
            {
                return BadRequest();
            }

            _context.Entry(arrival_departure_infos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!arrival_departure_infosExists(id))
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

        // POST: api/ArrivalDepartureInfos
        [HttpPost]
        public async Task<IActionResult> Postarrival_departure_infos([FromBody] arrival_departure_infos arrival_departure_infos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.arrival_departure_infos.Add(arrival_departure_infos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getarrival_departure_infos", new { id = arrival_departure_infos.id }, arrival_departure_infos);
        }

        // DELETE: api/ArrivalDepartureInfos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletearrival_departure_infos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var arrival_departure_infos = await _context.arrival_departure_infos.FindAsync(id);
            if (arrival_departure_infos == null)
            {
                return NotFound();
            }

            _context.arrival_departure_infos.Remove(arrival_departure_infos);
            await _context.SaveChangesAsync();

            return Ok(arrival_departure_infos);
        }

        private bool arrival_departure_infosExists(int id)
        {
            return _context.arrival_departure_infos.Any(e => e.id == id);
        }
    }
}