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

        private readonly IDataRepository<Client> dataRepositoryClient;

        private readonly IDataRepository<Telephone> dataRepositoryTelephone;

        public UsersController(IDataRepository<User> dataRepo, IDataRepository<Client> dataRepoClient, IDataRepository<Telephone> dataRepoTelephone)
        {
            dataRepository = dataRepo;
            dataRepositoryClient = dataRepoClient;
            dataRepositoryTelephone = dataRepoTelephone;
        }

        // GET: api/Users
        [HttpGet]
        //[Authorize(Policy = Policies.Type0)] pour limiter l'accès aux utilisateurs avec l'attribut type compte à 0 (en passant par le login controller qui donne le token jwt)
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
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
        public async Task<ActionResult<User>> PostUser([FromBody]UserPostRequest userRequest)
        {
            //créer un client pour l'utiliser dans le user qui est créé après
            var clientResponse = await new ClientsController(dataRepositoryClient).PostClient(new ClientPostRequest
            {
                Civilite = userRequest.Gender,
                NomClient = userRequest.LastName,
                PrenomClient = userRequest.FirstName,
                EmailClient = userRequest.Email,
                DateNaissanceClient = userRequest.BirthDateClient
            });

            var client = ((CreatedAtActionResult)clientResponse.Result).Value as Client;

            //créer un tel pour le client
            var clientResponseTel = await new TelephonesController(dataRepositoryTelephone).PostTelephone(new PhonePostRequest
            {
                IdClient = client.IdClient,
                NumTelephone = userRequest.PhoneNumber
            });

            User user = new User
            {
                Id = GetMaxId().Result.Value + 1,
                FirstName = userRequest.FirstName,
                Email = userRequest.Email,
                Password = userRequest.Password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Civilite = userRequest.Gender,
                LastName = userRequest.LastName,
                IdClient = client.IdClient,
                IsComplete = true,
                TypeCompte = 2,
                DoubleAuth = false,
                LastConnected = DateTime.Now,
                //ClientUsers = new Client()
            };

            await dataRepository.AddAsync(user);



            user.ClientUsers = null; // pour pouvoir renvoyer un json plus petit sinon on reçoit une erreur au lieu du user convertit en json

            return CreatedAtAction("GetUserById", new { id = user.Id }, user);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (user == null)
            {
                return Problem("Entity set 'BMWDBContext.Users'  is null.");
            }
            await dataRepository.AddAsync(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }*/

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
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
        //public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public DateTime BirthDateClient { get; set; }

        public string PhoneNumber { get; set; } = null!;

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }

        //public bool IsComplete { get; set; }

        //public int TypeCompte { get; set; }

        //public bool DoubleAuth { get; set; }

        //public DateTime LastConnected { get; set; }
    }
}
