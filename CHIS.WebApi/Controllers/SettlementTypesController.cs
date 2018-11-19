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
    public class SettlementTypesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public SettlementTypesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/SettlementTypes
        [HttpGet]
        public IEnumerable<settlement_types> Getsettlement_types()
        {
            return _context.settlement_types;
        }

        // GET: api/SettlementTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getsettlement_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var settlement_types = await _context.settlement_types.FindAsync(id);

            if (settlement_types == null)
            {
                return NotFound();
            }

            return Ok(settlement_types);
        }

        // PUT: api/SettlementTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putsettlement_types([FromRoute] int id, [FromBody] settlement_types settlement_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != settlement_types.id)
            {
                return BadRequest();
            }

            _context.Entry(settlement_types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!settlement_typesExists(id))
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

        // POST: api/SettlementTypes
        [HttpPost]
        public async Task<IActionResult> Postsettlement_types([FromBody] settlement_types settlement_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.settlement_types.Add(settlement_types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getsettlement_types", new { id = settlement_types.id }, settlement_types);
        }

        // DELETE: api/SettlementTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletesettlement_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var settlement_types = await _context.settlement_types.FindAsync(id);
            if (settlement_types == null)
            {
                return NotFound();
            }

            _context.settlement_types.Remove(settlement_types);
            await _context.SaveChangesAsync();

            return Ok(settlement_types);
        }

        private bool settlement_typesExists(int id)
        {
            return _context.settlement_types.Any(e => e.id == id);
        }
    }
}