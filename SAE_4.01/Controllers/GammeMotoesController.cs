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
    public class GammeMotoesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        public GammeMotoesController(BMWDBContext context)
        {
            _context = context;
        }

        // GET: api/GammeMotoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GammeMoto>>> GetGammeMotos()
        {
          if (_context.GammeMotos == null)
          {
              return NotFound();
          }
            return await _context.GammeMotos.ToListAsync();
        }

        // GET: api/GammeMotoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GammeMoto>> GetGammeMoto(int id)
        {
          if (_context.GammeMotos == null)
          {
              return NotFound();
          }
            var gammeMoto = await _context.GammeMotos.FindAsync(id);

            if (gammeMoto == null)
            {
                return NotFound();
            }

            return gammeMoto;
        }

        // PUT: api/GammeMotoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGammeMoto(int id, GammeMoto gammeMoto)
        {
            if (id != gammeMoto.IdGamme)
            {
                return BadRequest();
            }

            _context.Entry(gammeMoto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GammeMotoExists(id))
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

        // POST: api/GammeMotoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GammeMoto>> PostGammeMoto(GammeMoto gammeMoto)
        {
          if (_context.GammeMotos == null)
          {
              return Problem("Entity set 'BMWDBContext.GammeMotos'  is null.");
          }
            _context.GammeMotos.Add(gammeMoto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGammeMoto", new { id = gammeMoto.IdGamme }, gammeMoto);
        }

        // DELETE: api/GammeMotoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGammeMoto(int id)
        {
            if (_context.GammeMotos == null)
            {
                return NotFound();
            }
            var gammeMoto = await _context.GammeMotos.FindAsync(id);
            if (gammeMoto == null)
            {
                return NotFound();
            }

            _context.GammeMotos.Remove(gammeMoto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GammeMotoExists(int id)
        {
            return (_context.GammeMotos?.Any(e => e.IdGamme == id)).GetValueOrDefault();
        }
    }
}
