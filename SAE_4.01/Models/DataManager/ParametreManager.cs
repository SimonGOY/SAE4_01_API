using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class ParametreManager : IDataRepository<Parametre>
    {
        readonly BMWDBContext _dbContext;

        public ParametreManager() { }

        public ParametreManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Parametre>>> GetAllAsync()
        {
            return await _dbContext.Parametres.ToListAsync();
        }

        public async Task<ActionResult<Parametre>> GetByNomAsync(string nom)
        {
            return await _dbContext.Parametres.FirstOrDefaultAsync(p => p.NomParametre == nom);
        }

        public async Task AddAsync(Parametre entity)
        {
            await _dbContext.Parametres.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Parametre par, Parametre entity)
        {
            _dbContext.Entry(par).State = EntityState.Modified;
            par.NomParametre = entity.NomParametre;
            par.Description = entity.Description;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Parametre par)
        {
            _dbContext.Parametres.Remove(par);
            await _dbContext.SaveChangesAsync();
        }

        public Task<ActionResult<Parametre>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametre>>> IDataRepository<Parametre>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametre>>> IDataRepository<Parametre>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametre>>> IDataRepository<Parametre>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametre>>> IDataRepository<Parametre>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametre>>> IDataRepository<Parametre>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametre>>> IDataRepository<Parametre>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametre>>> IDataRepository<Parametre>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametre>>> IDataRepository<Parametre>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametre>>> IDataRepository<Parametre>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametre>>> IDataRepository<Parametre>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametre>>> IDataRepository<Parametre>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Parametre>>> IDataRepository<Parametre>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Parametre>> IDataRepository<Parametre>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Parametre>> IDataRepository<Parametre>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Parametre>> IDataRepository<Parametre>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }
    }
}
