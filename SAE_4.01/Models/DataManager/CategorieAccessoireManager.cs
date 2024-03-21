using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class CategorieAccessoireManager : IDataRepository<CategorieAccessoire>
    {
        readonly BMWDBContext _dbContext;

        public CategorieAccessoireManager() { }

        public CategorieAccessoireManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<CategorieAccessoire>>> GetAllAsync()
        {
            return await _dbContext.CategorieAccessoires.ToListAsync();
        }

        public async Task<ActionResult<CategorieAccessoire>> GetByIdAsync(int id)
        {
            return await _dbContext.CategorieAccessoires.FirstOrDefaultAsync(p => p.IdCatAcc == id);
        }

        public async Task AddAsync(CategorieAccessoire entity)
        {
            await _dbContext.CategorieAccessoires.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategorieAccessoire cat, CategorieAccessoire entity)
        {
            _dbContext.Entry(cat).State = EntityState.Modified;
            cat.IdCatAcc = entity.IdCatAcc;
            cat.NomCatAcc = entity.NomCatAcc;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(CategorieAccessoire cat)
        {
            _dbContext.CategorieAccessoires.Remove(cat);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<Stock>> IDataRepository<CategorieAccessoire>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Stock>> IDataRepository<CategorieAccessoire>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
