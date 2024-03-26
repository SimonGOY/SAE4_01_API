using System;
using System.Collections.Generic;
using System.Drawing;
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
    public class CommandesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Commande> dataRepository;

        public CommandesController(IDataRepository<Commande> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Commandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommandes()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Commandes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commande>> GetCommande(int id)
        {

            var commande = await dataRepository.GetByIdAsync(id);

            if (commande == null)
            {
                return NotFound();
            }

            return commande;
        }

        // PUT: api/Commandes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommande(int id, Commande commande)
        {
            if (id != commande.IdCommande)
            {
                return BadRequest();
            }

            var cmdToUpdate = await dataRepository.GetByIdAsync(id);

            if (cmdToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(cmdToUpdate.Value, commande);
                return NoContent();
            }
        }

        // POST: api/Commandes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Commande>> PostCommande(Commande commande)
        {
            if (commande == null)
            {
                return Problem("Entity set 'BMWDBContext.Commandes'  is null.");
            }
            await dataRepository.AddAsync(commande);

            return CreatedAtAction("GetCommande", new { id = commande.IdCommande }, commande);
        }

        // DELETE: api/Commandes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommande(int id)
        {
            var commande = await dataRepository.GetByIdAsync(id);

            if (commande == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(commande.Value);

            return NoContent();
        }

        private bool CommandeExists(int id)
        {
            return (_context.Commandes?.Any(e => e.IdCommande == id)).GetValueOrDefault();
        }
    }
}
