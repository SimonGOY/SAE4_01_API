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
    public class CategorieAccessoiresController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<CategorieAccessoire> dataRepository;

        public CategorieAccessoiresController(IDataRepository<CategorieAccessoire> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/CategorieAccessoires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieAccessoire>>> GetCategorieAccessoires()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/CategorieAccessoires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorieAccessoire>> GetCategorieAccessoire(int id)
        {

            var categorieAccessoire = await dataRepository.GetByIdAsync(id);

            if (categorieAccessoire == null)
            {
                return NotFound();
            }

            return categorieAccessoire;
        }

        // PUT: api/CategorieAccessoires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorieAccessoire(int id, CategorieAccessoire categorieAccessoire)
        {
            if (id != categorieAccessoire.IdCatAcc)
            {
                return BadRequest();
            }

            var ctaToUpdate = await dataRepository.GetByIdAsync(id);

            if (ctaToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(ctaToUpdate.Value, categorieAccessoire);
                return NoContent();
            }
        }

        // POST: api/CategorieAccessoires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategorieAccessoire>> PostCategorieAccessoire(CategorieAccessoire categorieAccessoire)
        {
            if (categorieAccessoire == null)
            {
                return Problem("Entity set 'BMWDBContext.CategorieAccessoires'  is null.");
            }
            await dataRepository.AddAsync(categorieAccessoire);

            return CreatedAtAction("GetCategorieAccessoire", new { id = categorieAccessoire.IdCatAcc }, categorieAccessoire);
        }

        // DELETE: api/CategorieAccessoires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorieAccessoire(int id)
        {
            var categorieAccessoire = await dataRepository.GetByIdAsync(id);

            if (categorieAccessoire == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(categorieAccessoire.Value);

            return NoContent();
        }

        private bool CategorieAccessoireExists(int id)
        {
            return (_context.CategorieAccessoires?.Any(e => e.IdCatAcc == id)).GetValueOrDefault();
        }
    }
}
