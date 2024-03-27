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
    public class EquipementsController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Equipement> dataRepository;

        public EquipementsController(IDataRepository<Equipement> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Equipements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipement>>> GetEquipements()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Equipements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipement>> GetEquipement(int id)
        {

            var equipement = await dataRepository.GetByIdAsync(id);

            if (equipement == null)
            {
                return NotFound();
            }

            return equipement;
        }

        // PUT: api/Equipements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipement(int id, Equipement equipement)
        {
            if (id != equipement.IdEquipement)
            {
                return BadRequest();
            }

            var equToUpdate = await dataRepository.GetByIdAsync(id);

            if (equToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(equToUpdate.Value, equipement);
                return NoContent();
            }
        }

        // POST: api/Equipements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipement>> PostEquipement(Equipement equipement)
        {
            if (equipement == null)
            {
                return Problem("Entity set 'BMWDBContext.Equipements'  is null.");
            }
            await dataRepository.AddAsync(equipement);

            return CreatedAtAction("GetEquipement", new { id = equipement.IdEquipement }, equipement);
        }

        // DELETE: api/Equipements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipement(int id)
        {
            var equipement = await dataRepository.GetByIdAsync(id);

            if (equipement == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(equipement.Value);

            return NoContent();
        }

        private bool EquipementExists(int id)
        {
            return (_context.Equipements?.Any(e => e.IdEquipement == id)).GetValueOrDefault();
        }
    }
}
