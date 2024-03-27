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
    public class SeComposeController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<SeCompose> dataRepository;

        public SeComposeController(IDataRepository<SeCompose> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/SeCompose
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeCompose>>> GetSeComposes()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/SeCompose/Pack/5
        [HttpGet("pack/{id}")]
        public async Task<ActionResult<IEnumerable<SeCompose>>> GetByIdPack(int id)
        {
            var secomposent = await dataRepository.GetByIdPackAsync(id);

            if (secomposent == null || !secomposent.Value.Any())
            {
                return NotFound();
            }

            return Ok(secomposent);
        }


        // GET: api/SeCompose/Option/5
        [HttpGet("option/{id}")]
        public async Task<ActionResult<IEnumerable<SeCompose>>> GetByIdOption(int id)
        {
            var secomposent = await dataRepository.GetByIdOptionAsync(id);

            if (secomposent == null || !secomposent.Value.Any())
            {
                return NotFound();
            }

            return Ok(secomposent);
        }

        // PUT: api/SeCompose/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id1}/{id2}")]
        public async Task<IActionResult> PutSeCompose(int id1, int id2, SeCompose seCompose)
        {
            var scpToUpdate = await dataRepository.GetBy2CompositeKeysAsync(id1, id2);

            if (scpToUpdate == null)
            {
                return NotFound();
            }

            // Mettre à jour l'entité existante avec les données de l'entité passée en paramètre
            await dataRepository.UpdateAsync(scpToUpdate.Value, seCompose);
            return NoContent();
        }

        // POST: api/SeCompose
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeCompose>> PostSeCompose(SeCompose seCompose)
        {
            try
            {
                await dataRepository.AddAsync(seCompose);
                return CreatedAtAction(nameof(dataRepository.GetBy2CompositeKeysAsync), new { id1 = seCompose.IdPack, id2 = seCompose.IdOption }, seCompose);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur lors de la création de l'entitee : {ex.Message}");
            }
        }

        // DELETE: api/SeCompose/5
        [HttpDelete("{id1}/{id2}")]
        public async Task<IActionResult> DeleteSeCompose(int id1, int id2)
        {
            var seCompose = await dataRepository.GetBy2CompositeKeysAsync(id1, id2);

            if (seCompose == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(seCompose.Value);
            return NoContent();
        }

        private bool SeComposeExists(int id)
        {
            return (_context.SeComposes?.Any(e => e.IdPack == id)).GetValueOrDefault();
        }
    }
}
