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
    public class AccessoiresController : ControllerBase
    {
        private readonly BMWDBContext _context;

        public AccessoiresController(BMWDBContext context)
        {
            _context = context;
        }

        // GET: api/Accessoires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accessoire>>> GetAccessoires()
        {
          if (_context.Accessoires == null)
          {
              return NotFound();
          }
            return await _context.Accessoires.ToListAsync();
        }

        // GET: api/Accessoires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accessoire>> GetAccessoire(int id)
        {
          if (_context.Accessoires == null)
          {
              return NotFound();
          }
            var accessoire = await _context.Accessoires.FindAsync(id);

            if (accessoire == null)
            {
                return NotFound();
            }

            return accessoire;
        }

        // PUT: api/Accessoires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccessoire(int id, Accessoire accessoire)
        {
            if (id != accessoire.IdAccessoire)
            {
                return BadRequest();
            }

            _context.Entry(accessoire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessoireExists(id))
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

        // POST: api/Accessoires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Accessoire>> PostAccessoire(Accessoire accessoire)
        {
          if (_context.Accessoires == null)
          {
              return Problem("Entity set 'BMWDBContext.Accessoires'  is null.");
          }
            _context.Accessoires.Add(accessoire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccessoire", new { id = accessoire.IdAccessoire }, accessoire);
        }

        // DELETE: api/Accessoires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccessoire(int id)
        {
            if (_context.Accessoires == null)
            {
                return NotFound();
            }
            var accessoire = await _context.Accessoires.FindAsync(id);
            if (accessoire == null)
            {
                return NotFound();
            }

            _context.Accessoires.Remove(accessoire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccessoireExists(int id)
        {
            return (_context.Accessoires?.Any(e => e.IdAccessoire == id)).GetValueOrDefault();
        }
    }
}
