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
    public class ProfessionnelsController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Professionnel> dataRepository;

        public ProfessionnelsController(IDataRepository<Professionnel> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Professionnels
        [HttpGet]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<IEnumerable<Professionnel>>> GetProfessionnels()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Professionnels/5
        [HttpGet("{id}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<Professionnel>> GetProfessionnel(int id)
        {

            var professionnel = await dataRepository.GetByIdAsync(id);

            if (professionnel == null)
            {
                return NotFound();
            }

            return professionnel;
        }

        // PUT: api/Professionnels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<IActionResult> PutProfessionnel(int id, Professionnel professionnel)
        {
            if (id != professionnel.IdPro)
            {
                return BadRequest();
            }

            var proToUpdate = await dataRepository.GetByIdAsync(id);

            if (proToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(proToUpdate.Value, professionnel);
                return NoContent();
            }
        }

        // POST: api/Professionnels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<Professionnel>> PostProfessionnel(Professionnel professionnel)
        {
            if (professionnel == null)
            {
                return Problem("Entity set 'BMWDBContext.Professionnels'  is null.");
            }
            await dataRepository.AddAsync(professionnel);

            return CreatedAtAction("GetProfessionnel", new { id = professionnel.IdPro }, professionnel);
        }

        // DELETE: api/Professionnels/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<IActionResult> DeleteProfessionnel(int id)
        {
            var professionnel = await dataRepository.GetByIdAsync(id);

            if (professionnel == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(professionnel.Value);

            return NoContent();
        }

        private bool ProfessionnelExists(int id)
        {
            return (_context.Professionnels?.Any(e => e.IdPro == id)).GetValueOrDefault();
        }
    }
}
