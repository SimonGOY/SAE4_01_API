using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class ClientManager : IDataRepository<Client>
    {
        readonly BMWDBContext _dbContext;

        public ClientManager() { }

        public ClientManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Client>>> GetAllAsync()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<ActionResult<Client>> GetByIdAsync(int id)
        {
            return await _dbContext.Clients.FirstOrDefaultAsync(p => p.IdClient == id);
        }

        public async Task AddAsync(Client entity)
        {
            await _dbContext.Clients.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Client clt, Client entity)
        {
            _dbContext.Entry(clt).State = EntityState.Modified;
            clt.IdClient = entity.IdClient;
            clt.NumAdresse = entity.NumAdresse;
            clt.Civilite = entity.Civilite;
            clt.NomClient = entity.NomClient;
            clt.PrenomClient = entity.PrenomClient;
            clt.DateNaissanceClient = entity.DateNaissanceClient;
            clt.EmailClient = entity.EmailClient;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Client clt)
        {
            _dbContext.Clients.Remove(clt);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Client>>> IDataRepository<Client>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Client>>> IDataRepository<Client>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Client>>> IDataRepository<Client>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Client>>> IDataRepository<Client>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Client>>> IDataRepository<Client>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Client>>> IDataRepository<Client>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Client>>> IDataRepository<Client>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Client>>> IDataRepository<Client>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Client>>> IDataRepository<Client>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Client>>> IDataRepository<Client>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Client>>> IDataRepository<Client>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Client>>> IDataRepository<Client>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
