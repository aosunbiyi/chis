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
    public class LaundryServicesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public LaundryServicesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/LaundryServices
        [HttpGet]
        public IEnumerable<laundry_services> Getlaundry_services()
        {
            return _context.laundry_services.Include(a=>a.laundry_items_laundry_services);
        }

        [HttpPost("getLaundryItems")]
        public async Task<IActionResult> getLaundryItems([FromBody] LData1 data )
        {
            var items = _context.laundry_items_laundry_services.Where(a => a.laundry_service_id == data.id).ToListAsync();

            return Ok(items);
        }

        // GET: api/LaundryServices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getlaundry_services([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_services = await _context.laundry_services.FindAsync(id);

            if (laundry_services == null)
            {
                return NotFound();
            }

            return Ok(laundry_services);
        }

        // PUT: api/LaundryServices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlaundry_services([FromRoute] int id, [FromBody] laundry_services laundry_services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laundry_services.id)
            {
                return BadRequest();
            }

            _context.Entry(laundry_services).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!laundry_servicesExists(id))
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

        // POST: api/LaundryServices
        [HttpPost]
        public async Task<IActionResult> Postlaundry_services([FromBody] laundry_services laundry_services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.laundry_services.Add(laundry_services);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getlaundry_services", new { id = laundry_services.id }, laundry_services);
        }

        // DELETE: api/LaundryServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelaundry_services([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_services = await _context.laundry_services.FindAsync(id);
            if (laundry_services == null)
            {
                return NotFound();
            }

            _context.laundry_services.Remove(laundry_services);
            await _context.SaveChangesAsync();

            return Ok(laundry_services);
        }

        private bool laundry_servicesExists(int id)
        {
            return _context.laundry_services.Any(e => e.id == id);
        }
    }
}

public class LData1
{
    public int id { get; set; }
}