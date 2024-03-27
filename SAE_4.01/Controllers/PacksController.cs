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
    public class PacksController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Pack> dataRepository;

        public PacksController(IDataRepository<Pack> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Packs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pack>>> GetPacks()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Packs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pack>> GetPack(int id)
        {

            var pack = await dataRepository.GetByIdAsync(id);

            if (pack == null)
            {
                return NotFound();
            }

            return pack;
        }

        [HttpGet("idmoto/{id}")]
        public async Task<ActionResult<IEnumerable<Pack>>> GetCouleurByIdMoto(int id)
        {

            var couleur = await dataRepository.GetByIdMotoAsync(id);

            if (couleur == null)
            {
                return NotFound();
            }

            return couleur;
        }

        // PUT: api/Packs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPack(int id, Pack pack)
        {
            if (id != pack.IdPack)
            {
                return BadRequest();
            }

            _context.Entry(pack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackExists(id))
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

        // POST: api/Packs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pack>> PostPack(Pack pack)
        {
          if (_context.Packs == null)
          {
              return Problem("Entity set 'BMWDBContext.Packs'  is null.");
          }
            _context.Packs.Add(pack);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPack", new { id = pack.IdPack }, pack);
        }

        // DELETE: api/Packs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePack(int id)
        {
            if (_context.Packs == null)
            {
                return NotFound();
            }
            var pack = await _context.Packs.FindAsync(id);
            if (pack == null)
            {
                return NotFound();
            }

            _context.Packs.Remove(pack);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackExists(int id)
        {
            return (_context.Packs?.Any(e => e.IdPack == id)).GetValueOrDefault();
        }
    }
}
