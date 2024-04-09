using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;

namespace SAE_4._01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentationEquipementsController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<PresentationEquipement> dataRepository;

        public PresentationEquipementsController(IDataRepository<PresentationEquipement> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/PresentationEquipements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PresentationEquipement>>> GetPresentationEquipements()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/PresentationEquipements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PresentationEquipement>> GetPresentationEquipement(int id)
        {

            var presentationEquipement = await dataRepository.GetByIdAsync(id);

            if (presentationEquipement == null)
            {
                return NotFound();
            }

            return presentationEquipement;
        }


        // POST: api/PresentationEquipements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<PresentationEquipement>> PostPresentationEquipement(PresentationEquipement presentationEquipement)
        {
            if (presentationEquipement == null)
            {
                return Problem("Entity set 'BMWDBContext.PresentaionEquipements'  is null.");
            }
            await dataRepository.AddAsync(presentationEquipement);

            return CreatedAtAction("GetPresentationEquipement", new { id = presentationEquipement.IdPresentation }, presentationEquipement);
        }

        // DELETE: api/PresentationEquipements/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeletePresentationEquipement(int id)
        {
            var presentationEquipement = await dataRepository.GetByIdAsync(id);

            if (presentationEquipement == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(presentationEquipement.Value);

            return NoContent();
        }

        private bool PresentationEquipementExists(int id)
        {
            return (_context.PresentationEquipements?.Any(e => e.IdPresentation == id)).GetValueOrDefault();
        }
    }
}
