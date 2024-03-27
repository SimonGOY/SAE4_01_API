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
        Task<ActionResult<IEnumerable<CategorieCaracteristique>>> IDataRepository<CategorieCaracteristique>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieCaracteristique>>> IDataRepository<CategorieCaracteristique>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieCaracteristique>>> IDataRepository<CategorieCaracteristique>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieCaracteristique>>> IDataRepository<CategorieCaracteristique>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieCaracteristique>>> IDataRepository<CategorieCaracteristique>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieCaracteristique>>> IDataRepository<CategorieCaracteristique>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieCaracteristique>>> IDataRepository<CategorieCaracteristique>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieCaracteristique>>> IDataRepository<CategorieCaracteristique>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieCaracteristique>>> IDataRepository<CategorieCaracteristique>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieCaracteristique>>> IDataRepository<CategorieCaracteristique>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieCaracteristique>>> IDataRepository<CategorieCaracteristique>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieCaracteristique>>> IDataRepository<CategorieCaracteristique>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<CategorieCaracteristique>> IDataRepository<CategorieCaracteristique>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<CategorieCaracteristique>> IDataRepository<CategorieCaracteristique>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<CategorieCaracteristique>> IDataRepository<CategorieCaracteristique>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }
    }
}
