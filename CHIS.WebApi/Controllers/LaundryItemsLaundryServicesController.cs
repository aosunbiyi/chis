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
    public class LaundryItemsLaundryServicesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public LaundryItemsLaundryServicesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/LaundryItemsLaundryServices
        [HttpGet]
        public IEnumerable<laundry_items_laundry_services> Getlaundry_items_laundry_services()
        {
            return _context.laundry_items_laundry_services;
        }

        // GET: api/LaundryItemsLaundryServices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getlaundry_items_laundry_services([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_items_laundry_services = await _context.laundry_items_laundry_services.FindAsync(id);

            if (laundry_items_laundry_services == null)
            {
                return NotFound();
            }

            return Ok(laundry_items_laundry_services);
        }

        // PUT: api/LaundryItemsLaundryServices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putlaundry_items_laundry_services([FromRoute] int id, [FromBody] laundry_items_laundry_services laundry_items_laundry_services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laundry_items_laundry_services.laundry_item_id)
            {
                return BadRequest();
            }

            _context.Entry(laundry_items_laundry_services).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!laundry_items_laundry_servicesExists(id))
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

        // POST: api/LaundryItemsLaundryServices
        [HttpPost]
        public async Task<IActionResult> Postlaundry_items_laundry_services([FromBody] laundry_items_laundry_services laundry_items_laundry_services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.laundry_items_laundry_services.Add(laundry_items_laundry_services);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (laundry_items_laundry_servicesExists(laundry_items_laundry_services.laundry_item_id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getlaundry_items_laundry_services", new { id = laundry_items_laundry_services.laundry_item_id }, laundry_items_laundry_services);
        }

        // DELETE: api/LaundryItemsLaundryServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletelaundry_items_laundry_services([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var laundry_items_laundry_services = await _context.laundry_items_laundry_services.FindAsync(id);
            if (laundry_items_laundry_services == null)
            {
                return NotFound();
            }

            _context.laundry_items_laundry_services.Remove(laundry_items_laundry_services);
            await _context.SaveChangesAsync();

            return Ok(laundry_items_laundry_services);
        }

        private bool laundry_items_laundry_servicesExists(int id)
        {
            return _context.laundry_items_laundry_services.Any(e => e.laundry_item_id == id);
        }
    }
}