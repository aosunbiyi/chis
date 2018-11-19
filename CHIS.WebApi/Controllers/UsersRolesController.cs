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
    public class UsersRolesController : ControllerBase
    {
        private readonly hotel_dbContext _context;

        public UsersRolesController(hotel_dbContext context)
        {
            _context = context;
        }

        // GET: api/UsersRoles
        [HttpGet]
        public IEnumerable<users_roles> Getusers_roles()
        {
            return _context.users_roles;
        }

        // GET: api/UsersRoles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getusers_roles([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users_roles = await _context.users_roles.FindAsync(id);

            if (users_roles == null)
            {
                return NotFound();
            }

            return Ok(users_roles);
        }

        // PUT: api/UsersRoles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putusers_roles([FromRoute] int id, [FromBody] users_roles users_roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users_roles.user_id)
            {
                return BadRequest();
            }

            _context.Entry(users_roles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!users_rolesExists(id))
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

        // POST: api/UsersRoles
        [HttpPost]
        public async Task<IActionResult> Postusers_roles([FromBody] users_roles users_roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.users_roles.Add(users_roles);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (users_rolesExists(users_roles.user_id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getusers_roles", new { id = users_roles.user_id }, users_roles);
        }

        // DELETE: api/UsersRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteusers_roles([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users_roles = await _context.users_roles.FindAsync(id);
            if (users_roles == null)
            {
                return NotFound();
            }

            _context.users_roles.Remove(users_roles);
            await _context.SaveChangesAsync();

            return Ok(users_roles);
        }

        private bool users_rolesExists(int id)
        {
            return _context.users_roles.Any(e => e.user_id == id);
        }
    }
}