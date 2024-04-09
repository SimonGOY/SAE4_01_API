using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<IEnumerable<ContenuCommande>>> GetContenuCommandes()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/contenucommande/commande/5
        [HttpGet("commande/{id}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<IEnumerable<ContenuCommande>>> GetByIdCommande(int id)
        {
            var contenuCommande = await dataRepository.GetByIdCommandeAsync(id);

            if (contenuCommande == null || !contenuCommande.Value.Any())
            {
                return NotFound();
            }

            return Ok(contenuCommande);
        }

        // GET: api/contenucommande/equipement/5
        [HttpGet("equipement/{id}")]
        [Authorize(Policy = Policies.Type0)]
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
        [Authorize(Policy = Policies.Type0)]
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
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<IEnumerable<ContenuCommande>>> GetByIdColoris(int id)
        {
            var sontinclus = await dataRepository.GetByIdColorisAsync(id);

            if (sontinclus == null || !sontinclus.Value.Any())
            {
                return NotFound();
            }

            return Ok(sontinclus);
        }

        [HttpGet("{id1}/{id2}/{id3}/{id4}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<ContenuCommande>> GetByIds(int id1, int id2, int id3, int id4)
        {
            var contenuCommande = await dataRepository.GetBy4CompositeKeysAsync(id1, id2, id3, id4);

            if (contenuCommande == null)
            {
                return NotFound();
            }

            return contenuCommande;
        }

        // PUT: api/ContenuCommandes/commande/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id1}/{id2}/{id3}/{id4}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<IActionResult> PutContenuCommande(int id1, int id2, int id3, int id4, ContenuCommande contenuCommande)
        {

            var ccmToUpdate = await dataRepository.GetBy4CompositeKeysAsync(id1, id2, id3, id4);

            if (ccmToUpdate == null)
            {
                return NotFound();
            }

            // Mettre à jour l'entité existante avec les données de l'entité passée en paramètre
            await dataRepository.UpdateAsync(ccmToUpdate.Value, contenuCommande);
            return NoContent();
        }

        // POST: api/ContenuCommandes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<ContenuCommande>> PostContenuCommande(ContenuCommande contenuCommande)
        {
            try
            {
                await dataRepository.AddAsync(contenuCommande);
                return CreatedAtAction(nameof(dataRepository.GetBy4CompositeKeysAsync), new { id1 = contenuCommande.IdCommande, id2 = contenuCommande.IdEquipement, id3 = contenuCommande.IdTaille, id4 = contenuCommande.IdColoris }, contenuCommande);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur lors de la création de l'entitee : {ex.Message}");
            }
        }

        // DELETE: api/ContenuCommandes/5
        [HttpDelete("{id1}/{id2}/{id3}/{id4}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<IActionResult> DeleteContenuCommande(int id1, int id2, int id3, int id4)
        {
            var contenuCommande = await dataRepository.GetBy4CompositeKeysAsync( id1, id2, id3, id4);

            if (contenuCommande == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(contenuCommande.Value);
            return NoContent();

        }

        private bool ContenuCommandeExists(int id)
        {
            return (_context.ContenuCommandes?.Any(e => e.IdEquipement == id)).GetValueOrDefault();
        }
    }
}
