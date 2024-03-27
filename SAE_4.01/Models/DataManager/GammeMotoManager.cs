using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace SAE_4._01.Models.DataManager
{
    public class GammeMotoManager : IDataRepository<GammeMoto>
    {
        readonly BMWDBContext _dbContext;

        public GammeMotoManager() { }

        public GammeMotoManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<GammeMoto>>> GetAllAsync()
        {
            return await _dbContext.GammeMotos.ToListAsync();
        }

        public async Task<ActionResult<GammeMoto>> GetByIdAsync(int id)
        {
            return await _dbContext.GammeMotos.FirstOrDefaultAsync(p => p.IdGamme == id);
        }

        public async Task AddAsync(GammeMoto entity)
        {
            await _dbContext.GammeMotos.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(GammeMoto gam, GammeMoto entity)
        {
            _dbContext.Entry(gam).State = EntityState.Modified;
            gam.IdGamme = entity.IdGamme;
            gam.LibelleGamme = entity.LibelleGamme;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(GammeMoto gam)
        {
            _dbContext.GammeMotos.Remove(gam);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<GammeMoto>>> IDataRepository<GammeMoto>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<GammeMoto>>> IDataRepository<GammeMoto>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<GammeMoto>>> IDataRepository<GammeMoto>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<GammeMoto>>> IDataRepository<GammeMoto>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<GammeMoto>>> IDataRepository<GammeMoto>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<GammeMoto>>> IDataRepository<GammeMoto>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<GammeMoto>>> IDataRepository<GammeMoto>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<GammeMoto>>> IDataRepository<GammeMoto>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<GammeMoto>>> IDataRepository<GammeMoto>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<GammeMoto>>> IDataRepository<GammeMoto>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<GammeMoto>>> IDataRepository<GammeMoto>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<GammeMoto>>> IDataRepository<GammeMoto>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<GammeMoto>> IDataRepository<GammeMoto>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<GammeMoto>> IDataRepository<GammeMoto>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<GammeMoto>> IDataRepository<GammeMoto>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<GammeMoto>> IDataRepository<GammeMoto>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
