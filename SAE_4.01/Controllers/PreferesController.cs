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
    public class PreferesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        public PreferesController(BMWDBContext context)
        {
            _context = context;
        }

        // GET: api/Preferes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prefere>>> GetPreferes()
        {
          if (_context.Preferes == null)
          {
              return NotFound();
          }
            return await _context.Preferes.ToListAsync();
        }

        // GET: api/Preferes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prefere>> GetPrefere(int id)
        {
          if (_context.Preferes == null)
          {
              return NotFound();
          }
            var prefere = await _context.Preferes.FindAsync(id);

            if (prefere == null)
            {
                return NotFound();
            }

            return prefere;
        }

        // PUT: api/Preferes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrefere(int id, Prefere prefere)
        {
            if (id != prefere.IdClient)
            {
                return BadRequest();
            }

            _context.Entry(prefere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrefereExists(id))
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

        // POST: api/Preferes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prefere>> PostPrefere(Prefere prefere)
        {
          if (_context.Preferes == null)
          {
              return Problem("Entity set 'BMWDBContext.Preferes'  is null.");
          }
            _context.Preferes.Add(prefere);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrefereExists(prefere.IdClient))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrefere", new { id = prefere.IdClient }, prefere);
        }

        // DELETE: api/Preferes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrefere(int id)
        {
            if (_context.Preferes == null)
            {
                return NotFound();
            }
            var prefere = await _context.Preferes.FindAsync(id);
            if (prefere == null)
            {
                return NotFound();
            }

            _context.Preferes.Remove(prefere);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrefereExists(int id)
        {
            return (_context.Preferes?.Any(e => e.IdClient == id)).GetValueOrDefault();
        }
    }
}
