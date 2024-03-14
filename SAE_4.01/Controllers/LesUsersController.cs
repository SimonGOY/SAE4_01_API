using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_4._01.Models.EntityFramework;

namespace SAE_4._01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LesUsersController : ControllerBase
    {
        private readonly BMWDBContext _context;

        public LesUsersController(BMWDBContext context)
        {
            _context = context;
        }

        // GET: api/LesUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetLesUsers()
        {
            if (_context.LesUsers == null)
            {
                return NotFound();
            }
            return await _context.LesUsers.ToListAsync();
        }

        // GET: api/LesUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            if (_context.LesUsers == null)
            {
                return NotFound();
            }
            var Users = await _context.LesUsers.FindAsync(id);

            if (Users == null)
            {
                return NotFound();
            }

            return Users;
        }

        // PUT: api/LesUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users Users)
        {
            if (id != Users.Id)
            {
                return BadRequest();
            }

            _context.Entry(Users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/LesUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users Users)
        {
            if (_context.LesUsers == null)
            {
                return Problem("Entity set 'BMWDBContext.LesUsers'  is null.");
            }
            _context.LesUsers.Add(Users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = Users.Id }, Users);
        }

        // DELETE: api/LesUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            if (_context.LesUsers == null)
            {
                return NotFound();
            }
            var Users = await _context.LesUsers.FindAsync(id);
            if (Users == null)
            {
                return NotFound();
            }

            _context.LesUsers.Remove(Users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersExists(int id)
        {
            return (_context.LesUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
