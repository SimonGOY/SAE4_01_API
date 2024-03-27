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
            return await dataRepository.GetAllAsync();
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
        [HttpPut("{id1}/{id2}")]
        public async Task<IActionResult> PutGarage(int id1, int id2 , Garage garage)
        {
            var grgToUpdate = await dataRepository.GetBy2CompositeKeysAsync(id1, id2);

            if (grgToUpdate == null)
            {
                return NotFound();
            }

            // Mettre à jour l'entité existante avec les données de l'entité passée en paramètre
            await dataRepository.UpdateAsync(grgToUpdate.Value, garage);
            return NoContent();
        }

        // POST: api/Garages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Garage>> PostGarage(Garage garage)
        {
            try
            {
                await dataRepository.AddAsync(garage);
                return CreatedAtAction(nameof(dataRepository.GetBy2CompositeKeysAsync), new { id1 = garage.IdMotoConfigurable, id2 = garage.IdClient }, garage);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur lors de la création de l'entitee : {ex.Message}");
            }
        }

        // DELETE: api/Garages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGarage(int id1, int id2)
        {
            var garage = await dataRepository.GetBy2CompositeKeysAsync(id1, id2);

            if (garage == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(garage.Value);
            return NoContent();
        }

        private bool GarageExists(int id)
        {
            return (_context.Garages?.Any(e => e.IdMotoConfigurable == id)).GetValueOrDefault();
        }
    }
}
