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

        // PUT: api/Coloris/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColoris(int id, Coloris coloris)
        {
            if (id != coloris.IdColoris)
            {
                return BadRequest();
            }

            var clsToUpdate = await dataRepository.GetByIdAsync(id);

            if (clsToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(clsToUpdate.Value, coloris);
                return NoContent();
            }
        }

        // POST: api/Coloris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
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
