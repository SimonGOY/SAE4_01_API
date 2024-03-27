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
    public class AccessoiresController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Accessoire> dataRepository;

        public AccessoiresController(IDataRepository<Accessoire> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Accessoires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accessoire>>> GetAccessoires()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Accessoires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accessoire>> GetAccessoire(int id)
        {

            var accessoire = await dataRepository.GetByIdAsync(id);

            if (accessoire == null)
            {
                return NotFound();
            }

            return accessoire;


        }

        [HttpGet("idmoto/{id}")]
        public async Task<ActionResult<IEnumerable<Accessoire>>> GetCouleurByIdMoto(int id)
        {

            var couleur = await dataRepository.GetByIdMotoAsync(id);

            if (couleur == null)
            {
                return NotFound();
            }

            return couleur;
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

            var accToUpdate = await dataRepository.GetByIdAsync(id);

            if (accToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(accToUpdate.Value, accessoire);
                return NoContent();
            }
        }

        // POST: api/Accessoires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Accessoire>> PostAccessoire(Accessoire accessoire)
        {

            if (accessoire == null)
            {
                return Problem("Entity set 'BMWDBContext.Accessoires'  is null.");
            }
            await dataRepository.AddAsync(accessoire);

            return CreatedAtAction("GetAccessoire", new { id = accessoire.IdAccessoire }, accessoire);
        }

        // DELETE: api/Accessoires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccessoire(int id)
        {

            var accessoire = await dataRepository.GetByIdAsync(id);

            if (accessoire == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(accessoire.Value);

            return NoContent();
        }

        private bool AccessoireExists(int id)
        {
            return (_context.Accessoires?.Any(e => e.IdAccessoire == id)).GetValueOrDefault();
        }
    }
}
