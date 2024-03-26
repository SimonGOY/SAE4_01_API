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
    public class DemandeEssaisController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<DemandeEssai> dataRepository;

        public DemandeEssaisController(IDataRepository<DemandeEssai> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/DemandeEssais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DemandeEssai>>> GetDemandeEssais()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/DemandeEssais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DemandeEssai>> GetDemandeEssai(int id)
        {

            var demandeEssai = await dataRepository.GetByIdAsync(id);

            if (demandeEssai == null)
            {
                return NotFound();
            }

            return demandeEssai;
        }

        // PUT: api/DemandeEssais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDemandeEssai(int id, DemandeEssai demandeEssai)
        {
            if (id != demandeEssai.IdDemandeEssai)
            {
                return BadRequest();
            }

            _context.Entry(demandeEssai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemandeEssaiExists(id))
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

        // POST: api/DemandeEssais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DemandeEssai>> PostDemandeEssai(DemandeEssai demandeEssai)
        {
          if (_context.DemandeEssais == null)
          {
              return Problem("Entity set 'BMWDBContext.DemandeEssais'  is null.");
          }
            _context.DemandeEssais.Add(demandeEssai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDemandeEssai", new { id = demandeEssai.IdDemandeEssai }, demandeEssai);
        }

        // DELETE: api/DemandeEssais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDemandeEssai(int id)
        {
            if (_context.DemandeEssais == null)
            {
                return NotFound();
            }
            var demandeEssai = await _context.DemandeEssais.FindAsync(id);
            if (demandeEssai == null)
            {
                return NotFound();
            }

            _context.DemandeEssais.Remove(demandeEssai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DemandeEssaiExists(int id)
        {
            return (_context.DemandeEssais?.Any(e => e.IdDemandeEssai == id)).GetValueOrDefault();
        }
    }
}
