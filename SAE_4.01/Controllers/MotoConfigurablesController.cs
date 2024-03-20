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
    public class MotoConfigurablesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        public MotoConfigurablesController(BMWDBContext context)
        {
            _context = context;
        }

        // GET: api/MotoConfigurables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotoConfigurable>>> GetMotoConfigurables()
        {
          if (_context.MotoConfigurables == null)
          {
              return NotFound();
          }
            return await _context.MotoConfigurables.ToListAsync();
        }

        // GET: api/MotoConfigurables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotoConfigurable>> GetMotoConfigurable(int id)
        {
          if (_context.MotoConfigurables == null)
          {
              return NotFound();
          }
            var motoConfigurable = await _context.MotoConfigurables.FindAsync(id);

            if (motoConfigurable == null)
            {
                return NotFound();
            }

            return motoConfigurable;
        }

        // PUT: api/MotoConfigurables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotoConfigurable(int id, MotoConfigurable motoConfigurable)
        {
            if (id != motoConfigurable.IdMotoConfigurable)
            {
                return BadRequest();
            }

            _context.Entry(motoConfigurable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoConfigurableExists(id))
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

        // POST: api/MotoConfigurables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MotoConfigurable>> PostMotoConfigurable(MotoConfigurable motoConfigurable)
        {
          if (_context.MotoConfigurables == null)
          {
              return Problem("Entity set 'BMWDBContext.MotoConfigurables'  is null.");
          }
            _context.MotoConfigurables.Add(motoConfigurable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotoConfigurable", new { id = motoConfigurable.IdMotoConfigurable }, motoConfigurable);
        }

        // DELETE: api/MotoConfigurables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotoConfigurable(int id)
        {
            if (_context.MotoConfigurables == null)
            {
                return NotFound();
            }
            var motoConfigurable = await _context.MotoConfigurables.FindAsync(id);
            if (motoConfigurable == null)
            {
                return NotFound();
            }

            _context.MotoConfigurables.Remove(motoConfigurable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotoConfigurableExists(int id)
        {
            return (_context.MotoConfigurables?.Any(e => e.IdMotoConfigurable == id)).GetValueOrDefault();
        }
    }
}
