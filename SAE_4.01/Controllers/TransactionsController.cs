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
    public class TransactionsController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Transaction> dataRepository;

        public TransactionsController(IDataRepository<Transaction> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {

            var transaction = await dataRepository.GetByIdAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
        {
            if (id != transaction.IdTransaction)
            {
                return BadRequest();
            }

            var tctToUpdate = await dataRepository.GetByIdAsync(id);

            if (tctToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(tctToUpdate.Value, transaction);
                return NoContent();
            }
        }

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {
            if (transaction == null)
            {
                return Problem("Entity set 'BMWDBContext.Transactions'  is null.");
            }
            await dataRepository.AddAsync(transaction);

            return CreatedAtAction("GetTransaction", new { id = transaction.IdTransaction }, transaction);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await dataRepository.GetByIdAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(transaction.Value);

            return NoContent();
        }

        private bool TransactionExists(int id)
        {
            return (_context.Transactions?.Any(e => e.IdTransaction == id)).GetValueOrDefault();
        }
    }
}
