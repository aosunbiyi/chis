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
    public class CardTypePrefixesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public CardTypePrefixesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/CardTypePrefixes
        [HttpGet]
        public IEnumerable<card_type_prefixes> Getcard_type_prefixes()
        {
            return _context.card_type_prefixes;
        }

        // GET: api/CardTypePrefixes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getcard_type_prefixes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var card_type_prefixes = await _context.card_type_prefixes.FindAsync(id);

            if (card_type_prefixes == null)
            {
                return NotFound();
            }

            return Ok(card_type_prefixes);
        }

        // PUT: api/CardTypePrefixes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcard_type_prefixes([FromRoute] int id, [FromBody] card_type_prefixes card_type_prefixes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != card_type_prefixes.id)
            {
                return BadRequest();
            }

            _context.Entry(card_type_prefixes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!card_type_prefixesExists(id))
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

        // POST: api/CardTypePrefixes
        [HttpPost]
        public async Task<IActionResult> Postcard_type_prefixes([FromBody] card_type_prefixes card_type_prefixes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.card_type_prefixes.Add(card_type_prefixes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcard_type_prefixes", new { id = card_type_prefixes.id }, card_type_prefixes);
        }

        // DELETE: api/CardTypePrefixes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecard_type_prefixes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var card_type_prefixes = await _context.card_type_prefixes.FindAsync(id);
            if (card_type_prefixes == null)
            {
                return NotFound();
            }

            _context.card_type_prefixes.Remove(card_type_prefixes);
            await _context.SaveChangesAsync();

            return Ok(card_type_prefixes);
        }

        private bool card_type_prefixesExists(int id)
        {
            return _context.card_type_prefixes.Any(e => e.id == id);
        }
    }
}