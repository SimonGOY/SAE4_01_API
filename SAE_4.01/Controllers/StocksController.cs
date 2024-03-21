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
    public class StocksController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Stock> dataRepository;

        public StocksController(IDataRepository<Stock> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Stocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetClients()
        {
            return await dataRepository.GetAllAsync();
        }



        // GET: api/Stocks/taille/5
        [HttpGet("taille/{id}")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetByTailleId(int id)
        {
            var stocks = await dataRepository.GetByIdTailleAsync(id);

            if (stocks == null || !stocks.Value.Any())
            {
                return NotFound();
            }

            return Ok(stocks);
        }

        // GET: api/Stocks/couleur/5
        [HttpGet("couleur/{id}")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetByColorisId(int id)
        {
            var stocks = await dataRepository.GetByIdColorisAsync(id);

            if (stocks == null || !stocks.Value.Any())
            {
                return NotFound();
            }

            return Ok(stocks);
        }




        // PUT: api/Stocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, Stock stock)
        {
            if (id != stock.IdTaille)
            {
                return BadRequest();
            }

            _context.Entry(stock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
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

        // POST: api/Stocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {
          if (_context.Stocks == null)
          {
              return Problem("Entity set 'BMWDBContext.Stocks'  is null.");
          }
            _context.Stocks.Add(stock);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StockExists(stock.IdTaille))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStock", new { id = stock.IdTaille }, stock);
        }

        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            if (_context.Stocks == null)
            {
                return NotFound();
            }
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockExists(int id)
        {
            return (_context.Stocks?.Any(e => e.IdTaille == id)).GetValueOrDefault();
        }
    }
}
