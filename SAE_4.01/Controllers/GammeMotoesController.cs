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
    public class GammeMotoesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<GammeMoto> dataRepository;

        public GammeMotoesController(IDataRepository<GammeMoto> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/GammeMotoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GammeMoto>>> GetGammeMotos()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/GammeMotoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GammeMoto>> GetGammeMoto(int id)
        {

            var gammeMoto = await dataRepository.GetByIdAsync(id);

            if (gammeMoto == null)
            {
                return NotFound();
            }

            return gammeMoto;
        }


        // POST: api/GammeMotoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<GammeMoto>> PostGammeMoto(GammeMoto gammeMoto)
        {
            if (gammeMoto == null)
            {
                return Problem("Entity set 'BMWDBContext.GammeMotos'  is null.");
            }
            await dataRepository.AddAsync(gammeMoto);

            return CreatedAtAction("GetGammeMoto", new { id = gammeMoto.IdGamme }, gammeMoto);
        }

        // DELETE: api/GammeMotoes/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteGammeMoto(int id)
        {
            var gammeMoto = await dataRepository.GetByIdAsync(id);

            if (gammeMoto == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(gammeMoto.Value);

            return NoContent();
        }

        private bool GammeMotoExists(int id)
        {
            return (_context.GammeMotos?.Any(e => e.IdGamme == id)).GetValueOrDefault();
        }
    }
}
