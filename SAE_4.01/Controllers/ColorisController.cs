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
    public class ColorisController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Coloris> dataRepository;

        public ColorisController(IDataRepository<Coloris> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Coloris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coloris>>> GetLesColoris()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Coloris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coloris>> GetColoris(int id)
        {

            var coloris = await dataRepository.GetByIdAsync(id);

            if (coloris == null)
            {
                return NotFound();
            }

            return coloris;
        }

        // POST: api/Coloris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<Coloris>> PostColoris(Coloris coloris)
        {
            if (coloris == null)
            {
                return Problem("Entity set 'BMWDBContext.LesColoris'  is null.");
            }
            await dataRepository.AddAsync(coloris);

            return CreatedAtAction("GetCollection", new { id = coloris.IdColoris }, coloris);
        }

        // DELETE: api/Coloris/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteColoris(int id)
        {
            var coloris = await dataRepository.GetByIdAsync(id);

            if (coloris == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(coloris.Value);

            return NoContent();
        }

        private bool ColorisExists(int id)
        {
            return (_context.LesColoris?.Any(e => e.IdColoris == id)).GetValueOrDefault();
        }
    }
}
