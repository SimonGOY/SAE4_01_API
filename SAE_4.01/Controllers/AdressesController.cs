using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
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
    public class AdressesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Adresse> dataRepository;

        public AdressesController(IDataRepository<Adresse> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Adresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adresse>>> GetAdresses()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Adresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adresse>> GetAdresse(int id)
        {

            var adresse = await dataRepository.GetByIdAsync(id);

            if (adresse == null)
            {
                return NotFound();
            }

            return adresse;
        }

        // PUT: api/Adresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdresse(int id, Adresse adresse)
        {
            if (id != adresse.NumAdresse)
            {
                return BadRequest();
            }

            var adrToUpdate = await dataRepository.GetByIdAsync(id);

            if (adrToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(adrToUpdate.Value, adresse);
                return NoContent();
            }
        }

        // POST: api/Adresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adresse>> PostAdresse(AdressePostRequest adressePostRequest)
        {
            if (adressePostRequest.NumAdresse == null)
            {
                adressePostRequest.NumAdresse = GetMaxId().Result.Value + 1;
            }

            /*if (adresse == null)
            {
                return Problem("Entity set 'BMWDBContext.Adresses'  is null.");
            }*/

            Adresse adresse = new Adresse
            {
                NumAdresse = (int)adressePostRequest.NumAdresse,
                NomPays = adressePostRequest.NomPays,
                AdresseAdresse = adressePostRequest.AdresseAdresse,
                PaysAdresse = adressePostRequest.PaysAdresse
            };

            await dataRepository.AddAsync(adresse);

            return CreatedAtAction("GetAdresse", new { id = adresse.NumAdresse }, adresse);
        }

        // DELETE: api/Adresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdresse(int id)
        {
            var adresse = await dataRepository.GetByIdAsync(id);

            if (adresse == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(adresse.Value);

            return NoContent();
        }

        private bool AdresseExists(int id)
        {
            return (_context.Adresses?.Any(e => e.NumAdresse == id)).GetValueOrDefault();
        }

        private async Task<ActionResult<int>> GetMaxId()
        {
            ActionResult<IEnumerable<Adresse>> actionResult = await dataRepository.GetAllAsync();

            IEnumerable<Adresse> adresses = actionResult.Value;

            int max = 0;

            foreach (Adresse adresse in adresses)
            {
                if (adresse.NumAdresse > max)
                {
                    max = (int)adresse.NumAdresse;
                }
            }

            return max;
        }
    }

    public class AdressePostRequest
    {
        public int? NumAdresse { get; set; }

        public string NomPays { get; set; } = null!;

        public string AdresseAdresse { get; set; } = null!;

        public Pays PaysAdresse { get; set; } = null!;
    }
}
