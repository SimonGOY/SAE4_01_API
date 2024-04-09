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
    public class EstLiesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<EstLie> dataRepository;

        public EstLiesController(IDataRepository<EstLie> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/EstLies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstLie>>> GetSontLies()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/EstLie/equipement/5
        [HttpGet("equipement/{id}")]
        public async Task<ActionResult<IEnumerable<EstLie>>> GetByIdEquipement(int id)
        {
            var sontlies = await dataRepository.GetByIdEquipementAsync(id);

            if (sontlies == null || !sontlies.Value.Any())
            {
                return NotFound();
            }

            return Ok(sontlies);
        }

        // GET: api/EstLie/equidequipement/5
        [HttpGet("equidequipement/{id}")]
        public async Task<ActionResult<IEnumerable<EstLie>>> GetByEquIdEquipement(int id)
        {
            var sontlies = await dataRepository.GetByEquIdEquipementAsync(id);

            if (sontlies == null || !sontlies.Value.Any())
            {
                return NotFound();
            }

            return Ok(sontlies);
        }

        [HttpGet("{id1}/{id2}")]
        public async Task<ActionResult<EstLie>> GetByIds(int id1, int id2)
        {
            var estLie = await dataRepository.GetBy2CompositeKeysAsync(id1, id2);

            if (estLie == null)
            {
                return NotFound();
            }

            return estLie;
        }

        // POST: api/EstLies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<EstLie>> PostEstLie(EstLie estLie)
        {
            try
            {
                await dataRepository.AddAsync(estLie);
                return CreatedAtAction(nameof(dataRepository.GetBy2CompositeKeysAsync), new { id1 = estLie.IdEquipement, id2 = estLie.EquIdEquipement }, estLie);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur lors de la création de l'entitee : {ex.Message}");
            }
        }

        // DELETE: api/EstLies/5
        [HttpDelete("{id1}/{id2}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteEstLie(int id1, int id2)
        {
            var estLie = await dataRepository.GetBy2CompositeKeysAsync(id1, id2);

            if (estLie == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(estLie.Value);
            return NoContent();
        }

        private bool EstLieExists(int id)
        {
            return (_context.SontLies?.Any(e => e.IdEquipement == id)).GetValueOrDefault();
        }
    }
}
