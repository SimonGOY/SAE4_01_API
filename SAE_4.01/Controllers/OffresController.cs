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
    public class OffresController : ControllerBase
    {
        private readonly BMWDBContext _context;

        public OffresController(BMWDBContext context)
        {
            _context = context;
        }

        // GET: api/Offres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offre>>> GetOffres()
        {
          if (_context.Offres == null)
          {
              return NotFound();
          }
            return await _context.Offres.ToListAsync();
        }

        // GET: api/Offres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Offre>> GetOffre(int id)
        {
          if (_context.Offres == null)
          {
              return NotFound();
          }
            var offre = await _context.Offres.FindAsync(id);

            if (offre == null)
            {
                return NotFound();
            }

            return offre;
        }

        // PUT: api/Offres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffre(int id, Offre offre)
        {
            if (id != offre.IdOffre)
            {
                return BadRequest();
            }

            _context.Entry(offre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OffreExists(id))
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

        // POST: api/Offres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Offre>> PostOffre(Offre offre)
        {
          if (_context.Offres == null)
          {
              return Problem("Entity set 'BMWDBContext.Offres'  is null.");
          }
            _context.Offres.Add(offre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOffre", new { id = offre.IdOffre }, offre);
        }

        // DELETE: api/Offres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffre(int id)
        {
            if (_context.Offres == null)
            {
                return NotFound();
            }
            var offre = await _context.Offres.FindAsync(id);
            if (offre == null)
            {
                return NotFound();
            }

            _context.Offres.Remove(offre);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OffreExists(int id)
        {
            return (_context.Offres?.Any(e => e.IdOffre == id)).GetValueOrDefault();
        }
    }
}
