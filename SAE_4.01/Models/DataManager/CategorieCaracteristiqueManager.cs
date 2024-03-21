using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class CategorieCaracteristiqueManager : IDataRepository<CategorieCaracteristique>
    {
        readonly BMWDBContext _dbContext;

        public CategorieCaracteristiqueManager() { }

        public CategorieCaracteristiqueManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<CategorieCaracteristique>>> GetAllAsync()
        {
            return await _dbContext.CategorieCaracteristiques.ToListAsync();
        }

        public async Task<ActionResult<CategorieCaracteristique>> GetByIdAsync(int id)
        {
            return await _dbContext.CategorieCaracteristiques.FirstOrDefaultAsync(p => p.IdCatCaracteristique == id);
        }

        public async Task AddAsync(CategorieCaracteristique entity)
        {
            await _dbContext.CategorieCaracteristiques.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategorieCaracteristique ctc, CategorieCaracteristique entity)
        {
            _dbContext.Entry(ctc).State = EntityState.Modified;
            ctc.IdCatCaracteristique = entity.IdCatCaracteristique;
            ctc.NomCatCaracteristique = entity.NomCatCaracteristique;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(CategorieCaracteristique ctc)
        {
            _dbContext.CategorieCaracteristiques.Remove(ctc);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<CategorieCaracteristique>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<CategorieCaracteristique>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
