using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class UserManager : IDataRepository<User>
    {
        readonly BMWDBContext _dbContext;

        public UserManager() { }

        public UserManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<User>>> GetAllAsync()
        {
            return await _dbContext.LesUsers.ToListAsync();
        }

        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            return await _dbContext.LesUsers.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(User entity)
        {
            await _dbContext.LesUsers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(User use, User entity)
        {
            use.FirstName = entity.FirstName;
            use.Email = entity.Email;
            use.Password = entity.Password;
            use.CreatedAt = entity.CreatedAt;
            use.UpdatedAt = entity.UpdatedAt;
            use.Civilite = entity.Civilite;
            use.LastName = entity.LastName;
            use.IsComplete = entity.IsComplete;
            use.TypeCompte = entity.TypeCompte;
            use.DoubleAuth = entity.DoubleAuth;
            use.LastConnected = entity.LastConnected;
            use.ClientUsers = entity.ClientUsers;

            await _dbContext.SaveChangesAsync();
        }


        public async Task DeleteAsync(User use)
        {
            _dbContext.LesUsers.Remove(use);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<User>>> IDataRepository<User>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<User>>> IDataRepository<User>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<User>>> IDataRepository<User>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<User>>> IDataRepository<User>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<User>>> IDataRepository<User>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<User>>> IDataRepository<User>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<User>>> IDataRepository<User>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<User>>> IDataRepository<User>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<User>>> IDataRepository<User>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<User>>> IDataRepository<User>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<User>>> IDataRepository<User>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<User>>> IDataRepository<User>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<User>> IDataRepository<User>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<User>> IDataRepository<User>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<User>> IDataRepository<User>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<User>> IDataRepository<User>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
