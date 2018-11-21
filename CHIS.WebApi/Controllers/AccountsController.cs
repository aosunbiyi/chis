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
            return _context.accounts.Include(a=>a.account_type_).Include(a=>a.hotel_representative_)
                .Include(a=>a.reservations).OrderByDescending(a=>a.id);
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
        public async Task<IActionResult> Putaccounts([FromRoute] int id, [FromBody] accountModel ac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != int.Parse(ac.id))
            {
                return BadRequest();
            }

            var accounts = _context.accounts.Where(a => a.id == id).SingleOrDefault();
            accounts.account_type_id = int.Parse(ac.account_type_id);
            accounts.address1 = ac.address1;
            accounts.address2 = ac.address2;          
            accounts.city = ac.city;
            accounts.country = ac.country;          
            
            accounts.credit_limit = decimal.Parse(ac.credit_limit);
            accounts.email = ac.email;
            accounts.fax = ac.fax;
            accounts.first_name = ac.first_name;
            accounts.group_name = ac.group_name;
            accounts.hotel_representative_id = int.Parse(ac.hotel_representative_id);
            accounts.last_name = ac.last_name;
            accounts.modified = DateTime.Now;           
            accounts.phone = ac.phone;
            accounts.postal_code = ac.postal_code;            
            accounts.remark = ac.remark;
            accounts.state = ac.state;

            _context.SaveChanges();


            return  Ok(accounts);
        }

        // POST: api/Accounts
        [HttpPost]
        public async Task<IActionResult> Postaccounts([FromBody] accountModel ac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accounts = new accounts();
            accounts.account_number= CHIS.Core.Infrastructure.AccountGenerator.Generate(10);
            accounts.account_type_id = int.Parse(ac.account_type_id);
            accounts.address1 = ac.address1;
            accounts.address2 = ac.address2;
            accounts.alias = "";
            accounts.card_holder = "";
            accounts.card_number = "";
            accounts.city = ac.city;
            accounts.country = ac.country;
            accounts.created = DateTime.Now;
            accounts.created_by = "";
            accounts.created_on = DateTime.Now;
            accounts.credit_card_type = "";
            accounts.credit_limit = decimal.Parse(ac.credit_limit);
            accounts.email = ac.email;
            accounts.exp_date = DateTime.Now;
            accounts.fax = ac.fax;
            accounts.first_name = ac.first_name;
            accounts.group_name = ac.group_name;
            accounts.hotel_representative_id = int.Parse(ac.hotel_representative_id);
            accounts.last_name = ac.last_name;
            accounts.modified = DateTime.Now;
            accounts.opening_balance = 0M;
            accounts.payment_term = 0M;
            accounts.phone = ac.phone;
            accounts.postal_code = ac.postal_code;
            accounts.reg_number = "";
            accounts.reg_number1 = "";
            accounts.reg_number2 = "";
            accounts.remark = ac.remark;
            accounts.state = ac.state;
            

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

    public class accountModel
    {
        public string id { get; set; }
        public string account_type_id { get; set; }
        public string hotel_representative_id { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string credit_limit { get; set; }
        public string group_name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string remark { get; set; }
    }
}