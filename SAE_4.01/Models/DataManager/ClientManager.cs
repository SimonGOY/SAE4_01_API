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

        public async Task UpdateAsync(Client etu, Client entity)
        {
            _dbContext.Entry(etu).State = EntityState.Modified;
            /*etu.EtudiantId = entity.EtudiantId;
            etu.Ine = entity.Ine;
            etu.NomEtudiant = entity.NomEtudiant;
            etu.PrenomEtudiant = entity.PrenomEtudiant;
            etu.DateInscription = entity.DateInscription;*/
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Client etu)
        {
            _dbContext.Clients.Remove(etu);
            await _dbContext.SaveChangesAsync();
        }
    }
}
