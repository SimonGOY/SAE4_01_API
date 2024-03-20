using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_4._01.Models.EntityFramework;

namespace SAE_4._01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstInclusController : ControllerBase
    {
        private readonly BMWDBContext _context;

        public EstInclusController(BMWDBContext context)
        {
            _context = context;
        }

        // GET: api/EstInclus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstInclus>>> GetSontInclus()
        {
          if (_context.SontInclus == null)
          {
              return NotFound();
          }
            return await _context.SontInclus.ToListAsync();
        }

        // GET: api/EstInclus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstInclus>> GetEstInclus(int id)
        {
          if (_context.SontInclus == null)
          {
              return NotFound();
          }
            var estInclus = await _context.SontInclus.FindAsync(id);

            if (estInclus == null)
            {
                return NotFound();
            }

            return estInclus;
        }

        // PUT: api/EstInclus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstInclus(int id, EstInclus estInclus)
        {
            if (id != estInclus.IdOption)
            {
                return BadRequest();
            }

            _context.Entry(estInclus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstInclusExists(id))
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

        // POST: api/EstInclus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstInclus>> PostEstInclus(EstInclus estInclus)
        {
          if (_context.SontInclus == null)
          {
              return Problem("Entity set 'BMWDBContext.SontInclus'  is null.");
          }
            _context.SontInclus.Add(estInclus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstInclusExists(estInclus.IdOption))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEstInclus", new { id = estInclus.IdOption }, estInclus);
        }

        // DELETE: api/EstInclus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstInclus(int id)
        {
            if (_context.SontInclus == null)
            {
                return NotFound();
            }
            var estInclus = await _context.SontInclus.FindAsync(id);
            if (estInclus == null)
            {
                return NotFound();
            }

            _context.SontInclus.Remove(estInclus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstInclusExists(int id)
        {
            return (_context.SontInclus?.Any(e => e.IdOption == id)).GetValueOrDefault();
        }
    }
}
