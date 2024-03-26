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
    public class ConcessionnairesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Concessionnaire> dataRepository;

        public ConcessionnairesController(IDataRepository<Concessionnaire> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Concessionnaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concessionnaire>>> GetConcessionnaires()
        {
          if (_context.Concessionnaires == null)
          {
              return NotFound();
          }
            return await _context.Concessionnaires.ToListAsync();
        }

        // GET: api/Concessionnaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Concessionnaire>> GetConcessionnaire(int id)
        {
          if (_context.Concessionnaires == null)
          {
              return NotFound();
          }
            var concessionnaire = await _context.Concessionnaires.FindAsync(id);

            if (concessionnaire == null)
            {
                return NotFound();
            }

            return concessionnaire;
        }

        // PUT: api/Concessionnaires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcessionnaire(int id, Concessionnaire concessionnaire)
        {
            if (id != concessionnaire.IdConcessionnaire)
            {
                return BadRequest();
            }

            _context.Entry(concessionnaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcessionnaireExists(id))
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

        // POST: api/Concessionnaires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Concessionnaire>> PostConcessionnaire(Concessionnaire concessionnaire)
        {
          if (_context.Concessionnaires == null)
          {
              return Problem("Entity set 'BMWDBContext.Concessionnaires'  is null.");
          }
            _context.Concessionnaires.Add(concessionnaire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConcessionnaire", new { id = concessionnaire.IdConcessionnaire }, concessionnaire);
        }

        // DELETE: api/Concessionnaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcessionnaire(int id)
        {
            if (_context.Concessionnaires == null)
            {
                return NotFound();
            }
            var concessionnaire = await _context.Concessionnaires.FindAsync(id);
            if (concessionnaire == null)
            {
                return NotFound();
            }

            _context.Concessionnaires.Remove(concessionnaire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConcessionnaireExists(int id)
        {
            return (_context.Concessionnaires?.Any(e => e.IdConcessionnaire == id)).GetValueOrDefault();
        }
    }
}
