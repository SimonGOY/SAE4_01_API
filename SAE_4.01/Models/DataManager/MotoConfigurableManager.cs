using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace SAE_4._01.Models.DataManager
{
    public class MotoConfigurableManager : IDataRepository<MotoConfigurable>
    {
        readonly BMWDBContext _dbContext;

        public MotoConfigurableManager() { }

        public MotoConfigurableManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<MotoConfigurable>>> GetAllAsync()
        {
            return await _dbContext.MotoConfigurables.ToListAsync();
        }

        public async Task<ActionResult<MotoConfigurable>> GetByIdAsync(int id)
        {
            return await _dbContext.MotoConfigurables.FirstOrDefaultAsync(p => p.IdMotoConfigurable == id);
        }

        public async Task AddAsync(MotoConfigurable entity)
        {
            await _dbContext.MotoConfigurables.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(MotoConfigurable mcf, MotoConfigurable entity)
        {
            _dbContext.Entry(mcf).State = EntityState.Modified;
            mcf.IdMotoConfigurable = entity.IdMotoConfigurable;
            mcf.IdMoto = entity.IdMoto;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MotoConfigurable mcf)
        {
            _dbContext.MotoConfigurables.Remove(mcf);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<MotoConfigurable>>> IDataRepository<MotoConfigurable>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MotoConfigurable>>> IDataRepository<MotoConfigurable>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MotoConfigurable>>> IDataRepository<MotoConfigurable>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MotoConfigurable>>> IDataRepository<MotoConfigurable>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MotoConfigurable>>> IDataRepository<MotoConfigurable>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MotoConfigurable>>> IDataRepository<MotoConfigurable>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MotoConfigurable>>> IDataRepository<MotoConfigurable>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MotoConfigurable>>> IDataRepository<MotoConfigurable>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MotoConfigurable>>> IDataRepository<MotoConfigurable>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MotoConfigurable>>> IDataRepository<MotoConfigurable>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MotoConfigurable>>> IDataRepository<MotoConfigurable>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MotoConfigurable>>> IDataRepository<MotoConfigurable>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<MotoConfigurable>> IDataRepository<MotoConfigurable>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<MotoConfigurable>> IDataRepository<MotoConfigurable>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<MotoConfigurable>> IDataRepository<MotoConfigurable>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }
    }
}
