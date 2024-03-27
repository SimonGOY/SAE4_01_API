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

        public async Task<ActionResult<Stock>> GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            return await _dbContext.Stocks.FirstOrDefaultAsync(e => e.IdEquipement == id1 && e.IdTaille == id2 && e.IdColoris == id3);
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

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Stock>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Stock>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Stock>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Stock>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Stock>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Stock>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Stock>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Stock>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Stock>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Stock>> IDataRepository<Stock>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Stock>> IDataRepository<Stock>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Stock>> IDataRepository<Stock>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
