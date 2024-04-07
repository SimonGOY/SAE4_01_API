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
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
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

        // GET: api/Stocks/equipement/5
        [HttpGet("equipement/{id}")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetByEquipementId(int id)
        {
            var stocks = await dataRepository.GetByIdEquipementAsync(id);

            if (stocks == null || !stocks.Value.Any())
            {
                return NotFound();
            }

            return Ok(stocks);
        }

        // GET: api/Stocks/couleur/5
        [HttpGet("coloris/{id}")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetByColorisId(int id)
        {
            var stocks = await dataRepository.GetByIdColorisAsync(id);

            if (stocks == null || !stocks.Value.Any())
            {
                return NotFound();
            }

            return Ok(stocks);
        }


        [HttpGet("{id1}/{id2}/{id3}")]
        public async Task<ActionResult<Stock>> GetByIds(int id1, int id2, int id3)
        {
            var stock = await dataRepository.GetBy3CompositeKeysAsync(id1, id2, id3);

            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }

        // PUT: api/Stocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id1}/{id2}/{id3}")]
        public async Task<IActionResult> PutStock(int id1, int id2, int id3, Stock stock)
        {
            var stkToUpdate = await dataRepository.GetBy3CompositeKeysAsync(id1, id2, id3);

            if (stkToUpdate == null)
            {
                return NotFound();
            }

            // Mettre à jour l'entité existante avec les données de l'entité passée en paramètre
            await dataRepository.UpdateAsync(stkToUpdate.Value, stock);
            return NoContent();
        }

        // POST: api/Stocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {
            try
            {
                await dataRepository.AddAsync(stock);
                return CreatedAtAction(nameof(dataRepository.GetBy3CompositeKeysAsync), new { id1 = stock.IdTaille, id2 = stock.IdEquipement , id3 = stock.IdColoris }, stock);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erreur lors de la création de l'entitee : {ex.Message}");
            }
        }

        // DELETE: api/Stocks/5
        [HttpDelete("{id1}/{id2}/{id3}")]
        public async Task<IActionResult> DeleteStock(int id1, int id2, int id3)
        {
            var stock = await dataRepository.GetBy3CompositeKeysAsync(id1, id2, id3);

            if (stock == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(stock.Value);
            return NoContent();
        }

        private bool StockExists(int id)
        {
            return (_context.Stocks?.Any(e => e.IdTaille == id)).GetValueOrDefault();
        }
    }
}
