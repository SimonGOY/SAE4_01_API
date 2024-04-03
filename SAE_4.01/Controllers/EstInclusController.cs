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
    public class EstInclusController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<EstInclus> dataRepository;

        public EstInclusController(IDataRepository<EstInclus> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/EstInclus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstInclus>>> GetSontInclus()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/EstInclus/option/5
        [HttpGet("option/{id}")]
        public async Task<ActionResult<IEnumerable<EstInclus>>> GetByIdOption(int id)
        {
            var sontinclus = await dataRepository.GetByIdOptionAsync(id);

            if (sontinclus == null || !sontinclus.Value.Any())
            {
                return NotFound();
            }

            return Ok(sontinclus);
        }

        // GET: api/EstInclus/style/5
        [HttpGet("style/{id}")]
        public async Task<ActionResult<IEnumerable<EstInclus>>> GetByIdStyle(int id)
        {
            return await dataRepository.GetAllAsync();
        }

        [HttpGet("{id1}/{id2}")]
        public async Task<ActionResult<EstInclus>> GetByIds(int id1, int id2)
        {
            var estInclus = await dataRepository.GetBy2CompositeKeysAsync(id1, id2);

            if (estInclus == null)
            {
                return NotFound();
            }

            return estInclus;
        }

        // PUT: api/EstInclus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id1}/{id2}")]
        public async Task<IActionResult> PutEstInclus(int id1, int id2, EstInclus estInclus)
        {

            var eclToUpdate = await dataRepository.GetBy2CompositeKeysAsync(id1, id2);

            if (eclToUpdate == null)
            {
                return NotFound();
            }

            // Mettre à jour l'entité existante avec les données de l'entité passée en paramètre
            await dataRepository.UpdateAsync(eclToUpdate.Value, estInclus);
            return NoContent();
        }

        // POST: api/EstInclus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstInclus>> PostEstInclus(EstInclus estInclus)
        {
            try
            {
                await dataRepository.AddAsync(estInclus);
                return CreatedAtAction(nameof(dataRepository.GetBy2CompositeKeysAsync), new { id1 = estInclus.IdOption, id2 = estInclus.IdStyle}, estInclus);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur lors de la création de l'entitee : {ex.Message}");
            }
        }

        // DELETE: api/EstInclus/5
        [HttpDelete("{id1}/{id2}")]
        public async Task<IActionResult> DeleteEstInclus(int id1, int id2)
        {
            var estInclus = await dataRepository.GetBy2CompositeKeysAsync(id1, id2);

            if (estInclus == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(estInclus.Value);
            return NoContent();
        }

        private bool EstInclusExists(int id)
        {
            return (_context.SontInclus?.Any(e => e.IdOption == id)).GetValueOrDefault();
        }
    }
}
