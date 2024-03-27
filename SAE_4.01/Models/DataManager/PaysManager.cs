using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class PaysManager : IDataRepository<Pays>
    {
        readonly BMWDBContext _dbContext;

        public PaysManager() { }

        public PaysManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Pays>>> GetAllAsync()
        {
            return await _dbContext.LesPays.ToListAsync();
        }

        public async Task AddAsync(Pays entity)
        {
            await _dbContext.LesPays.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pays pay, Pays entity)
        {
            _dbContext.Entry(pay).State = EntityState.Modified;
            pay.NomPays = entity.NomPays;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pays pay)
        {
            _dbContext.LesPays.Remove(pay);
            await _dbContext.SaveChangesAsync();
        }

        public Task<ActionResult<Pays>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Pays>>> IDataRepository<Pays>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Pays>>> IDataRepository<Pays>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Pays>>> IDataRepository<Pays>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Pays>>> IDataRepository<Pays>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Pays>>> IDataRepository<Pays>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Pays>>> IDataRepository<Pays>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Pays>>> IDataRepository<Pays>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Pays>>> IDataRepository<Pays>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Pays>>> IDataRepository<Pays>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Pays>>> IDataRepository<Pays>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Pays>>> IDataRepository<Pays>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Pays>>> IDataRepository<Pays>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Pays>> IDataRepository<Pays>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Pays>> IDataRepository<Pays>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Pays>> IDataRepository<Pays>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }
    }
}
