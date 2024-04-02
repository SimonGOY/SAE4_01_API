using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_4._01.Models.DataManager;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;

namespace SAE_4._01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaEquipementController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<MediaEquipement> dataRepository;

        public MediaEquipementController(IDataRepository<MediaEquipement> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Media/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaEquipement>> GetMedia(int id)
        {

            var media = await dataRepository.GetByIdAsync(id);

            if (media == null)
            {
                return NotFound();
            }

            return media;
        }


        [HttpGet("idequipement/{id}")]
        public async Task<ActionResult<IEnumerable<MediaEquipement>>> GetByIdEquipement(int id)
        {
            var contenuCommande = await dataRepository.GetByIdEquipementAsync(id);

            if (contenuCommande == null || !contenuCommande.Value.Any())
            {
                return NotFound();
            }

            return Ok(contenuCommande);
        }


        // PUT: api/Media/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedia(int id, MediaEquipement media)
        {
            if (id != media.IdMediaEquipement)
            {
                return BadRequest();
            }

            var medToUpdate = await dataRepository.GetByIdAsync(id);

            if (medToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(medToUpdate.Value, media);
                return NoContent();
            }
        }

        // POST: api/Media
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MediaEquipement>> PostMedia(MediaEquipement media)
        {
            if (media == null)
            {
                return Problem("Entity set 'BMWDBContext.Medias'  is null.");
            }
            await dataRepository.AddAsync(media);

            return CreatedAtAction("GetMedia", new { id = media.IdMediaEquipement }, media);
        }

        // DELETE: api/Media/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedia(int id)
        {
            var media = await dataRepository.GetByIdAsync(id);

            if (media == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(media.Value);

            return NoContent();
        }

        private bool MediaExists(int id)
        {
            return (_context.MediasEquipement?.Any(e => e.IdMediaEquipement == id)).GetValueOrDefault();
        }
    }
}
