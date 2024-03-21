using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace SAE_4._01.Models.DataManager
{
    public class GarageManager : IDataRepository<Garage>
    {
        readonly BMWDBContext _dbContext;

        public GarageManager() { }

        public GarageManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Garage>>> GetAllAsync()
        {
            return await _dbContext.Garages.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Garage>>> GetByIdMotoConfigurableAsync(int id)
        {
            return await _dbContext.Garages.Where(p => p.IdMotoConfigurable == id).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Garage>>> GetByIdClientAsync(int id)
        {
            return await _dbContext.Garages.Where(p => p.IdClient == id).ToListAsync();
        }

        public async Task AddAsync(Garage entity)
        {
            await _dbContext.Garages.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Garage grg, Garage entity)
        {
            _dbContext.Entry(grg).State = EntityState.Modified;
            grg.IdMotoConfigurable = entity.IdMotoConfigurable;
            grg.IdClient = entity.IdClient;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Garage grg)
        {
            _dbContext.Garages.Remove(grg);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<Garage>> IDataRepository<Garage>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Garage>>> IDataRepository<Garage>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Garage>>> IDataRepository<Garage>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Garage>>> IDataRepository<Garage>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Garage>>> IDataRepository<Garage>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Garage>>> IDataRepository<Garage>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Garage>>> IDataRepository<Garage>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Garage>>> IDataRepository<Garage>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Garage>>> IDataRepository<Garage>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Garage>>> IDataRepository<Garage>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Garage>>> IDataRepository<Garage>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
