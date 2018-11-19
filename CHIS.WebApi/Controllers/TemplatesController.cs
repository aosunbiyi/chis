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
    public class TemplatesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public TemplatesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Templates
        [HttpGet]
        public IEnumerable<templates> Gettemplates()
        {
            return _context.templates;
        }

        // GET: api/Templates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Gettemplates([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var templates = await _context.templates.FindAsync(id);

            if (templates == null)
            {
                return NotFound();
            }

            return Ok(templates);
        }

        // PUT: api/Templates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttemplates([FromRoute] int id, [FromBody] templates templates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != templates.id)
            {
                return BadRequest();
            }

            _context.Entry(templates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!templatesExists(id))
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

        // POST: api/Templates
        [HttpPost]
        public async Task<IActionResult> Posttemplates([FromBody] templates templates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.templates.Add(templates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettemplates", new { id = templates.id }, templates);
        }

        // DELETE: api/Templates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetemplates([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var templates = await _context.templates.FindAsync(id);
            if (templates == null)
            {
                return NotFound();
            }

            _context.templates.Remove(templates);
            await _context.SaveChangesAsync();

            return Ok(templates);
        }

        private bool templatesExists(int id)
        {
            return _context.templates.Any(e => e.id == id);
        }
    }
}