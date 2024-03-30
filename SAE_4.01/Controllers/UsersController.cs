using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;

namespace SAE_4._01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<User> dataRepository;

        public UsersController(IDataRepository<User> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Users
        [HttpGet]
        //[Authorize(Policy = Policies.Type0)] pour limiter l'accès aux utilisateurs avec l'attribut type compte à 0 (en passant par le login controller qui donne le token jwt)
        public async Task<ActionResult<IEnumerable<User>>> GetLesUsers()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsers(int id)
        {

            var users = await dataRepository.GetByIdAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {

            if (id != user.Id)
            {
                return BadRequest();
            }

            var usrToUpdate = await dataRepository.GetByIdAsync(id);

            if (usrToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(usrToUpdate.Value, user);
                return NoContent();
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUsers(User user)
        {
            if (user == null)
            {
                return Problem("Entity set 'BMWDBContext.Users'  is null.");
            }
            await dataRepository.AddAsync(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            var user = await dataRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(user.Value);

            return NoContent();
        }

        private bool UsersExists(int id)
        {
            return (_context.LesUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
