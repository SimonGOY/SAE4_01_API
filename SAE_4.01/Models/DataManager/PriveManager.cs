using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class PriveManager : IDataRepository<Prive>
    {
        readonly BMWDBContext _dbContext;

        public PriveManager() { }

        public PriveManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Prive>>> GetAllAsync()
        {
            return await _dbContext.Prives.ToListAsync();
        }

        public async Task<ActionResult<Prive>> GetByIdAsync(int id)
        {
            return await _dbContext.Prives.FirstOrDefaultAsync(p => p.IdPrive == id);
        }

        public async Task AddAsync(Prive entity)
        {
            await _dbContext.Prives.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Prive pri, Prive entity)
        {
            _dbContext.Entry(pri).State = EntityState.Modified;
            pri.IdPrive = entity.IdPrive;
            pri.IdClient = entity.IdClient;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Prive pri)
        {
            _dbContext.Prives.Remove(pri);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Prive>>> IDataRepository<Prive>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prive>>> IDataRepository<Prive>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prive>>> IDataRepository<Prive>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prive>>> IDataRepository<Prive>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prive>>> IDataRepository<Prive>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prive>>> IDataRepository<Prive>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prive>>> IDataRepository<Prive>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prive>>> IDataRepository<Prive>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prive>>> IDataRepository<Prive>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prive>>> IDataRepository<Prive>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prive>>> IDataRepository<Prive>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prive>>> IDataRepository<Prive>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Prive>> IDataRepository<Prive>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Prive>> IDataRepository<Prive>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Prive>> IDataRepository<Prive>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }
    }
}
