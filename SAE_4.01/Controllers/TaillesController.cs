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
    public class TaillesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Taille> dataRepository;

        public TaillesController(IDataRepository<Taille> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Tailles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Taille>>> GetTailles()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Tailles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Taille>> GetTaille(int id)
        {

            var taille = await dataRepository.GetByIdAsync(id);

            if (taille == null)
            {
                return NotFound();
            }

            return taille;
        }

        // PUT: api/Tailles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaille(int id, Taille taille)
        {
            if (id != taille.IdTaille)
            {
                return BadRequest();
            }

            var tleToUpdate = await dataRepository.GetByIdAsync(id);

            if (tleToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(tleToUpdate.Value, taille);
                return NoContent();
            }
        }

        // POST: api/Tailles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Taille>> PostTaille(Taille taille)
        {
            if (taille == null)
            {
                return Problem("Entity set 'BMWDBContext.Tailles'  is null.");
            }
            await dataRepository.AddAsync(taille);

            return CreatedAtAction("GetTaille", new { id = taille.IdTaille }, taille);
        }

        // DELETE: api/Tailles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaille(int id)
        {
            var taille = await dataRepository.GetByIdAsync(id);

            if (taille == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(taille.Value);

            return NoContent();
        }

        private bool TailleExists(int id)
        {
            return (_context.Tailles?.Any(e => e.IdTaille == id)).GetValueOrDefault();
        }
    }
}
