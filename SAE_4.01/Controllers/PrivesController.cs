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
    public class PrivesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Prive> dataRepository;

        public PrivesController(IDataRepository<Prive> dataRepo)
        {
            dataRepository = dataRepo;
        }


        // GET: api/Prives
        [HttpGet]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<IEnumerable<Prive>>> GetPrives()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Prives/5
        [HttpGet("{id}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<Prive>> GetPrive(int id)
        {

            var prive = await dataRepository.GetByIdAsync(id);

            if (prive == null)
            {
                return NotFound();
            }

            return prive;
        }


        // POST: api/Prives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<Prive>> PostPrive(Prive prive)
        {
            if (prive == null)
            {
                return Problem("Entity set 'BMWDBContext.Prives'  is null.");
            }
            await dataRepository.AddAsync(prive);

            return CreatedAtAction("GetPrive", new { id = prive.IdPrive }, prive);
        }

        // DELETE: api/Prives/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<IActionResult> DeletePrive(int id)
        {
            var prive = await dataRepository.GetByIdAsync(id);

            if (prive == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(prive.Value);

            return NoContent();
        }

        private bool PriveExists(int id)
        {
            return (_context.Prives?.Any(e => e.IdPrive == id)).GetValueOrDefault();
        }
    }
}
