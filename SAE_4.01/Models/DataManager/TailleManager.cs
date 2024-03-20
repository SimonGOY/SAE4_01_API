using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class TailleManager : IDataRepository<Taille>
    {
        readonly BMWDBContext _dbContext;

        public TailleManager() { }

        public TailleManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Taille>>> GetAllAsync()
        {
            return await _dbContext.Tailles.ToListAsync();
        }

        public async Task<ActionResult<Taille>> GetByIdAsync(int id)
        {
            return await _dbContext.Tailles.FirstOrDefaultAsync(p => p.IdTaille == id);
        }

        public async Task AddAsync(Taille entity)
        {
            await _dbContext.Tailles.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Taille tai, Taille entity)
        {
            _dbContext.Entry(tai).State = EntityState.Modified;
            tai.IdTaille = entity.IdTaille;
            tai.LibelleTaille = entity.LibelleTaille;
            tai.DescTaille = entity.DescTaille;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Taille use)
        {
            _dbContext.Tailles.Remove(use);
            await _dbContext.SaveChangesAsync();
        }
    }
}
