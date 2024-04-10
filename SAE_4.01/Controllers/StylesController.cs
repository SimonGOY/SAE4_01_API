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
    public class StylesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Style> dataRepository;

        public StylesController(IDataRepository<Style> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Styles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Style>>> GetStyles()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Styles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Style>> GetStyle(int id)
        {

            var style = await dataRepository.GetByIdAsync(id);

            if (style == null)
            {
                return NotFound();
            }

            return style;
        }

        [HttpGet("idmoto/{id}")]
        public async Task<ActionResult<IEnumerable<Style>>> GetStyleByIdMoto(int id)
        {

            var couleur = await dataRepository.GetByIdMotoAsync(id);

            if (couleur == null)
            {
                return NotFound();
            }

            return couleur;
        }

        // PUT: api/Styles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> PutStyle(int id, Style style)
        {
            if (id != style.IdStyle)
            {
                return BadRequest();
            }

            var styToUpdate = await dataRepository.GetByIdAsync(id);

            if (styToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(styToUpdate.Value, style);
                return NoContent();
            }
        }

        // POST: api/Styles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<Style>> PostStyle(Style style)
        {
            if (style == null)
            {
                return Problem("Entity set 'BMWDBContext.Styles'  is null.");
            }
            await dataRepository.AddAsync(style);

            return CreatedAtAction("GetStyle", new { id = style.IdStyle }, style);
        }

        // DELETE: api/Styles/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteStyle(int id)
        {
            var style = await dataRepository.GetByIdAsync(id);

            if (style == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(style.Value);

            return NoContent();
        }

        private bool StyleExists(int id)
        {
            return (_context.Styles?.Any(e => e.IdStyle == id)).GetValueOrDefault();
        }
    }
}
