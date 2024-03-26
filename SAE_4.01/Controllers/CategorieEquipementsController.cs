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
    public class CategorieEquipementsController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<CategorieEquipement> dataRepository;

        public CategorieEquipementsController(IDataRepository<CategorieEquipement> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/CategorieEquipements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieEquipement>>> GetCategorieEquipements()
        {
            if (_context.CategorieEquipements == null)
            {
                return NotFound();
            }
            return await _context.CategorieEquipements.ToListAsync();
        }

        // GET: api/CategorieEquipements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorieEquipement>> GetCategorieEquipement(int id)
        {
          if (_context.CategorieEquipements == null)
          {
              return NotFound();
          }
            var categorieEquipement = await _context.CategorieEquipements.FindAsync(id);

            if (categorieEquipement == null)
            {
                return NotFound();
            }

            return categorieEquipement;
        }

        // PUT: api/CategorieEquipements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorieEquipement(int id, CategorieEquipement categorieEquipement)
        {
            if (id != categorieEquipement.IdCatEquipement)
            {
                return BadRequest();
            }

            _context.Entry(categorieEquipement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieEquipementExists(id))
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

        // POST: api/CategorieEquipements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategorieEquipement>> PostCategorieEquipement(CategorieEquipement categorieEquipement)
        {
          if (_context.CategorieEquipements == null)
          {
              return Problem("Entity set 'BMWDBContext.CategorieEquipements'  is null.");
          }
            _context.CategorieEquipements.Add(categorieEquipement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorieEquipement", new { id = categorieEquipement.IdCatEquipement }, categorieEquipement);
        }

        // DELETE: api/CategorieEquipements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorieEquipement(int id)
        {
            if (_context.CategorieEquipements == null)
            {
                return NotFound();
            }
            var categorieEquipement = await _context.CategorieEquipements.FindAsync(id);
            if (categorieEquipement == null)
            {
                return NotFound();
            }

            _context.CategorieEquipements.Remove(categorieEquipement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategorieEquipementExists(int id)
        {
            return (_context.CategorieEquipements?.Any(e => e.IdCatEquipement == id)).GetValueOrDefault();
        }
    }
}
