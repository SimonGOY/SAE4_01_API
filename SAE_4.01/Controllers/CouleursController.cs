using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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
    public class CouleursController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Couleur> dataRepository;

        public CouleursController(IDataRepository<Couleur> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Couleurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Couleur>>> GetCouleurs()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Couleurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Couleur>> GetCouleur(int id)
        {

            var couleur = await dataRepository.GetByIdAsync(id);

            if (couleur == null)
            {
                return NotFound();
            }

            return couleur;
        }

        // PUT: api/Couleurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCouleur(int id, Couleur couleur)
        {
            if (id != couleur.IdCouleur)
            {
                return BadRequest();
            }

            var clrToUpdate = await dataRepository.GetByIdAsync(id);

            if (clrToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(clrToUpdate.Value, couleur);
                return NoContent();
            }
        }

        // POST: api/Couleurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Couleur>> PostCouleur(Couleur couleur)
        {
            if (couleur == null)
            {
                return Problem("Entity set 'BMWDBContext.Couleurs'  is null.");
            }
            await dataRepository.AddAsync(couleur);

            return CreatedAtAction("GetCouleur", new { id = couleur.IdCouleur }, couleur);
        }

        // DELETE: api/Couleurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCouleur(int id)
        {
            var couleur = await dataRepository.GetByIdAsync(id);

            if (couleur == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(couleur.Value);

            return NoContent();
        }

        private bool CouleurExists(int id)
        {
            return (_context.Couleurs?.Any(e => e.IdCouleur == id)).GetValueOrDefault();
        }
    }
}
