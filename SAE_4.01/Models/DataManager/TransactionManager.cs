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

        Task<ActionResult<IEnumerable<Transaction>>> IDataRepository<Transaction>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Transaction>>> IDataRepository<Transaction>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Transaction>>> IDataRepository<Transaction>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Transaction>>> IDataRepository<Transaction>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Transaction>>> IDataRepository<Transaction>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Transaction>>> IDataRepository<Transaction>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Transaction>>> IDataRepository<Transaction>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Transaction>>> IDataRepository<Transaction>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Transaction>>> IDataRepository<Transaction>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Transaction>>> IDataRepository<Transaction>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Transaction>>> IDataRepository<Transaction>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Transaction>>> IDataRepository<Transaction>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Transaction>> IDataRepository<Transaction>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Transaction>> IDataRepository<Transaction>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Transaction>> IDataRepository<Transaction>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Transaction>> IDataRepository<Transaction>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Transaction>> GetReference(int id)
        {
            throw new NotImplementedException();
        }
    }
}
