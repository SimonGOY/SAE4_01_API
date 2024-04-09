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
            return await dataRepository.GetAllAsync();
        }

        // GET: api/CategorieEquipements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorieEquipement>> GetCategorieEquipement(int id)
        {

            var categorieEquipement = await dataRepository.GetByIdAsync(id);

            if (categorieEquipement == null)
            {
                return NotFound();
            }

            return categorieEquipement;
        }


        // POST: api/CategorieEquipements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<CategorieEquipement>> PostCategorieEquipement(CategorieEquipement categorieEquipement)
        {
            if (categorieEquipement == null)
            {
                return Problem("Entity set 'BMWDBContext.CategorieEquipements'  is null.");
            }
            await dataRepository.AddAsync(categorieEquipement);

            return CreatedAtAction("GetCategorieEquipement", new { id = categorieEquipement.IdCatEquipement }, categorieEquipement);
        }

        // DELETE: api/CategorieEquipements/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteCategorieEquipement(int id)
        {
            var categorieEquipement = await dataRepository.GetByIdAsync(id);

            if (categorieEquipement == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(categorieEquipement.Value);

            return NoContent();
        }

        private bool CategorieEquipementExists(int id)
        {
            return (_context.CategorieEquipements?.Any(e => e.IdCatEquipement == id)).GetValueOrDefault();
        }
    }
}
