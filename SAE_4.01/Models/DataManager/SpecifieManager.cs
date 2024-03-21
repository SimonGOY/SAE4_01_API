using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace SAE_4._01.Models.DataManager
{
    public class SpecifieManager : IDataRepository<Specifie>
    {
        readonly BMWDBContext _dbContext;

        public SpecifieManager() { }

        public SpecifieManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Specifie>>> GetAllAsync()
        {
            return await _dbContext.Specifies.ToListAsync();
        }

        public async Task<ActionResult<Specifie>> GetByIdAsync(int id)
        {
            return await _dbContext.Specifies.FirstOrDefaultAsync(p => p.IdOption == id);
        }

        public async Task AddAsync(Specifie entity)
        {
            await _dbContext.Specifies.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Specifie spe, Specifie entity)
        {
            _dbContext.Entry(spe).State = EntityState.Modified;
            spe.IdOption = entity.IdOption;
            spe.IdMoto = entity.IdMoto;
            spe.OptionSpecifie = entity.OptionSpecifie;
            spe.ModeleMotoSpecifie = entity.ModeleMotoSpecifie;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Specifie spe)
        {
            _dbContext.Specifies.Remove(spe);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<Stock>> IDataRepository<Specifie>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Stock>> IDataRepository<Specifie>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
