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
    public class LaundryHotelServicesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public LaundryHotelServicesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/LaundryHotelServices
        [HttpGet]
        public IEnumerable<laundry_hotel_services> Getlaundry_hotel_services()
        {
            return _context.laundry_hotel_services;
        }

        // GET: api/LaundryHotelServices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getlaundry_hotel_services([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_hotel_services = await _context.laundry_hotel_services.FindAsync(id);

            if (laundry_hotel_services == null)
            {
                return NotFound();
            }

            return Ok(laundry_hotel_services);
        }

        // PUT: api/LaundryHotelServices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlaundry_hotel_services([FromRoute] int id, [FromBody] laundry_hotel_services laundry_hotel_services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laundry_hotel_services.id)
            {
                return BadRequest();
            }

            _context.Entry(laundry_hotel_services).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!laundry_hotel_servicesExists(id))
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

        // POST: api/LaundryHotelServices
        [HttpPost]
        public async Task<IActionResult> Postlaundry_hotel_services([FromBody] laundry_hotel_services laundry_hotel_services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.laundry_hotel_services.Add(laundry_hotel_services);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlaundry_hotel_services", new { id = laundry_hotel_services.id }, laundry_hotel_services);
        }

        // DELETE: api/LaundryHotelServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelaundry_hotel_services([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_hotel_services = await _context.laundry_hotel_services.FindAsync(id);
            if (laundry_hotel_services == null)
            {
                return NotFound();
            }

            _context.laundry_hotel_services.Remove(laundry_hotel_services);
            await _context.SaveChangesAsync();

            return Ok(laundry_hotel_services);
        }

        private bool laundry_hotel_servicesExists(int id)
        {
            return _context.laundry_hotel_services.Any(e => e.id == id);
        }
    }
}