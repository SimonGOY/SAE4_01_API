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
    public class SpecifiesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Specifie> dataRepository;

        public SpecifiesController(IDataRepository<Specifie> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Specifies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specifie>>> GetSpecifies()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Specifies/option/5
        [HttpGet("option/{id}")]
        public async Task<ActionResult<IEnumerable<Specifie>>> GetByIdOption(int id)
        {
          var specifies = await dataRepository.GetByIdOptionAsync(id);

            if (specifies == null || !specifies.Value.Any())
            {
                return NotFound();
            }

            return Ok(specifies);
        }

        // GET: api/Specifies/modelmoto/5
        [HttpGet("modelmoto/{id}")]
        public async Task<ActionResult<IEnumerable<Specifie>>> GetByIdMoto(int id)
        {
            var specifies = await dataRepository.GetByIdMotoAsync(id);

            if (specifies == null || !specifies.Value.Any())
            {
                return NotFound();
            }

            return Ok(specifies);
        }

        [HttpGet("{id1}/{id2}")]
        public async Task<ActionResult<Specifie>> GetByIds(int id1, int id2)
        {
            var specifies = await dataRepository.GetBy2CompositeKeysAsync(id1, id2);

            if (specifies == null)
            {
                return NotFound();
            }

            return specifies;
        }


        // POST: api/Specifies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<Specifie>> PostSpecifie(Specifie specifie)
        {
            try
            {
                await dataRepository.AddAsync(specifie);
                return CreatedAtAction(nameof(dataRepository.GetBy2CompositeKeysAsync), new { id1 = specifie.IdOption, id2 = specifie.IdMoto }, specifie);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur lors de la création de l'entitee : {ex.Message}");
            }
        }

        // DELETE: api/Specifies/5
        [HttpDelete("{id1}/{id2}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteSpecifie(int id1, int id2)
        {
            var specifie = await dataRepository.GetBy2CompositeKeysAsync(id1, id2);

            if (specifie == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(specifie.Value);
            return NoContent();
        }

        private bool SpecifieExists(int id)
        {
            return (_context.Specifies?.Any(e => e.IdMoto == id)).GetValueOrDefault();
        }
    }
}
