using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using MessagePack.Formatters;

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
        [Authorize(Policy = Policies.Type2)] //pour limiter l'accès aux utilisateurs avec l'attribut type compte à 2 (en passant par le login controller qui donne le token jwt)
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<User>> GetUserById(int id)
        {

            var users = await dataRepository.GetByIdAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // GET: api/Users/email/xx@gmail.com
        [HttpGet]
        [Route("email/{email}")]
        //[Authorize(Policy = Policies.Type0)] c'est pour vérifier qu'un compte avec une adresse mail existe
        public async Task<ActionResult<bool>> GetIfUserExistsByEmail(string email)
        {
            var usersActionResult = await dataRepository.GetAllAsync();
            var users = usersActionResult.Value;

            return users.Any(e => e.Email == email);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.Type0)]
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
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<User>> PostUser([FromBody]UserPostRequest userPostRequest)
        {
            if (userPostRequest.Id == null)
            {
                userPostRequest.Id = GetMaxId().Result.Value + 1;
            }

            User user = new User
            {
                Id = (int)userPostRequest.Id,
                FirstName = userPostRequest.FirstName,
                Email = userPostRequest.Email,
                Password = userPostRequest.Password,
                CreatedAt = userPostRequest.CreatedAt,
                UpdatedAt = userPostRequest.UpdatedAt,
                Civilite = userPostRequest.Civilite,
                LastName = userPostRequest.LastName,
                IdClient = userPostRequest.IdClient,
                IsComplete = userPostRequest.IsComplete,
                TypeCompte = userPostRequest.TypeCompte,
                DoubleAuth = userPostRequest.DoubleAuth,
                LastConnected = userPostRequest.LastConnected
                //ClientUsers = new Client()
            };

            /*if (user == null)
            {
                return Problem("Entity set 'BMWDBContext.Users'  is null.");
            }*/

            await dataRepository.AddAsync(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await dataRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(user.Value);

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.LesUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<ActionResult<int>> GetMaxId()
        {
            ActionResult<IEnumerable<User>> actionResult = await dataRepository.GetAllAsync();

            IEnumerable<User> users = actionResult.Value;

            int max = 0;

            foreach (User user in users)
            {
                if (user.Id > max)
                {
                    max = user.Id;
                }
            }

            return max;
        }
    }

    public class UserPostRequest
    {
        public int? Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Civilite { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int IdClient { get; set; }

        public bool IsComplete { get; set; }

        public int TypeCompte { get; set; }

        public bool DoubleAuth { get; set; }

        public DateTime LastConnected { get; set; }
    }
}
