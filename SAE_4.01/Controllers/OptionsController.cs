using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;

namespace SAE_4._01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Option> dataRepository;

        public OptionsController(IDataRepository<Option> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Options
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Option>>> GetOptions()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Options/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Option>> GetOption(int id)
        {

            var option = await dataRepository.GetByIdAsync(id);

            if (option == null)
            {
                return NotFound();
            }

            return option;
        }

        // PUT: api/Options/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> PutOption(int id, Option option)
        {
            if (id != option.IdOption)
            {
                return BadRequest();
            }

            var optToUpdate = await dataRepository.GetByIdAsync(id);

            if (optToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(optToUpdate.Value, option);
                return NoContent();
            }
        }

        // POST: api/Options
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<Option>> PostOption(Option option)
        {
            if (option == null)
            {
                return Problem("Entity set 'BMWDBContext.Options'  is null.");
            }
            await dataRepository.AddAsync(option);

            return CreatedAtAction("GetOption", new { id = option.IdOption }, option);
        }

        // DELETE: api/Options/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteOption(int id)
        {
            var option = await dataRepository.GetByIdAsync(id);

            if (option == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(option.Value);

            return NoContent();
        }

        private bool OptionExists(int id)
        {
            return (_context.Options?.Any(e => e.IdOption == id)).GetValueOrDefault();
        }
    }
}
