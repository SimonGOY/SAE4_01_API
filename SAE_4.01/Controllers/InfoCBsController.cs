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

            _context.Entry(infoCB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoCBExists(id))
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

        // POST: api/InfoCBs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoCB>> PostInfoCB(InfoCB infoCB)
        {
          if (_context.InfoCBs == null)
          {
              return Problem("Entity set 'BMWDBContext.InfoCBs'  is null.");
          }
            _context.InfoCBs.Add(infoCB);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoCB", new { id = infoCB.IdCarte }, infoCB);
        }

        // DELETE: api/InfoCBs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoCB(int id)
        {
            if (_context.InfoCBs == null)
            {
                return NotFound();
            }
            var infoCB = await _context.InfoCBs.FindAsync(id);
            if (infoCB == null)
            {
                return NotFound();
            }

            _context.InfoCBs.Remove(infoCB);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfoCBExists(int id)
        {
            return (_context.InfoCBs?.Any(e => e.IdCarte == id)).GetValueOrDefault();
        }
    }
}
