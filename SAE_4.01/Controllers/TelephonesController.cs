using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<IEnumerable<Telephone>>> GetTelephones()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Telephones/5
        [HttpGet("{id}")]
        [Authorize(Policy = Policies.Type0)]
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
        [Authorize(Policy = Policies.Type0)]
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


        // POST: api/Telephones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<Telephone>> PostTelephone(TelephonePostRequest telephonePostRequest)
        {
            if (telephonePostRequest.Id == null)
            {
                telephonePostRequest.Id = GetMaxId().Result.Value + 1;
            }

            /*if (telephone == null)
            {
                return Problem("Entity set 'BMWDBContext.Telephones'  is null.");
            }*/

            Telephone telephone = new Telephone
            {
                Id = (int)telephonePostRequest.Id,
                IdClient = telephonePostRequest.IdClient,
                NumTelephone = telephonePostRequest.NumTelephone,
                Type = telephonePostRequest.Type,
                Fonction = telephonePostRequest.Fonction
                //ClientTelephone = new Client()
            };

            await dataRepository.AddAsync(telephone);

            return CreatedAtAction("GetTelephone", new { id = telephone.Id }, telephone);
        }

        // DELETE: api/Telephones/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type0)]
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
                    max = (int)telephone.Id;
                }
            }

            return max;
        }
    }

    public class TelephonePostRequest
    {
        public int? Id { get; set; }

        public int IdClient { get; set; }

        public string NumTelephone { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Fonction { get; set; } = null!;
    }

}