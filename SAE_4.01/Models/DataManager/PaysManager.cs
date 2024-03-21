using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class PaysManager : IDataRepository<Pays>
    {
        readonly BMWDBContext _dbContext;

        public PaysManager() { }

        public PaysManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Pays>>> GetAllAsync()
        {
            return await _dbContext.LesPays.ToListAsync();
        }

        public async Task AddAsync(Pays entity)
        {
            await _dbContext.LesPays.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pays pay, Pays entity)
        {
            _dbContext.Entry(pay).State = EntityState.Modified;
            pay.NomPays = entity.NomPays;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pays pay)
        {
            _dbContext.LesPays.Remove(pay);
            await _dbContext.SaveChangesAsync();
        }

        public Task<ActionResult<Pays>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Pays>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Pays>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
