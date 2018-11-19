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
    public class AccountsController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public AccountsController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public IEnumerable<accounts> Getaccounts()
        {
            return _context.accounts;
        }
        
        [HttpGet("getAccountByPhone/{phone}")]
        public async Task<IActionResult> getAccountByPhone([FromRoute]string phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await _context.accounts.Where(a=>a.phone.Equals(phone)).FirstOrDefaultAsync();

            if (account == null)
            {
                return NotFound();
            }


            return Ok(account);
        }


        [HttpGet("getAccountByEmail/{email}")]
        public async Task<IActionResult> getAccountByEmail([FromRoute]string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await _context.accounts.Where(a => a.email.Equals(email)).FirstOrDefaultAsync();

            if (account == null)
            {
                return NotFound();
            }


            return Ok(account);
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getaccounts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accounts = await _context.accounts.FindAsync(id);

            if (accounts == null)
            {
                return NotFound();
            }

            return Ok(accounts);
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putaccounts([FromRoute] int id, [FromBody] accounts accounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accounts.id)
            {
                return BadRequest();
            }

            _context.Entry(accounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!accountsExists(id))
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

        // POST: api/Accounts
        [HttpPost]
        public async Task<IActionResult> Postaccounts([FromBody] accounts accounts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.accounts.Add(accounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getaccounts", new { id = accounts.id }, accounts);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteaccounts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accounts = await _context.accounts.FindAsync(id);
            if (accounts == null)
            {
                return NotFound();
            }

            _context.accounts.Remove(accounts);
            await _context.SaveChangesAsync();

            return Ok(accounts);
        }

        private bool accountsExists(int id)
        {
            return _context.accounts.Any(e => e.id == id);
        }
    }
}