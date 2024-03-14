using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_4._01.Models.EntityFramework;

namespace SAE_4._01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContenuCommandesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        public ContenuCommandesController(BMWDBContext context)
        {
            _context = context;
        }

        // GET: api/ContenuCommandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContenuCommande>>> GetContenuCommandes()
        {
          if (_context.ContenuCommandes == null)
          {
              return NotFound();
          }
            return await _context.ContenuCommandes.ToListAsync();
        }

        // GET: api/ContenuCommandes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContenuCommande>> GetContenuCommande(int id)
        {
          if (_context.ContenuCommandes == null)
          {
              return NotFound();
          }
            var contenuCommande = await _context.ContenuCommandes.FindAsync(id);

            if (contenuCommande == null)
            {
                return NotFound();
            }

            return contenuCommande;
        }

        // PUT: api/ContenuCommandes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContenuCommande(int id, ContenuCommande contenuCommande)
        {
            if (id != contenuCommande.IdEquipement)
            {
                return BadRequest();
            }

            _context.Entry(contenuCommande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContenuCommandeExists(id))
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

        // POST: api/ContenuCommandes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContenuCommande>> PostContenuCommande(ContenuCommande contenuCommande)
        {
          if (_context.ContenuCommandes == null)
          {
              return Problem("Entity set 'BMWDBContext.ContenuCommandes'  is null.");
          }
            _context.ContenuCommandes.Add(contenuCommande);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContenuCommandeExists(contenuCommande.IdEquipement))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetContenuCommande", new { id = contenuCommande.IdEquipement }, contenuCommande);
        }

        // DELETE: api/ContenuCommandes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContenuCommande(int id)
        {
            if (_context.ContenuCommandes == null)
            {
                return NotFound();
            }
            var contenuCommande = await _context.ContenuCommandes.FindAsync(id);
            if (contenuCommande == null)
            {
                return NotFound();
            }

            _context.ContenuCommandes.Remove(contenuCommande);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContenuCommandeExists(int id)
        {
            return (_context.ContenuCommandes?.Any(e => e.IdEquipement == id)).GetValueOrDefault();
        }
    }
}
