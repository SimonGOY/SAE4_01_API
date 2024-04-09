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
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<IEnumerable<DemandeEssai>>> GetDemandeEssais()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/DemandeEssais/5
        [HttpGet("{id}")]
        [Authorize(Policy = Policies.Type0)]
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
        [Authorize(Policy = Policies.Type0)]
        public async Task<IActionResult> PutDemandeEssai(int id, DemandeEssai demandeEssai)
        {
            if (id != demandeEssai.IdDemandeEssai)
            {
                return BadRequest();
            }

            var dmdToUpdate = await dataRepository.GetByIdAsync(id);

            if (dmdToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(dmdToUpdate.Value, demandeEssai);
                return NoContent();
            }
        }

        // POST: api/DemandeEssais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<DemandeEssai>> PostDemandeEssai(DemandeEssai demandeEssai)
        {
            if (demandeEssai == null)
            {
                return Problem("Entity set 'BMWDBContext.DemandeEssais'  is null.");
            }
            await dataRepository.AddAsync(demandeEssai);

            return CreatedAtAction("GetDemandeEssai", new { id = demandeEssai.IdDemandeEssai }, demandeEssai);
        }

        // DELETE: api/DemandeEssais/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<IActionResult> DeleteDemandeEssai(int id)
        {
            var demandeEssai = await dataRepository.GetByIdAsync(id);

            if (demandeEssai == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(demandeEssai.Value);

            return NoContent();
        }

        private bool DemandeEssaiExists(int id)
        {
            return (_context.DemandeEssais?.Any(e => e.IdDemandeEssai == id)).GetValueOrDefault();
        }
    }
}
