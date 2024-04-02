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
    public class MediaMotoController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<MediaMoto> dataRepository;

        public MediaMotoController(IDataRepository<MediaMoto> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/MediaMoto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaMoto>>> GetContenuCommandes()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/MediaMoto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaMoto>> GetMedia(int id)
        {

            var media = await dataRepository.GetByIdAsync(id);

            if (media == null)
            {
                return NotFound();
            }

            return media;
        }


        [HttpGet("idmoto/{id}")]
        public async Task<ActionResult<IEnumerable<MediaMoto>>> GetByIdMoto(int id)
        {
            var moto = await dataRepository.GetByIdMotoAsync(id);

            if (moto == null || !moto.Value.Any())
            {
                return NotFound();
            }

            return Ok(moto);
        }

        [HttpGet("reference/{id}")]
        public async Task<ActionResult<MediaMoto>> GetReference(int id)
        {
            var media = await dataRepository.GetReference(id);

            if (media == null)
            {
                return NotFound();
            }

            return media;
        }


        // PUT: api/MediaMoto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedia(int id, MediaMoto media)
        {
            if (id != media.IdMediaMoto)
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

        // POST: api/MediaMoto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MediaMoto>> PostMedia(MediaMoto media)
        {
            if (media == null)
            {
                return Problem("Entity set 'BMWDBContext.Medias'  is null.");
            }
            await dataRepository.AddAsync(media);

            return CreatedAtAction("GetMedia", new { id = media.IdMediaMoto }, media);
        }

        // DELETE: api/MediaMoto/5
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
            return (_context.MediasMoto?.Any(e => e.IdMediaMoto == id)).GetValueOrDefault();
        }
    }
}
