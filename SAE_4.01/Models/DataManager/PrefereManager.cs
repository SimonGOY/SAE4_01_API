using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class PrefereManager : IDataRepository<Prefere>
    {
        readonly BMWDBContext _dbContext;

        public PrefereManager() { }

        public PrefereManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Prefere>>> GetAllAsync()
        {
            return await _dbContext.Preferes.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Prefere>>> GetByIdClientAsync(int id)
        {
            return await _dbContext.Preferes.Where(p => p.IdClient == id).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Prefere>>> GetByIdConcessionnaireAsync(int id)
        {
            return await _dbContext.Preferes.Where(p => p.IdConcessionnaire == id).ToListAsync();
        }

        public async Task<ActionResult<Prefere>> GetBy2CompositeKeysAsync(int id1, int id2)
        {
            return await _dbContext.Preferes.FirstOrDefaultAsync(e => e.IdClient == id1 && e.IdConcessionnaire == id2);
        }

        public async Task AddAsync(Prefere entity)
        {
            await _dbContext.Preferes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Prefere pre, Prefere entity)
        {
            _dbContext.Entry(pre).State = EntityState.Modified;
            pre.IdClient = entity.IdClient;
            pre.IdConcessionnaire = entity.IdConcessionnaire;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Prefere pre)
        {
            _dbContext.Preferes.Remove(pre);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<Prefere>> IDataRepository<Prefere>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prefere>>> IDataRepository<Prefere>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prefere>>> IDataRepository<Prefere>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prefere>>> IDataRepository<Prefere>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prefere>>> IDataRepository<Prefere>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prefere>>> IDataRepository<Prefere>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prefere>>> IDataRepository<Prefere>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prefere>>> IDataRepository<Prefere>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prefere>>> IDataRepository<Prefere>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prefere>>> IDataRepository<Prefere>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Prefere>>> IDataRepository<Prefere>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Prefere>> IDataRepository<Prefere>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Prefere>> IDataRepository<Prefere>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Prefere>> IDataRepository<Prefere>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
