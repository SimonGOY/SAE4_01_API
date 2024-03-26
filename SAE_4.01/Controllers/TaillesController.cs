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
    public class TaillesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Taille> dataRepository;

        public TaillesController(IDataRepository<Taille> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Tailles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taille>>> GetTailles()
        {
          if (_context.Tailles == null)
          {
              return NotFound();
          }
            return await _context.Tailles.ToListAsync();
        }

        // GET: api/Tailles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taille>> GetTaille(int id)
        {
          if (_context.Tailles == null)
          {
              return NotFound();
          }
            var taille = await _context.Tailles.FindAsync(id);

            if (taille == null)
            {
                return NotFound();
            }

            return taille;
        }

        // PUT: api/Tailles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaille(int id, Taille taille)
        {
            if (id != taille.IdTaille)
            {
                return BadRequest();
            }

            _context.Entry(taille).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TailleExists(id))
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

        // POST: api/Tailles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Taille>> PostTaille(Taille taille)
        {
          if (_context.Tailles == null)
          {
              return Problem("Entity set 'BMWDBContext.Tailles'  is null.");
          }
            _context.Tailles.Add(taille);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaille", new { id = taille.IdTaille }, taille);
        }

        // DELETE: api/Tailles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaille(int id)
        {
            if (_context.Tailles == null)
            {
                return NotFound();
            }
            var taille = await _context.Tailles.FindAsync(id);
            if (taille == null)
            {
                return NotFound();
            }

            _context.Tailles.Remove(taille);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TailleExists(int id)
        {
            return (_context.Tailles?.Any(e => e.IdTaille == id)).GetValueOrDefault();
        }
    }
}
