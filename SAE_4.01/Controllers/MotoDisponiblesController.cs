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
    public class MotoDisponiblesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<MotoDisponible> dataRepository;

        public MotoDisponiblesController(IDataRepository<MotoDisponible> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/MotoDisponibles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotoDisponible>>> GetMotoDisponibles()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/MotoDisponibles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotoDisponible>> GetMotoDisponible(int id)
        {

            var motoDisponible = await dataRepository.GetByIdAsync(id);

            if (motoDisponible == null)
            {
                return NotFound();
            }

            return motoDisponible;
        }

        // PUT: api/MotoDisponibles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotoDisponible(int id, MotoDisponible motoDisponible)
        {
            if (id != motoDisponible.IdMotoDisponible)
            {
                return BadRequest();
            }

            _context.Entry(motoDisponible).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoDisponibleExists(id))
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

        // POST: api/MotoDisponibles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MotoDisponible>> PostMotoDisponible(MotoDisponible motoDisponible)
        {
          if (_context.MotoDisponibles == null)
          {
              return Problem("Entity set 'BMWDBContext.MotoDisponibles'  is null.");
          }
            _context.MotoDisponibles.Add(motoDisponible);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotoDisponible", new { id = motoDisponible.IdMotoDisponible }, motoDisponible);
        }

        // DELETE: api/MotoDisponibles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotoDisponible(int id)
        {
            if (_context.MotoDisponibles == null)
            {
                return NotFound();
            }
            var motoDisponible = await _context.MotoDisponibles.FindAsync(id);
            if (motoDisponible == null)
            {
                return NotFound();
            }

            _context.MotoDisponibles.Remove(motoDisponible);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotoDisponibleExists(int id)
        {
            return (_context.MotoDisponibles?.Any(e => e.IdMotoDisponible == id)).GetValueOrDefault();
        }
    }
}
