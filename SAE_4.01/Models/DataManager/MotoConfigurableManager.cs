using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace SAE_4._01.Models.DataManager
{
    public class MotoConfigurableManager : IDataRepository<MotoConfigurable>
    {
        readonly BMWDBContext _dbContext;

        public MotoConfigurableManager() { }

        public MotoConfigurableManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<MotoConfigurable>>> GetAllAsync()
        {
            return await _dbContext.MotoConfigurables.ToListAsync();
        }

        public async Task<ActionResult<MotoConfigurable>> GetByIdAsync(int id)
        {
            return await _dbContext.MotoConfigurables.FirstOrDefaultAsync(p => p.IdMotoConfigurable == id);
        }

        public async Task AddAsync(MotoConfigurable entity)
        {
            await _dbContext.MotoConfigurables.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(MotoConfigurable mcf, MotoConfigurable entity)
        {
            _dbContext.Entry(mcf).State = EntityState.Modified;
            mcf.IdMotoConfigurable = entity.IdMotoConfigurable;
            mcf.IdMoto = entity.IdMoto;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MotoConfigurable mcf)
        {
            _dbContext.MotoConfigurables.Remove(mcf);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<MotoConfigurable>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<MotoConfigurable>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
