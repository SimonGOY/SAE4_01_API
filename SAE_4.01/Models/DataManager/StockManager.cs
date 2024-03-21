using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class StockManager : IDataRepository<Stock>
    {
        readonly BMWDBContext _dbContext;

        public StockManager() { }

        public StockManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Stock>>> GetAllAsync()
        {
            return await _dbContext.Stocks.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Stock>>> GetByIdEquipementAsync(int id)
        {
            return await _dbContext.Stocks.Where(p => p.IdEquipement == id).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Stock>>> GetByIdTailleAsync(int id)
        {
            return await _dbContext.Stocks.Where(p => p.IdTaille == id).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Stock>>> GetByIdColorisAsync(int id)
        {
            return await _dbContext.Stocks.Where(p => p.IdColoris == id).ToListAsync();
        }

        public async Task AddAsync(Stock entity)
        {
            await _dbContext.Stocks.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Stock sto, Stock entity)
        {
            _dbContext.Entry(sto).State = EntityState.Modified;
            sto.IdEquipement = entity.IdEquipement;
            sto.IdTaille = entity.IdTaille;
            sto.IdColoris = entity.IdColoris;
            sto.Quantite = entity.Quantite;
            sto.TailleStock = entity.TailleStock;
            sto.ColorisStock = entity.ColorisStock;
            sto.EquipementStock = entity.EquipementStock;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Stock sto)
        {
            _dbContext.Stocks.Remove(sto);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<Stock>> IDataRepository<Stock>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Stock>> IDataRepository<Stock>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Stock>> IDataRepository<Stock>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
