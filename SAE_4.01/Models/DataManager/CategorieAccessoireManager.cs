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

        Task<ActionResult<IEnumerable<CategorieAccessoire>>> IDataRepository<CategorieAccessoire>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieAccessoire>>> IDataRepository<CategorieAccessoire>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieAccessoire>>> IDataRepository<CategorieAccessoire>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieAccessoire>>> IDataRepository<CategorieAccessoire>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieAccessoire>>> IDataRepository<CategorieAccessoire>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieAccessoire>>> IDataRepository<CategorieAccessoire>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieAccessoire>>> IDataRepository<CategorieAccessoire>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieAccessoire>>> IDataRepository<CategorieAccessoire>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieAccessoire>>> IDataRepository<CategorieAccessoire>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieAccessoire>>> IDataRepository<CategorieAccessoire>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieAccessoire>>> IDataRepository<CategorieAccessoire>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieAccessoire>>> IDataRepository<CategorieAccessoire>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<CategorieAccessoire>> IDataRepository<CategorieAccessoire>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<CategorieAccessoire>> IDataRepository<CategorieAccessoire>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<CategorieAccessoire>> IDataRepository<CategorieAccessoire>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }
    }
}
