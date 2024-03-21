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
    public class GaragesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Garage> dataRepository;

        public GaragesController(IDataRepository<Garage> dataRepo)
        {
            dataRepository = dataRepo;
        }
        // GET: api/Garages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garage>>> GetGarages()
        {
          if (_context.Garages == null)
          {
              return NotFound();
          }
            return await _context.Garages.ToListAsync();
        }

        // GET: api/Garage/motoconfigurable/5
        [HttpGet("motoconfigurable/{id}")]
        public async Task<ActionResult<IEnumerable<Garage>>> GetByIdMotoConfigurable(int id)
        {
            var garages = await dataRepository.GetByIdMotoConfigurableAsync(id);

            if (garages == null || !garages.Value.Any())
            {
                return NotFound();
            }

            return Ok(garages);
        }

        // GET: api/Garage/client/5
        [HttpGet("client/{id}")]
        public async Task<ActionResult<IEnumerable<Garage>>> GetByIdClient(int id)
        {
            var garages = await dataRepository.GetByIdClientAsync(id);

            if (garages == null || !garages.Value.Any())
            {
                return NotFound();
            }

            return Ok(garages);
        }

        // PUT: api/Garages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarage(int id, Garage garage)
        {
            if (id != garage.IdMotoConfigurable)
            {
                return BadRequest();
            }

            _context.Entry(garage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarageExists(id))
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

        // POST: api/Garages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Garage>> PostGarage(Garage garage)
        {
          if (_context.Garages == null)
          {
              return Problem("Entity set 'BMWDBContext.Garages'  is null.");
          }
            _context.Garages.Add(garage);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GarageExists(garage.IdMotoConfigurable))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGarage", new { id = garage.IdMotoConfigurable }, garage);
        }

        // DELETE: api/Garages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGarage(int id)
        {
            if (_context.Garages == null)
            {
                return NotFound();
            }
            var garage = await _context.Garages.FindAsync(id);
            if (garage == null)
            {
                return NotFound();
            }

            _context.Garages.Remove(garage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GarageExists(int id)
        {
            return (_context.Garages?.Any(e => e.IdMotoConfigurable == id)).GetValueOrDefault();
        }
    }
}
