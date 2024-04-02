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

        Task<ActionResult<IEnumerable<PresentationEquipement>>> IDataRepository<PresentationEquipement>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<PresentationEquipement>>> IDataRepository<PresentationEquipement>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<PresentationEquipement>>> IDataRepository<PresentationEquipement>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<PresentationEquipement>>> IDataRepository<PresentationEquipement>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<PresentationEquipement>>> IDataRepository<PresentationEquipement>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<PresentationEquipement>>> IDataRepository<PresentationEquipement>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<PresentationEquipement>>> IDataRepository<PresentationEquipement>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<PresentationEquipement>>> IDataRepository<PresentationEquipement>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<PresentationEquipement>>> IDataRepository<PresentationEquipement>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<PresentationEquipement>>> IDataRepository<PresentationEquipement>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<PresentationEquipement>>> IDataRepository<PresentationEquipement>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<PresentationEquipement>>> IDataRepository<PresentationEquipement>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<PresentationEquipement>> IDataRepository<PresentationEquipement>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<PresentationEquipement>> IDataRepository<PresentationEquipement>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<PresentationEquipement>> IDataRepository<PresentationEquipement>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<PresentationEquipement>> IDataRepository<PresentationEquipement>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<PresentationEquipement>> GetReference(int id)
        {
            throw new NotImplementedException();
        }
    }
}
