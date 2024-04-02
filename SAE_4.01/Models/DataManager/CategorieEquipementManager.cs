using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class CategorieEquipementManager : IDataRepository<CategorieEquipement>
    {
        readonly BMWDBContext _dbContext;

        public CategorieEquipementManager() { }

        public CategorieEquipementManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<CategorieEquipement>>> GetAllAsync()
        {
            return await _dbContext.CategorieEquipements.ToListAsync();
        }

        public async Task<ActionResult<CategorieEquipement>> GetByIdAsync(int id)
        {
            return await _dbContext.CategorieEquipements.FirstOrDefaultAsync(p => p.IdCatEquipement == id);
        }

        public async Task AddAsync(CategorieEquipement entity)
        {
            await _dbContext.CategorieEquipements.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategorieEquipement ctc, CategorieEquipement entity)
        {
            _dbContext.Entry(ctc).State = EntityState.Modified;
            ctc.IdCatEquipement = entity.IdCatEquipement;
            ctc.LibelleCatEquipement = entity.LibelleCatEquipement;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(CategorieEquipement ctc)
        {
            _dbContext.CategorieEquipements.Remove(ctc);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<CategorieEquipement>>> IDataRepository<CategorieEquipement>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieEquipement>>> IDataRepository<CategorieEquipement>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieEquipement>>> IDataRepository<CategorieEquipement>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieEquipement>>> IDataRepository<CategorieEquipement>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieEquipement>>> IDataRepository<CategorieEquipement>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieEquipement>>> IDataRepository<CategorieEquipement>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieEquipement>>> IDataRepository<CategorieEquipement>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieEquipement>>> IDataRepository<CategorieEquipement>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieEquipement>>> IDataRepository<CategorieEquipement>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieEquipement>>> IDataRepository<CategorieEquipement>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieEquipement>>> IDataRepository<CategorieEquipement>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<CategorieEquipement>>> IDataRepository<CategorieEquipement>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<CategorieEquipement>> IDataRepository<CategorieEquipement>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<CategorieEquipement>> IDataRepository<CategorieEquipement>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<CategorieEquipement>> IDataRepository<CategorieEquipement>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<CategorieEquipement>> IDataRepository<CategorieEquipement>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<CategorieEquipement>> GetReference(int id)
        {
            throw new NotImplementedException();
        }
    }
}
