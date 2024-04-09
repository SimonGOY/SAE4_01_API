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
    public class MotoConfigurablesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<MotoConfigurable> dataRepository;

        public MotoConfigurablesController(IDataRepository<MotoConfigurable> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/MotoConfigurables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotoConfigurable>>> GetMotoConfigurables()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/MotoConfigurables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotoConfigurable>> GetMotoConfigurable(int id)
        {

            var motoConfigurable = await dataRepository.GetByIdAsync(id);

            if (motoConfigurable == null)
            {
                return NotFound();
            }

            return motoConfigurable;
        }


        // POST: api/MotoConfigurables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<MotoConfigurable>> PostMotoConfigurable(MotoConfigurable motoConfigurable)
        {
            if (motoConfigurable == null)
            {
                return Problem("Entity set 'BMWDBContext.MotoConfigurables'  is null.");
            }
            await dataRepository.AddAsync(motoConfigurable);

            return CreatedAtAction("GetMotoConfigurable", new { id = motoConfigurable.IdMoto }, motoConfigurable);
        }

        // DELETE: api/MotoConfigurables/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteMotoConfigurable(int id)
        {
            var motoConfigurable = await dataRepository.GetByIdAsync(id);

            if (motoConfigurable == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(motoConfigurable.Value);

            return NoContent();
        }

        private bool MotoConfigurableExists(int id)
        {
            return (_context.MotoConfigurables?.Any(e => e.IdMotoConfigurable == id)).GetValueOrDefault();
        }
    }
}
