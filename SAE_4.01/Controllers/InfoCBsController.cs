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
    public class InfoCBsController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<InfoCB> dataRepository;

        public InfoCBsController(IDataRepository<InfoCB> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/InfoCBs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoCB>>> GetInfoCBs()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/InfoCBs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoCB>> GetInfoCB(int id)
        {

            var infoCB = await dataRepository.GetByIdAsync(id);

            if (infoCB == null)
            {
                return NotFound();
            }

            return infoCB;
        }

        // PUT: api/InfoCBs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoCB(int id, InfoCB infoCB)
        {
            if (id != infoCB.IdCarte)
            {
                return BadRequest();
            }

            var icbToUpdate = await dataRepository.GetByIdAsync(id);

            if (icbToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(icbToUpdate.Value, infoCB);
                return NoContent();
            }
        }

        // POST: api/InfoCBs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoCB>> PostInfoCB(InfoCB infoCB)
        {
            if (infoCB == null)
            {
                return Problem("Entity set 'BMWDBContext.InfoCbs'  is null.");
            }
            await dataRepository.AddAsync(infoCB);

            return CreatedAtAction("GetInfoCB", new { id = infoCB.IdCarte }, infoCB);
        }

        // DELETE: api/InfoCBs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoCB(int id)
        {
            var infoCB = await dataRepository.GetByIdAsync(id);

            if (infoCB == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(infoCB.Value);

            return NoContent();
        }

        private bool InfoCBExists(int id)
        {
            return (_context.InfoCBs?.Any(e => e.IdCarte == id)).GetValueOrDefault();
        }
    }
}
