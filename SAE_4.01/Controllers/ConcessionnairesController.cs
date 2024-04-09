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
    public class ConcessionnairesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Concessionnaire> dataRepository;

        public ConcessionnairesController(IDataRepository<Concessionnaire> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Concessionnaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concessionnaire>>> GetConcessionnaires()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Concessionnaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Concessionnaire>> GetConcessionnaire(int id)
        {

            var concessionnaire = await dataRepository.GetByIdAsync(id);

            if (concessionnaire == null)
            {
                return NotFound();
            }

            return concessionnaire;
        }

        // PUT: api/Concessionnaires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> PutConcessionnaire(int id, Concessionnaire concessionnaire)
        {
            if (id != concessionnaire.IdConcessionnaire)
            {
                return BadRequest();
            }

            var conToUpdate = await dataRepository.GetByIdAsync(id);

            if (conToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(conToUpdate.Value, concessionnaire);
                return NoContent();
            }
        }

        // POST: api/Concessionnaires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<Concessionnaire>> PostConcessionnaire(Concessionnaire concessionnaire)
        {
            if (concessionnaire == null)
            {
                return Problem("Entity set 'BMWDBContext.Concessionnaires'  is null.");
            }
            await dataRepository.AddAsync(concessionnaire);

            return CreatedAtAction("GetConcessionnaire", new { id = concessionnaire.IdConcessionnaire }, concessionnaire);
        }

        // DELETE: api/Concessionnaires/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteConcessionnaire(int id)
        {
            var concessionnaire = await dataRepository.GetByIdAsync(id);

            if (concessionnaire == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(concessionnaire.Value);

            return NoContent();
        }

        private bool ConcessionnaireExists(int id)
        {
            return (_context.Concessionnaires?.Any(e => e.IdConcessionnaire == id)).GetValueOrDefault();
        }
    }
}
