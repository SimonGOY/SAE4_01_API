using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class TelephoneManager : IDataRepository<Telephone>
    {
        readonly BMWDBContext _dbContext;

        public TelephoneManager() { }

        public TelephoneManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Telephone>>> GetAllAsync()
        {
            return await _dbContext.Telephones.ToListAsync();
        }

        public async Task<ActionResult<Telephone>> GetByIdAsync(int id)
        {
            return await _dbContext.Telephones.FirstOrDefaultAsync(p => p.IdClient == id);
        }

        public async Task AddAsync(Telephone entity)
        {
            await _dbContext.Telephones.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Telephone tel, Telephone entity)
        {
            _dbContext.Entry(tel).State = EntityState.Modified;
            tel.Id = entity.Id;
            tel.IdClient = entity.IdClient;
            tel.NumTelephone = entity.NumTelephone;
            tel.Type = entity.Type;
            tel.Fonction = entity.Fonction;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Telephone use)
        {
            _dbContext.Telephones.Remove(use);
            await _dbContext.SaveChangesAsync();
        }
    }
}
