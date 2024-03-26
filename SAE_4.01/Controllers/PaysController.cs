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
    public class PaysController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Pays> dataRepository;

        public PaysController(IDataRepository<Pays> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Pays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pays>>> GetLesPays()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Pays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pays>> GetPays(string id)
        {
          if (_context.LesPays == null)
          {
              return NotFound();
          }
            var pays = await _context.LesPays.FindAsync(id);

            if (pays == null)
            {
                return NotFound();
            }

            return pays;
        }

        // PUT: api/Pays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPays(string id, Pays pays)
        {
            if (id != pays.NomPays)
            {
                return BadRequest();
            }

            _context.Entry(pays).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaysExists(id))
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

        // POST: api/Pays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pays>> PostPays(Pays pays)
        {
          if (_context.LesPays == null)
          {
              return Problem("Entity set 'BMWDBContext.LesPays'  is null.");
          }
            _context.LesPays.Add(pays);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaysExists(pays.NomPays))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPays", new { id = pays.NomPays }, pays);
        }

        // DELETE: api/Pays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePays(string id)
        {
            if (_context.LesPays == null)
            {
                return NotFound();
            }
            var pays = await _context.LesPays.FindAsync(id);
            if (pays == null)
            {
                return NotFound();
            }

            _context.LesPays.Remove(pays);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaysExists(string id)
        {
            return (_context.LesPays?.Any(e => e.NomPays == id)).GetValueOrDefault();
        }
    }
}
