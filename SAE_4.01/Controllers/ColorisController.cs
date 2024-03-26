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
          if (_context.LesColoris == null)
          {
              return NotFound();
          }
            return await _context.LesColoris.ToListAsync();
        }

        // GET: api/Coloris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coloris>> GetColoris(int id)
        {
          if (_context.LesColoris == null)
          {
              return NotFound();
          }
            var coloris = await _context.LesColoris.FindAsync(id);

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

            _context.Entry(coloris).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorisExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Coloris
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coloris>> PostColoris(Coloris coloris)
        {
          if (_context.LesColoris == null)
          {
              return Problem("Entity set 'BMWDBContext.LesColoris'  is null.");
          }
            _context.LesColoris.Add(coloris);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColoris", new { id = coloris.IdColoris }, coloris);
        }

        // DELETE: api/Coloris/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColoris(int id)
        {
            if (_context.LesColoris == null)
            {
                return NotFound();
            }
            var coloris = await _context.LesColoris.FindAsync(id);
            if (coloris == null)
            {
                return NotFound();
            }

            _context.LesColoris.Remove(coloris);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColorisExists(int id)
        {
            return (_context.LesColoris?.Any(e => e.IdColoris == id)).GetValueOrDefault();
        }
    }
}
