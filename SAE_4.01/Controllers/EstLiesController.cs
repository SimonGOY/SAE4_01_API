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
    public class EstLiesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<EstLie> dataRepository;

        public EstLiesController(IDataRepository<EstLie> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/EstLies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstLie>>> GetSontLies()
        {
          if (_context.SontLies == null)
          {
              return NotFound();
          }
            return await _context.SontLies.ToListAsync();
        }

        // GET: api/EstLie/equipement/5
        [HttpGet("equipement/{id}")]
        public async Task<ActionResult<IEnumerable<EstLie>>> GetByIdEquipement(int id)
        {
            var sontlies = await dataRepository.GetByIdEquipementAsync(id);

            if (sontlies == null || !sontlies.Value.Any())
            {
                return NotFound();
            }

            return Ok(sontlies);
        }

        // GET: api/EstLie/equidequipement/5
        [HttpGet("equidequipement/{id}")]
        public async Task<ActionResult<IEnumerable<EstLie>>> GetByEquIdEquipement(int id)
        {
            var sontlies = await dataRepository.GetByEquIdEquipementAsync(id);

            if (sontlies == null || !sontlies.Value.Any())
            {
                return NotFound();
            }

            return Ok(sontlies);
        }

        // PUT: api/EstLies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstLie(int id, EstLie estLie)
        {
            if (id != estLie.IdEquipement)
            {
                return BadRequest();
            }

            _context.Entry(estLie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstLieExists(id))
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

        // POST: api/EstLies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstLie>> PostEstLie(EstLie estLie)
        {
          if (_context.SontLies == null)
          {
              return Problem("Entity set 'BMWDBContext.SontLies'  is null.");
          }
            _context.SontLies.Add(estLie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstLieExists(estLie.IdEquipement))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEstLie", new { id = estLie.IdEquipement }, estLie);
        }

        // DELETE: api/EstLies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstLie(int id)
        {
            if (_context.SontLies == null)
            {
                return NotFound();
            }
            var estLie = await _context.SontLies.FindAsync(id);
            if (estLie == null)
            {
                return NotFound();
            }

            _context.SontLies.Remove(estLie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstLieExists(int id)
        {
            return (_context.SontLies?.Any(e => e.IdEquipement == id)).GetValueOrDefault();
        }
    }
}
