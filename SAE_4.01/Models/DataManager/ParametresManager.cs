using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class ParametresManager : IDataRepository<Parametres>
    {
        readonly BMWDBContext _dbContext;

        public ParametresManager() { }

        public ParametresManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Parametres>>> GetAllAsync()
        {
            return await _dbContext.Parametres.ToListAsync();
        }

        public async Task<ActionResult<Parametres>> GetByNomAsync(string nom)
        {
            return await _dbContext.Parametres.FirstOrDefaultAsync(p => p.NomParametre == nom);
        }

        public async Task AddAsync(Parametres entity)
        {
            await _dbContext.Parametres.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Parametres par, Parametres entity)
        {
            _dbContext.Entry(par).State = EntityState.Modified;
            par.NomParametre = entity.NomParametre;
            par.Description = entity.Description;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Parametres par)
        {
            _dbContext.Parametres.Remove(par);
            await _dbContext.SaveChangesAsync();
        }

        public Task<ActionResult<Parametres>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametres>>> IDataRepository<Parametres>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametres>>> IDataRepository<Parametres>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametres>>> IDataRepository<Parametres>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametres>>> IDataRepository<Parametres>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametres>>> IDataRepository<Parametres>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametres>>> IDataRepository<Parametres>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametres>>> IDataRepository<Parametres>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametres>>> IDataRepository<Parametres>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametres>>> IDataRepository<Parametres>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametres>>> IDataRepository<Parametres>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametres>>> IDataRepository<Parametres>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametres>>> IDataRepository<Parametres>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Parametres>> IDataRepository<Parametres>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Parametres>> IDataRepository<Parametres>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Parametres>> IDataRepository<Parametres>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }
    }
}
