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
    public class ModeleMotosController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<ModeleMoto> dataRepository;

        public ModeleMotosController(IDataRepository<ModeleMoto> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/ModeleMotos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeleMoto>>> GetModeleMotos()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/ModeleMotos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModeleMoto>> GetModeleMoto(int id)
        {

            var modeleMoto = await dataRepository.GetByIdAsync(id);

            if (modeleMoto == null)
            {
                return NotFound();
            }

            return modeleMoto;
        }

        // PUT: api/ModeleMotos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModeleMoto(int id, ModeleMoto ModeleMoto)
        {
            if (id != ModeleMoto.IdMoto)
            {
                return BadRequest();
            }

            _context.Entry(ModeleMoto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeleMotoExists(id))
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

        // POST: api/ModeleMotos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModeleMoto>> PostModeleMoto(ModeleMoto ModeleMoto)
        {
            if (_context.ModeleMotos == null)
            {
                return Problem("Entity set 'BMWDBContext.ModeleMotos'  is null.");
            }
            _context.ModeleMotos.Add(ModeleMoto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModeleMoto", new { id = ModeleMoto.IdMoto }, ModeleMoto);
        }

        // DELETE: api/ModeleMotos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModeleMoto(int id)
        {
            if (_context.ModeleMotos == null)
            {
                return NotFound();
            }
            var ModeleMoto = await _context.ModeleMotos.FindAsync(id);
            if (ModeleMoto == null)
            {
                return NotFound();
            }

            _context.ModeleMotos.Remove(ModeleMoto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeleMotoExists(int id)
        {
            return (_context.ModeleMotos?.Any(e => e.IdMoto == id)).GetValueOrDefault();
        }
    }
}
