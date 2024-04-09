using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
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
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> PutModeleMoto(int id, ModeleMoto modeleMoto)
        {
            if (id != modeleMoto.IdMoto)
            {
                return BadRequest();
            }

            var modToUpdate = await dataRepository.GetByIdAsync(id);

            if (modToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(modToUpdate.Value, modeleMoto);
                return NoContent();
            }
        }

        // POST: api/ModeleMotos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<ModeleMoto>> PostModeleMoto(ModeleMoto modeleMoto)
        {
            if (modeleMoto == null)
            {
                return Problem("Entity set 'BMWDBContext.ModelMotos'  is null.");
            }
            await dataRepository.AddAsync(modeleMoto);

            return CreatedAtAction("GetMoto", new { id = modeleMoto.IdMoto }, modeleMoto);
        }

        // DELETE: api/ModeleMotos/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteModeleMoto(int id)
        {
            var modeleMoto = await dataRepository.GetByIdAsync(id);

            if (modeleMoto == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(modeleMoto.Value);

            return NoContent();
        }

        private bool ModeleMotoExists(int id)
        {
            return (_context.ModeleMotos?.Any(e => e.IdMoto == id)).GetValueOrDefault();
        }
    }
}
