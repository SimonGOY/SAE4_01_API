using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class PresentationEquipementManager : IDataRepository<PresentationEquipement>
    {
        readonly BMWDBContext _dbContext;

        public PresentationEquipementManager() { }

        public PresentationEquipementManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<PresentationEquipement>>> GetAllAsync()
        {
            return await _dbContext.PresentationEquipements.ToListAsync();
        }

        public async Task<ActionResult<PresentationEquipement>> GetByIdAsync(int id)
        {
            return await _dbContext.PresentationEquipements.FirstOrDefaultAsync(p => p.IdColoris == id);
        }

        public async Task AddAsync(PresentationEquipement entity)
        {
            await _dbContext.PresentationEquipements.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PresentationEquipement pre, PresentationEquipement entity)
        {
            _dbContext.Entry(pre).State = EntityState.Modified;
            pre.IdPresentation = entity.IdPresentation;
            pre.IdEquipement = entity.IdEquipement;
            pre.IdColoris = entity.IdColoris;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PresentationEquipement pre)
        {
            _dbContext.PresentationEquipements.Remove(pre);
            await _dbContext.SaveChangesAsync();
        }
    }
}
