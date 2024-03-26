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
    public class PrivesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Prive> dataRepository;

        public PrivesController(IDataRepository<Prive> dataRepo)
        {
            dataRepository = dataRepo;
        }


        // GET: api/Prives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prive>>> GetPrives()
        {
          if (_context.Prives == null)
          {
              return NotFound();
          }
            return await _context.Prives.ToListAsync();
        }

        // GET: api/Prives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prive>> GetPrive(int id)
        {
          if (_context.Prives == null)
          {
              return NotFound();
          }
            var prive = await _context.Prives.FindAsync(id);

            if (prive == null)
            {
                return NotFound();
            }

            return prive;
        }

        // PUT: api/Prives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrive(int id, Prive prive)
        {
            if (id != prive.IdPrive)
            {
                return BadRequest();
            }

            _context.Entry(prive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriveExists(id))
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

        // POST: api/Prives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prive>> PostPrive(Prive prive)
        {
          if (_context.Prives == null)
          {
              return Problem("Entity set 'BMWDBContext.Prives'  is null.");
          }
            _context.Prives.Add(prive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrive", new { id = prive.IdPrive }, prive);
        }

        // DELETE: api/Prives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrive(int id)
        {
            if (_context.Prives == null)
            {
                return NotFound();
            }
            var prive = await _context.Prives.FindAsync(id);
            if (prive == null)
            {
                return NotFound();
            }

            _context.Prives.Remove(prive);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PriveExists(int id)
        {
            return (_context.Prives?.Any(e => e.IdPrive == id)).GetValueOrDefault();
        }
    }
}
