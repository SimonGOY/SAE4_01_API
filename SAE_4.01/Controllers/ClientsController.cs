using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;

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
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            if (client == null)
            {
                return Problem("Entity set 'BMWDBContext.Clients'  is null.");
            }
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
    }
}
