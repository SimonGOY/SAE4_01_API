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
    public class CaracteristiquesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Caracteristique> dataRepository;

        public CaracteristiquesController(IDataRepository<Caracteristique> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Caracteristiques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caracteristique>>> GetCaracteristiques()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Caracteristiques/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caracteristique>> GetCaracteristique(int id)
        {

            var caracteristique = await dataRepository.GetByIdAsync(id);

            if (caracteristique == null)
            {
                return NotFound();
            }

            return caracteristique;
        }

        // PUT: api/Caracteristiques/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaracteristique(int id, Caracteristique caracteristique)
        {
            if (id != caracteristique.IdCaracteristique)
            {
                return BadRequest();
            }

            var carToUpdate = await dataRepository.GetByIdAsync(id);

            if (carToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(carToUpdate.Value, caracteristique);
                return NoContent();
            }
        }

        // POST: api/Caracteristiques
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Caracteristique>> PostCaracteristique(Caracteristique caracteristique)
        {
            if (caracteristique == null)
            {
                return Problem("Entity set 'BMWDBContext.Caracteristiques'  is null.");
            }
            await dataRepository.AddAsync(caracteristique);

            return CreatedAtAction("GetCaracteristique", new { id =     caracteristique.IdCaracteristique }, caracteristique);
        }

        // DELETE: api/Caracteristiques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaracteristique(int id)
        {
            var caracteristique = await dataRepository.GetByIdAsync(id);

            if (caracteristique == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(caracteristique.Value);

            return NoContent();
        }

        private bool CaracteristiqueExists(int id)
        {
            return (_context.Caracteristiques?.Any(e => e.IdCaracteristique == id)).GetValueOrDefault();
        }
    }
}
