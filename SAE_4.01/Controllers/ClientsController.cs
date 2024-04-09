using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using SAE_4._01.Models.DataManager;

namespace SAE_4._01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Client> dataRepository;

        public ClientsController(IDataRepository<Client> dataRepo)
        {
            dataRepository = dataRepo;
            //_clientService = clientService;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {

            var client = await dataRepository.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<Client>> PostClient([FromBody] Client clientRequest)
        {
            int? nextId = null;

            if (clientRequest.IdClient == null)
            {
                nextId = GetMaxId().Result.Value + 1;
            }
            else
                nextId = (int)clientRequest.IdClient;

            Client client = new Client
            {
                IdClient = nextId,
                NumAdresse = 1,
                Civilite = clientRequest.Civilite,
                NomClient = clientRequest.NomClient,
                PrenomClient = clientRequest.PrenomClient,
                DateNaissanceClient = clientRequest.DateNaissanceClient,
                EmailClient = clientRequest.EmailClient
            };


            //...J'ai mal aux yeux
            ActionResult<IEnumerable<Client>> actionResult;
            if (dataRepository == null)
            {
                var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
                BMWDBContext context = new BMWDBContext(builder.Options);
                IDataRepository<Client> dataRepository = new ClientManager(context);

                await dataRepository.AddAsync(client);
            }
            else
            {
                await dataRepository.AddAsync(client);
            }

            return CreatedAtAction("GetClient", new { id = client.IdClient }, client);
        }*/

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(ClientPostRequest clientPostRequest)
        {
            if (clientPostRequest.IdClient == null)
            {
                clientPostRequest.IdClient = GetMaxId().Result.Value + 1;
            }

            Client client = new Client
            {
                IdClient = (int)clientPostRequest.IdClient,
                NumAdresse = clientPostRequest.NumAdresse,
                Civilite = clientPostRequest.Civilite,
                NomClient = clientPostRequest.NomClient,
                PrenomClient = clientPostRequest.PrenomClient,
                DateNaissanceClient = clientPostRequest.DateNaissanceClient,
                EmailClient = clientPostRequest.EmailClient
                //AdresseClient = new Adresse()
            };

            /*if (client == null)
            {
                return Problem("Entity set 'BMWDBContext.Clients'  is null.");
            }*/

            await dataRepository.AddAsync(client);

            return CreatedAtAction("GetClient", new { id = client.IdClient }, client);


        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {

            if (id != client.IdClient)
            {
                return BadRequest();
            }

            var cltToUpdate = await dataRepository.GetByIdAsync(id);

            if (cltToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(cltToUpdate.Value, client);
                return NoContent();
            }
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await dataRepository.GetByIdAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(client.Value);

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return (_context.Clients?.Any(e => e.IdClient == id)).GetValueOrDefault();
        }

        private async Task<ActionResult<int>> GetMaxId()
        {
            //...J'ai mal aux yeux
            ActionResult<IEnumerable<Client>> actionResult;
            if (dataRepository == null)
            {
                var builder = new DbContextOptionsBuilder<BMWDBContext>().UseNpgsql("Server=51.83.36.122; port=5432; Database=sa11; uid=sa11; password=BMW-S4; SearchPath=bmw;");
                BMWDBContext context = new BMWDBContext(builder.Options);
                IDataRepository<Client> dataRepository = new ClientManager(context);
                ClientsController controller = new ClientsController(dataRepository);
                actionResult = controller.GetClients().Result;
            }
            else
            {
                ClientsController controller = new ClientsController(dataRepository);
                actionResult = controller.GetClients().Result;
            }
            

            IEnumerable<Client> clients = actionResult.Value;

            int max = 0;

            foreach (Client client in clients)
            {
                if (client.IdClient > max)
                {
                    max = (int)client.IdClient;
                }
            }

            return max;
        }
    }

    public class ClientPostRequest
    {
        public int? IdClient { get; set; }

        public int NumAdresse { get; set; }

        public string Civilite { get; set; } = null!;

        public string NomClient { get; set; } = null!;

        public string PrenomClient { get; set; } = null!;

        public DateTime DateNaissanceClient { get; set; }

        public string EmailClient { get; set; } = null!;
    }
}
