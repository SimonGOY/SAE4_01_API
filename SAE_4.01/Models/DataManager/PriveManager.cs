using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class PriveManager : IDataRepository<Prive>
    {
        readonly BMWDBContext _dbContext;

        public PriveManager() { }

        public PriveManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Prive>>> GetAllAsync()
        {
            return await _dbContext.Prives.ToListAsync();
        }

        public async Task<ActionResult<Prive>> GetByIdAsync(int id)
        {
            return await _dbContext.Prives.FirstOrDefaultAsync(p => p.IdPrive == id);
        }

        public async Task AddAsync(Prive entity)
        {
            await _dbContext.Prives.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Prive pri, Prive entity)
        {
            _dbContext.Entry(pri).State = EntityState.Modified;
            pri.IdPrive = entity.IdPrive;
            pri.IdClient = entity.IdClient;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Prive pri)
        {
            _dbContext.Prives.Remove(pri);
            await _dbContext.SaveChangesAsync();
        }
    }
}
