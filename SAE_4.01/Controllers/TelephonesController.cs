using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;

namespace SAE_4._01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelephonesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Telephone> dataRepository;

        public TelephonesController(IDataRepository<Telephone> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Telephones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telephone>>> GetTelephones()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Telephones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Telephone>> GetTelephone(int id)
        {

            var telephone = await dataRepository.GetByIdAsync(id);

            if (telephone == null)
            {
                return NotFound();
            }

            return telephone;
        }

        // PUT: api/Telephones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelephone(int id, Telephone telephone)
        {
            if (id != telephone.Id)
            {
                return BadRequest();
            }

            var telToUpdate = await dataRepository.GetByIdAsync(id);

            if (telToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(telToUpdate.Value, telephone);
                return NoContent();
            }
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Telephone>> PostTelephone([FromBody] Telephone phoneRequest)
        {
            int nextId;
            string type;
            string fonction;

            if (phoneRequest.Id == null)
            {
                nextId = GetMaxId().Result.Value + 1;
            }
            else
                nextId = (int)phoneRequest.Id;

            if (phoneRequest.Type == null)
            {
                type = "Mobile";
            }
            else
                type = phoneRequest.Type;

            if (phoneRequest.Fonction == null)
            {
                fonction = "Privé";
            }
            else
                fonction = phoneRequest.Fonction;

            Telephone telephone = new Telephone
            {
                
                Id = nextId,
                IdClient = phoneRequest.IdClient,
                NumTelephone = phoneRequest.NumTelephone,
                Type = "Mobile",
                Fonction = "Privé",
                ClientTelephone = null
            };


            

            await dataRepository.AddAsync(telephone);

            return CreatedAtAction("GetTelephone", new { id = telephone.Id }, telephone);
        }

        // POST: api/Telephones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<Telephone>> PostTelephone(Telephone telephone)
        {
            if (telephone == null)
            {
                return Problem("Entity set 'BMWDBContext.Telephones'  is null.");
            }
            await dataRepository.AddAsync(telephone);

            return CreatedAtAction("GetTelephone", new { id = telephone.Id }, telephone);
        }*/

        // DELETE: api/Telephones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelephone(int id)
        {
            var telephone = await dataRepository.GetByIdAsync(id);

            if (telephone == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(telephone.Value);

            return NoContent();
        }

        private bool TelephoneExists(int id)
        {
            return (_context.Telephones?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<ActionResult<int>> GetMaxId()
        {
            ActionResult<IEnumerable<Telephone>> actionResult = await dataRepository.GetAllAsync();

            IEnumerable<Telephone> telephones = actionResult.Value;

            int max = 0;

            foreach (Telephone telephone in telephones)
            {
                if (telephone.Id > max)
                {
                    max = telephone.Id;
                }
            }

            return max;
        }
    }

    public class PhonePostRequest
    {
        public int? Id { get; set; }

        public int IdClient { get; set; }

        public string NumTelephone { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Fonction { get; set; } = null!;
    }

}