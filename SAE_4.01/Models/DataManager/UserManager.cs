using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class UserManager : IDataRepository<Users>
    {
        readonly BMWDBContext _dbContext;

        public UserManager() { }

        public UserManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Users>>> GetAllAsync()
        {
            return await _dbContext.LesUsers.ToListAsync();
        }

        public async Task<ActionResult<Users>> GetByIdAsync(int id)
        {
            return await _dbContext.LesUsers.FirstOrDefaultAsync(p => p.IdClient == id);
        }

        public async Task AddAsync(Users entity)
        {
            await _dbContext.LesUsers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Users use, Users entity)
        {
            _dbContext.Entry(use).State = EntityState.Modified;
            use.Id = entity.Id;
            use.FirstName = entity.FirstName;
            use.Email = entity.Email;
            use.Password = entity.Password;
            use.CreatedAt = entity.CreatedAt;
            use.UpdatedAt = entity.UpdatedAt;
            use.Civilite = entity.Civilite;
            use.LastName = entity.LastName;
            use.IdClient = entity.IdClient;
            use.IsComplete = entity.IsComplete;
            use.TypeCompte = entity.TypeCompte;
            use.DoubleAuth = entity.DoubleAuth;
            use.LastConnected = entity.LastConnected;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Users use)
        {
            _dbContext.LesUsers.Remove(use);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<Stock>> IDataRepository<Users>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Stock>> IDataRepository<Users>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
