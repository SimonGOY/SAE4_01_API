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

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<CategorieEquipement>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<CategorieEquipement>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
