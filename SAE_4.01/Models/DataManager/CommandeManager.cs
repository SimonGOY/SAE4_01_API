using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class CommandeManager : IDataRepository<Commande>
    {
        readonly BMWDBContext _dbContext;

        public CommandeManager() { }

        public CommandeManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Commande>>> GetAllAsync()
        {
            return await _dbContext.Commandes.ToListAsync();
        }

        public async Task<ActionResult<Commande>> GetByIdAsync(int id)
        {
            return await _dbContext.Commandes.FirstOrDefaultAsync(p => p.IdCommande == id);
        }

        public async Task AddAsync(Commande entity)
        {
            await _dbContext.Commandes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Commande cmd, Commande entity)
        {
            _dbContext.Entry(cmd).State = EntityState.Modified;
            cmd.IdCommande = entity.IdCommande;
            cmd.IdClient = entity.IdClient;
            cmd.DateCommande = entity.DateCommande;
            cmd.Etat = entity.Etat;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Commande cmd)
        {
            _dbContext.Commandes.Remove(cmd);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Commande>>> IDataRepository<Commande>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Commande>>> IDataRepository<Commande>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Commande>>> IDataRepository<Commande>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Commande>>> IDataRepository<Commande>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Commande>>> IDataRepository<Commande>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Commande>>> IDataRepository<Commande>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Commande>>> IDataRepository<Commande>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Commande>>> IDataRepository<Commande>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Commande>>> IDataRepository<Commande>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Commande>>> IDataRepository<Commande>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Commande>>> IDataRepository<Commande>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Commande>>> IDataRepository<Commande>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Commande>> IDataRepository<Commande>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Commande>> IDataRepository<Commande>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Commande>> IDataRepository<Commande>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Commande>> IDataRepository<Commande>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Commande>> GetReference(int id)
        {
            throw new NotImplementedException();
        }
    }
}
