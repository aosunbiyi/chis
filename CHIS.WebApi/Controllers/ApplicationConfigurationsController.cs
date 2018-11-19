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
    public class ApplicationConfigurationsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public ApplicationConfigurationsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationConfigurations
        [HttpGet]
        public IEnumerable<application_configurations> Getapplication_configurations()
        {
            return _context.application_configurations;
        }

        // GET: api/ApplicationConfigurations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getapplication_configurations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var application_configurations = await _context.application_configurations.FindAsync(id);

            if (application_configurations == null)
            {
                return NotFound();
            }

            return Ok(application_configurations);
        }

        // PUT: api/ApplicationConfigurations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putapplication_configurations([FromRoute] int id, [FromBody] application_configurations application_configurations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != application_configurations.id)
            {
                return BadRequest();
            }

            _context.Entry(application_configurations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!application_configurationsExists(id))
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

        // POST: api/ApplicationConfigurations
        [HttpPost]
        public async Task<IActionResult> Postapplication_configurations([FromBody] application_configurations application_configurations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.application_configurations.Add(application_configurations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getapplication_configurations", new { id = application_configurations.id }, application_configurations);
        }

        // DELETE: api/ApplicationConfigurations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteapplication_configurations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var application_configurations = await _context.application_configurations.FindAsync(id);
            if (application_configurations == null)
            {
                return NotFound();
            }

            _context.application_configurations.Remove(application_configurations);
            await _context.SaveChangesAsync();

            return Ok(application_configurations);
        }

        private bool application_configurationsExists(int id)
        {
            return _context.application_configurations.Any(e => e.id == id);
        }
    }
}