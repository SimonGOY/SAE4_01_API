using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
    public class PaysController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Pays> dataRepository;

        public PaysController(IDataRepository<Pays> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Pays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pays>>> GetLesPays()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Pays/5
        [HttpGet("{nom}")]
        public async Task<ActionResult<Pays>> GetPays(string nom)
        {

            var pays = await dataRepository.GetByNomAsync(nom);

            if (pays == null)
            {
                return NotFound();
            }

            return pays;
        }

        // PUT: api/Pays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{nom}")]
        public async Task<IActionResult> PutPays(string nom, Pays pays)
        {
            if (nom != pays.NomPays)
            {
                return BadRequest();
            }

            var payToUpdate = await dataRepository.GetByNomAsync(nom);

            if (payToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(payToUpdate.Value, pays);
                return NoContent();
            }
        }

        // POST: api/Pays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pays>> PostPays(Pays pays)
        {
            if (pays == null)
            {
                return Problem("Entity set 'BMWDBContext.LesPays'  is null.");
            }
            await dataRepository.AddAsync(pays);

            return CreatedAtAction("GetPays", new { nom = pays.NomPays }, pays);
        }


        // DELETE: api/Pays/5
        [HttpDelete("{nom}")]
        public async Task<IActionResult> DeletePays(string nom)
        {
            var pays = await dataRepository.GetByNomAsync(nom);

            if (pays == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(pays.Value);

            return NoContent();
        }

        private bool PaysExists(string nom)
        {
            return (_context.LesPays?.Any(e => e.NomPays == nom)).GetValueOrDefault();
        }
    }
}
