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
    public class MasterSetupsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public MasterSetupsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/MasterSetups
        [HttpGet]
        public IEnumerable<mastersetup> Getmastersetup()
        {
            return _context.mastersetup;
        }

        // GET: api/MasterSetups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getmastersetup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mastersetup = await _context.mastersetup.FindAsync(id);

            if (mastersetup == null)
            {
                return NotFound();
            }

            return Ok(mastersetup);
        }

        // PUT: api/MasterSetups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putmastersetup([FromRoute] int id, [FromBody] mastersetup mastersetup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mastersetup.id)
            {
                return BadRequest();
            }

            _context.Entry(mastersetup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mastersetupExists(id))
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

        // POST: api/MasterSetups
        [HttpPost]
        public async Task<IActionResult> Postmastersetup([FromBody] mastersetup mastersetup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.mastersetup.Add(mastersetup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getmastersetup", new { id = mastersetup.id }, mastersetup);
        }

        // DELETE: api/MasterSetups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemastersetup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mastersetup = await _context.mastersetup.FindAsync(id);
            if (mastersetup == null)
            {
                return NotFound();
            }

            _context.mastersetup.Remove(mastersetup);
            await _context.SaveChangesAsync();

            return Ok(mastersetup);
        }

        private bool mastersetupExists(int id)
        {
            return _context.mastersetup.Any(e => e.id == id);
        }
    }
}