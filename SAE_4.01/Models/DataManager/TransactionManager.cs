using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class TransactionManager : IDataRepository<Transaction>
    {
        readonly BMWDBContext _dbContext;

        public TransactionManager() { }

        public TransactionManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Transaction>>> GetAllAsync()
        {
            return await _dbContext.Transactions.ToListAsync();
        }

        public async Task<ActionResult<Transaction>> GetByIdAsync(int id)
        {
            return await _dbContext.Transactions.FirstOrDefaultAsync(p => p.IdTransaction == id);
        }

        public async Task AddAsync(Transaction entity)
        {
            await _dbContext.Transactions.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction tra, Transaction entity)
        {
            _dbContext.Entry(tra).State = EntityState.Modified;
            tra.IdTransaction = entity.IdTransaction;
            tra.IdCommande = entity.IdCommande;
            tra.Type = entity.Type;
            tra.Montant = entity.Montant;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Transaction tra)
        {
            _dbContext.Transactions.Remove(tra);
            await _dbContext.SaveChangesAsync();
        }
    }
}
