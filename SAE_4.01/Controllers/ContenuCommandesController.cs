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
    public class ContenuCommandesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<ContenuCommande> dataRepository;

        public ContenuCommandesController(IDataRepository<ContenuCommande> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/ContenuCommandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContenuCommande>>> GetContenuCommandes()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/contenucommande/commande/5
        [HttpGet("commande/{id}")]
        public async Task<ActionResult<IEnumerable<ContenuCommande>>> GetByIdCommande(int id)
        {
            var contenucommandes = await dataRepository.GetByIdCommandeAsync(id);

            if (contenucommandes == null || !contenucommandes.Value.Any())
            {
                return NotFound();
            }

            return Ok(contenucommandes);
        }

        // GET: api/contenucommande/equipement/5
        [HttpGet("equipement/{id}")]
        public async Task<ActionResult<IEnumerable<ContenuCommande>>> GetByIdEquipement(int id)
        {
            var contenucommandes = await dataRepository.GetByIdEquipementAsync(id);

            if (contenucommandes == null || !contenucommandes.Value.Any())
            {
                return NotFound();
            }

            return Ok(contenucommandes);
        }

        // GET: api/contenucommande/taille/5
        [HttpGet("taille/{id}")]
        public async Task<ActionResult<IEnumerable<ContenuCommande>>> GetByIdTaille(int id)
        {
            var contenucommandes = await dataRepository.GetByIdTailleAsync(id);

            if (contenucommandes == null || !contenucommandes.Value.Any())
            {
                return NotFound();
            }

            return Ok(contenucommandes);
        }

        // GET: api/contenucommande/coloris/5
        [HttpGet("coloris/{id}")]
        public async Task<ActionResult<IEnumerable<ContenuCommande>>> GetByIdColoris(int id)
        {
            var sontinclus = await dataRepository.GetByIdColorisAsync(id);

            if (sontinclus == null || !sontinclus.Value.Any())
            {
                return NotFound();
            }

            return Ok(sontinclus);
        }

        // PUT: api/ContenuCommandes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContenuCommande(int id, ContenuCommande contenuCommande)
        {
            if (id != contenuCommande.IdEquipement)
            {
                return BadRequest();
            }

            _context.Entry(contenuCommande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContenuCommandeExists(id))
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

        // POST: api/ContenuCommandes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContenuCommande>> PostContenuCommande(ContenuCommande contenuCommande)
        {
          if (_context.ContenuCommandes == null)
          {
              return Problem("Entity set 'BMWDBContext.ContenuCommandes'  is null.");
          }
            _context.ContenuCommandes.Add(contenuCommande);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContenuCommandeExists(contenuCommande.IdEquipement))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContenuCommande", new { id = contenuCommande.IdEquipement }, contenuCommande);
        }

        // DELETE: api/ContenuCommandes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContenuCommande(int id)
        {
            if (_context.ContenuCommandes == null)
            {
                return NotFound();
            }
            var contenuCommande = await _context.ContenuCommandes.FindAsync(id);
            if (contenuCommande == null)
            {
                return NotFound();
            }

            _context.ContenuCommandes.Remove(contenuCommande);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContenuCommandeExists(int id)
        {
            return (_context.ContenuCommandes?.Any(e => e.IdEquipement == id)).GetValueOrDefault();
        }
    }
}
