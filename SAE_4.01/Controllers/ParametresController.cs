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
    public class ParametresController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Parametre> dataRepository;

        public ParametresController(IDataRepository<Parametre> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Parametres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parametre>>> GetParametres()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Parametres/5
        [HttpGet("{nom}")]
        public async Task<ActionResult<Parametre>> GetParametre(string nom)
        {

            var parametres = await dataRepository.GetByNomAsync(nom);

            if (parametres == null)
            {
                return NotFound();
            }

            return parametres;
        }

        // PUT: api/Parametres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{nom}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> PutParametre(string nom, Parametre parametre)
        {
            if (nom != parametre.NomParametre)
            {
                return BadRequest();
            }

            var parToUpdate = await dataRepository.GetByNomAsync(nom);

            if (parToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(parToUpdate.Value, parametre);
                return NoContent();
            }
        }

        // POST: api/Parametres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<Parametre>> PostParametre(Parametre parametre)
        {
            if (parametre == null)
            {
                return Problem("Entity set 'BMWDBContext.Parametres'  is null.");
            }
            await dataRepository.AddAsync(parametre);

            return CreatedAtAction("GetParametre", new { nom = parametre.NomParametre }, parametre);
        }

        // DELETE: api/Parametres/5
        [HttpDelete("{nom}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteParametre(string nom)
        {
            var parametre = await dataRepository.GetByNomAsync(nom);

            if (parametre == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(parametre.Value);

            return NoContent();
        }

        private bool ParametresExists(string id)
        {
            return (_context.Parametres?.Any(e => e.NomParametre == id)).GetValueOrDefault();
        }
    }
}
