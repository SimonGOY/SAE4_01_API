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
    public class CollectionsController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Collection> dataRepository;

        public CollectionsController(IDataRepository<Collection> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Collections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Collection>>> GetCollections()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Collections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Collection>> GetCollection(int id)
        {

            var collection = await dataRepository.GetByIdAsync(id);

            if (collection == null)
            {
                return NotFound();
            }

            return collection;
        }

        // PUT: api/Collections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollection(int id, Collection collection)
        {
            if (id != collection.IdCollection)
            {
                return BadRequest();
            }

            var clnToUpdate = await dataRepository.GetByIdAsync(id);

            if (clnToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(clnToUpdate.Value, collection);
                return NoContent();
            }
        }

        // POST: api/Collections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Collection>> PostCollection(Collection collection)
        {
            if (collection == null)
            {
                return Problem("Entity set 'BMWDBContext.Collections'  is null.");
            }
            await dataRepository.AddAsync(collection);

            return CreatedAtAction("GetCollection", new { id = collection.IdCollection }, collection);
        }

        // DELETE: api/Collections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var collection = await dataRepository.GetByIdAsync(id);

            if (collection == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(collection.Value);

            return NoContent();
        }

        private bool CollectionExists(int id)
        {
            return (_context.Collections?.Any(e => e.IdCollection == id)).GetValueOrDefault();
        }
    }
}
