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
    public class ContactInfoController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<ContactInfo> dataRepository;

        public ContactInfoController(IDataRepository<ContactInfo> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/ContactInfoes
        [HttpGet]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<IEnumerable<ContactInfo>>> GetContactInfos()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/ContactInfoes/5
        [HttpGet("{id}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<ContactInfo>> GetContactInfo(int id)
        {

            var contactInfo = await dataRepository.GetByIdAsync(id);

            if (contactInfo == null)
            {
                return NotFound();
            }

            return contactInfo;
        }

        // PUT: api/ContactInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> PutContactInfo(int id, ContactInfo contactInfo)
        {
            if (id != contactInfo.IdContact)
            {
                return BadRequest();
            }

            var ctfToUpdate = await dataRepository.GetByIdAsync(id);

            if (ctfToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(ctfToUpdate.Value, contactInfo);
                return NoContent();
            }
        }

        // POST: api/ContactInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<ContactInfo>> PostContactInfo(ContactInfo contactInfo)
        {
            if (contactInfo == null)
            {
                return Problem("Entity set 'BMWDBContext.ContactInfos'  is null.");
            }
            await dataRepository.AddAsync(contactInfo);

            return CreatedAtAction("GetContactInfo", new { id = contactInfo.IdContact }, contactInfo);
        }

        // DELETE: api/ContactInfoes/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteContactInfo(int id)
        {
            var contactInfo = await dataRepository.GetByIdAsync(id);

            if (contactInfo == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(contactInfo.Value);

            return NoContent();
        }

        private bool ContactInfoExists(int id)
        {
            return (_context.ContactInfos?.Any(e => e.IdContact == id)).GetValueOrDefault();
        }
    }
}
