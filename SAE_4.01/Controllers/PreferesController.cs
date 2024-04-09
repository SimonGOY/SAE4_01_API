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
    public class PreferesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Prefere> dataRepository;

        public PreferesController(IDataRepository<Prefere> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Preferes
        [HttpGet]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<IEnumerable<Prefere>>> GetPreferes()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/SeCompose/client/5
        [HttpGet("client/{id}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<IEnumerable<Prefere>>> GetByIdClient(int id)
        {
            var preferes = await dataRepository.GetByIdClientAsync(id);

            if (preferes == null || !preferes.Value.Any())
            {
                return NotFound();
            }

            return Ok(preferes);
        }

        // GET: api/SeCompose/concessionnaire/5
        [HttpGet("concessionnaire/{id}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<IEnumerable<Prefere>>> GetByIdConcessionnaire(int id)
        {
            var preferes = await dataRepository.GetByIdConcessionnaireAsync(id);

            if (preferes == null || !preferes.Value.Any())
            {
                return NotFound();
            }

            return Ok(preferes);
        }

        [HttpGet("{id1}/{id2}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<Prefere>> GetByIds(int id1, int id2)
        {
            var prefere = await dataRepository.GetBy2CompositeKeysAsync(id1, id2);

            if (prefere == null)
            {
                return NotFound();
            }

            return prefere;
        }

        // POST: api/Preferes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<Prefere>> PostPrefere(Prefere prefere)
        {
            try
            {
                await dataRepository.AddAsync(prefere);
                return CreatedAtAction(nameof(dataRepository.GetBy2CompositeKeysAsync), new { id1 = prefere.IdClient, id2 = prefere.IdConcessionnaire }, prefere);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur lors de la création de l'entitee : {ex.Message}");
            }
        }

        // DELETE: api/Preferes/5
        [HttpDelete("{id1}/{id2}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeletePrefere(int id1, int id2)
        {
            var prefere = await dataRepository.GetBy2CompositeKeysAsync(id1, id2);

            if (prefere == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(prefere.Value);
            return NoContent();
        }

        private bool PrefereExists(int id)
        {
            return (_context.Preferes?.Any(e => e.IdClient == id)).GetValueOrDefault();
        }
    }
}
