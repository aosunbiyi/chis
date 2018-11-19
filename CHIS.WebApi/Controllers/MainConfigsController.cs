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
    public class MainConfigsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public MainConfigsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/MainConfigs
        [HttpGet]
        public IEnumerable<mainconfig> Getmainconfig()
        {
            return _context.mainconfig;
        }

        // GET: api/MainConfigs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getmainconfig([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mainconfig = await _context.mainconfig.FindAsync(id);

            if (mainconfig == null)
            {
                return NotFound();
            }

            return Ok(mainconfig);
        }

        // PUT: api/MainConfigs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmainconfig([FromRoute] int id, [FromBody] mainconfig mainconfig)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mainconfig.id)
            {
                return BadRequest();
            }

            _context.Entry(mainconfig).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mainconfigExists(id))
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

        // POST: api/MainConfigs
        [HttpPost]
        public async Task<IActionResult> Postmainconfig([FromBody] mainconfig mainconfig)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.mainconfig.Add(mainconfig);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmainconfig", new { id = mainconfig.id }, mainconfig);
        }

        // DELETE: api/MainConfigs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemainconfig([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mainconfig = await _context.mainconfig.FindAsync(id);
            if (mainconfig == null)
            {
                return NotFound();
            }

            _context.mainconfig.Remove(mainconfig);
            await _context.SaveChangesAsync();

            return Ok(mainconfig);
        }

        private bool mainconfigExists(int id)
        {
            return _context.mainconfig.Any(e => e.id == id);
        }
    }
}