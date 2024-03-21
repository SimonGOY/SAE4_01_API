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
    public class SpecifiesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Specifie> dataRepository;

        public SpecifiesController(IDataRepository<Specifie> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Specifies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specifie>>> GetSpecifies()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Specifies/option/5
        [HttpGet("option/{id}")]
        public async Task<ActionResult<IEnumerable<Specifie>>> GetByIdOption(int id)
        {
          var specifies = await dataRepository.GetByIdOptionAsync(id);

            if (specifies == null || !specifies.Value.Any())
            {
                return NotFound();
            }

            return Ok(specifies);
        }

        // GET: api/Specifies/modelmoto/5
        [HttpGet("modelmoto/{id}")]
        public async Task<ActionResult<IEnumerable<Specifie>>> GetByIdMoto(int id)
        {
            var specifies = await dataRepository.GetByIdMotoAsync(id);

            if (specifies == null || !specifies.Value.Any())
            {
                return NotFound();
            }

            return Ok(specifies);
        }

        // PUT: api/Specifies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecifie(int id, Specifie specifie)
        {
            if (id != specifie.IdMoto)
            {
                return BadRequest();
            }

            _context.Entry(specifie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecifieExists(id))
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

        // POST: api/Specifies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Specifie>> PostSpecifie(Specifie specifie)
        {
          if (_context.Specifies == null)
          {
              return Problem("Entity set 'BMWDBContext.Specifies'  is null.");
          }
            _context.Specifies.Add(specifie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpecifieExists(specifie.IdMoto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSpecifie", new { id = specifie.IdMoto }, specifie);
        }

        // DELETE: api/Specifies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecifie(int id)
        {
            if (_context.Specifies == null)
            {
                return NotFound();
            }
            var specifie = await _context.Specifies.FindAsync(id);
            if (specifie == null)
            {
                return NotFound();
            }

            _context.Specifies.Remove(specifie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecifieExists(int id)
        {
            return (_context.Specifies?.Any(e => e.IdMoto == id)).GetValueOrDefault();
        }
    }
}
