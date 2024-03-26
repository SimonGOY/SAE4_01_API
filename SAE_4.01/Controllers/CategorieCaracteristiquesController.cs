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
    public class CategorieCaracteristiquesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<CategorieCaracteristique> dataRepository;

        public CategorieCaracteristiquesController(IDataRepository<CategorieCaracteristique> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/CategorieCaracteristiques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieCaracteristique>>> GetCategorieCaracteristiques()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/CategorieCaracteristiques/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorieCaracteristique>> GetCategorieCaracteristique(int id)
        {
          if (_context.CategorieCaracteristiques == null)
          {
              return NotFound();
          }
            var categorieCaracteristique = await _context.CategorieCaracteristiques.FindAsync(id);

            if (categorieCaracteristique == null)
            {
                return NotFound();
            }

            return categorieCaracteristique;
        }

        // PUT: api/CategorieCaracteristiques/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorieCaracteristique(int id, CategorieCaracteristique categorieCaracteristique)
        {
            if (id != categorieCaracteristique.IdCatCaracteristique)
            {
                return BadRequest();
            }

            _context.Entry(categorieCaracteristique).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieCaracteristiqueExists(id))
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

        // POST: api/CategorieCaracteristiques
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategorieCaracteristique>> PostCategorieCaracteristique(CategorieCaracteristique categorieCaracteristique)
        {
          if (_context.CategorieCaracteristiques == null)
          {
              return Problem("Entity set 'BMWDBContext.CategorieCaracteristiques'  is null.");
          }
            _context.CategorieCaracteristiques.Add(categorieCaracteristique);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorieCaracteristique", new { id = categorieCaracteristique.IdCatCaracteristique }, categorieCaracteristique);
        }

        // DELETE: api/CategorieCaracteristiques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorieCaracteristique(int id)
        {
            if (_context.CategorieCaracteristiques == null)
            {
                return NotFound();
            }
            var categorieCaracteristique = await _context.CategorieCaracteristiques.FindAsync(id);
            if (categorieCaracteristique == null)
            {
                return NotFound();
            }

            _context.CategorieCaracteristiques.Remove(categorieCaracteristique);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategorieCaracteristiqueExists(int id)
        {
            return (_context.CategorieCaracteristiques?.Any(e => e.IdCatCaracteristique == id)).GetValueOrDefault();
        }
    }
}
