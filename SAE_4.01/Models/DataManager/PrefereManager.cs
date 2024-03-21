using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class PrefereManager : IDataRepository<Prefere>
    {
        readonly BMWDBContext _dbContext;

        public PrefereManager() { }

        public PrefereManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Prefere>>> GetAllAsync()
        {
            return await _dbContext.Preferes.ToListAsync();
        }

        public async Task<ActionResult<Prefere>> GetByIdAsync(int id)
        {
            return await _dbContext.Preferes.FirstOrDefaultAsync(p => p.IdClient == id);
        }

        public async Task AddAsync(Prefere entity)
        {
            await _dbContext.Preferes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Prefere pre, Prefere entity)
        {
            _dbContext.Entry(pre).State = EntityState.Modified;
            pre.IdClient = entity.IdClient;
            pre.IdConcessionnaire = entity.IdConcessionnaire;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Prefere pre)
        {
            _dbContext.Preferes.Remove(pre);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<Stock>> IDataRepository<Prefere>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Stock>> IDataRepository<Prefere>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
