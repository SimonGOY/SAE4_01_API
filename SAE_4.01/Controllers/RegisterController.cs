using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using BCrypt.Net;

namespace SAE_4._01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IConfiguration _config;

        private readonly IDataRepository<Adresse> dataRepositoryAdresse;

        private readonly IDataRepository<Pays> dataRepositoryPays;

        private readonly IDataRepository<User> dataRepositoryUser;

        private readonly IDataRepository<Client> dataRepositoryClient;

        private readonly IDataRepository<Telephone> dataRepositoryTelephone;

        public RegisterController(IConfiguration config, IDataRepository<Adresse> dataRepoAdresse, IDataRepository<Pays> dataRepoPays, IDataRepository<User> dataRepoUser, IDataRepository<Client> dataRepoClient, IDataRepository<Telephone> dataRepoTelephone)
        {
            _config = config;
            this.dataRepositoryAdresse = dataRepoAdresse;
            this.dataRepositoryPays = dataRepoPays;
            this.dataRepositoryUser = dataRepoUser;
            this.dataRepositoryClient = dataRepoClient;
            this.dataRepositoryTelephone = dataRepoTelephone;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            //créer adresse
            var payss = await dataRepositoryPays.GetAllAsync();

            var adresseResponse = await new AdressesController(dataRepositoryAdresse).PostAdresse(new AdressePostRequest
            {
                NomPays = "France",
                AdresseAdresse = "Adresse par défaut",
                PaysAdresse = payss.Value.SingleOrDefault(p => p.NomPays == "France")
            });

            var adresse = ((CreatedAtActionResult)adresseResponse.Result).Value as Adresse;

            //créer client
            var clientResponse = await new ClientsController(dataRepositoryClient).PostClient(new ClientPostRequest
            {
                NumAdresse = 100,
                Civilite = registerRequest.Gender,
                NomClient = registerRequest.LastName,
                PrenomClient = registerRequest.FirstName,
                DateNaissanceClient = registerRequest.BirthDateClient,
                EmailClient = registerRequest.Email
            });

            var client = ((CreatedAtActionResult)clientResponse.Result).Value as Client;

            //créer tel
            var telephoneResponse = await new TelephonesController(dataRepositoryTelephone).PostTelephone(new TelephonePostRequest
            {
                IdClient = (int)client.IdClient,
                NumTelephone = registerRequest.PhoneNumber,
                Type = "Mobile",
                Fonction = "Privé"
            });

            var telephone = ((CreatedAtActionResult)telephoneResponse.Result).Value as Telephone;

            //créer user
            var userResponse = await new UsersController(dataRepositoryUser).PostUser(new UserPostRequest
            {
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Civilite = registerRequest.Gender,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IdClient = (int)client.IdClient,
                IsComplete = false,
                TypeCompte = 0,
                DoubleAuth = false,
                LastConnected = DateTime.Now
            });

            var user = ((CreatedAtActionResult)userResponse.Result).Value as User;

            user.ClientUsers = null;

            var response = Ok(new
            {
                userDetails = user,
            });

            return response;
        }
    }

    public class RegisterRequest
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public DateTime BirthDateClient { get; set; }

        public string PhoneNumber { get; set; } = null!;
    }
}
