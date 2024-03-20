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

        public async Task<ActionResult<Garage>> GetByIdAsync(int id)
        {
            return await _dbContext.Garages.FirstOrDefaultAsync(p => p.IdMotoConfigurable == id);
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
    }
}
