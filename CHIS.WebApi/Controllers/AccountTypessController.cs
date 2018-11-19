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
    public class AccountTypesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public AccountTypesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/AccountTypess
        [HttpGet]
        public IEnumerable<account_types> Getaccount_types()
        {
            return _context.account_types;
        }

        // GET: api/AccountTypess/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getaccount_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account_types = await _context.account_types.FindAsync(id);

            if (account_types == null)
            {
                return NotFound();
            }

            return Ok(account_types);
        }

        // PUT: api/AccountTypess/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putaccount_types([FromRoute] int id, [FromBody] account_types account_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != account_types.id)
            {
                return BadRequest();
            }

            _context.Entry(account_types).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!account_typesExists(id))
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

        // POST: api/AccountTypess
        [HttpPost]
        public async Task<IActionResult> Postaccount_types([FromBody] account_types account_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.account_types.Add(account_types);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getaccount_types", new { id = account_types.id }, account_types);
        }

        // DELETE: api/AccountTypess/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteaccount_types([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account_types = await _context.account_types.FindAsync(id);
            if (account_types == null)
            {
                return NotFound();
            }

            _context.account_types.Remove(account_types);
            await _context.SaveChangesAsync();

            return Ok(account_types);
        }

        private bool account_typesExists(int id)
        {
            return _context.account_types.Any(e => e.id == id);
        }
    }
}