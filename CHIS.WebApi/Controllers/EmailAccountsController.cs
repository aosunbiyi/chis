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
    public class EmailAccountsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public EmailAccountsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/EmailAccounts
        [HttpGet]
        public IEnumerable<email_accounts> Getemail_accounts()
        {
            return _context.email_accounts;
        }

        // GET: api/EmailAccounts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getemail_accounts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var email_accounts = await _context.email_accounts.FindAsync(id);

            if (email_accounts == null)
            {
                return NotFound();
            }

            return Ok(email_accounts);
        }

        // PUT: api/EmailAccounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putemail_accounts([FromRoute] int id, [FromBody] email_accounts email_accounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != email_accounts.id)
            {
                return BadRequest();
            }

            _context.Entry(email_accounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!email_accountsExists(id))
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

        // POST: api/EmailAccounts
        [HttpPost]
        public async Task<IActionResult> Postemail_accounts([FromBody] email_accounts email_accounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.email_accounts.Add(email_accounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getemail_accounts", new { id = email_accounts.id }, email_accounts);
        }

        // DELETE: api/EmailAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteemail_accounts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var email_accounts = await _context.email_accounts.FindAsync(id);
            if (email_accounts == null)
            {
                return NotFound();
            }

            _context.email_accounts.Remove(email_accounts);
            await _context.SaveChangesAsync();

            return Ok(email_accounts);
        }

        private bool email_accountsExists(int id)
        {
            return _context.email_accounts.Any(e => e.id == id);
        }
    }
}