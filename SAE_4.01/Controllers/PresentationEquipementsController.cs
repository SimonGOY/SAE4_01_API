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

        // PUT: api/PresentationEquipements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPresentationEquipement(int id, PresentationEquipement presentationEquipement)
        {
            if (id != presentationEquipement.IdPresentation)
            {
                return BadRequest();
            }

            _context.Entry(presentationEquipement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresentationEquipementExists(id))
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

        // POST: api/PresentationEquipements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PresentationEquipement>> PostPresentationEquipement(PresentationEquipement presentationEquipement)
        {
          if (_context.PresentationEquipements == null)
          {
              return Problem("Entity set 'BMWDBContext.PresentationEquipements'  is null.");
          }
            _context.PresentationEquipements.Add(presentationEquipement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPresentationEquipement", new { id = presentationEquipement.IdPresentation }, presentationEquipement);
        }

        // DELETE: api/PresentationEquipements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePresentationEquipement(int id)
        {
            if (_context.PresentationEquipements == null)
            {
                return NotFound();
            }
            var presentationEquipement = await _context.PresentationEquipements.FindAsync(id);
            if (presentationEquipement == null)
            {
                return NotFound();
            }

            _context.PresentationEquipements.Remove(presentationEquipement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PresentationEquipementExists(int id)
        {
            return (_context.PresentationEquipements?.Any(e => e.IdPresentation == id)).GetValueOrDefault();
        }
    }
}
