using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class ContenuCommandeManager : IDataRepository<ContenuCommande>
    {
        readonly BMWDBContext _dbContext;

        public ContenuCommandeManager() { }

        public ContenuCommandeManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<ContenuCommande>>> GetAllAsync()
        {
            return await _dbContext.ContenuCommandes.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<ContenuCommande>>> GetByIdCommandeAsync(int id)
        {
            return await _dbContext.ContenuCommandes.Where(p => p.IdCommande == id).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<ContenuCommande>>> GetByIdEquipementAsync(int id)
        {
            return await _dbContext.ContenuCommandes.Where(p => p.IdEquipement == id).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<ContenuCommande>>> GetByIdTailleAsync(int id)
        {
            return await _dbContext.ContenuCommandes.Where(p => p.IdTaille == id).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<ContenuCommande>>> GetByIdColorisAsync(int id)
        {
            return await _dbContext.ContenuCommandes.Where(p => p.IdColoris == id).ToListAsync();
        }

        public async Task<ActionResult<ContenuCommande>> GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            return await _dbContext.ContenuCommandes.FirstOrDefaultAsync(e => e.IdCommande == id1 && e.IdEquipement == id2 && e.IdTaille == id3 && e.IdColoris == id4);
        }

        public async Task AddAsync(ContenuCommande entity)
        {
            await _dbContext.ContenuCommandes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ContenuCommande ccm, ContenuCommande entity)
        {
            _dbContext.Entry(ccm).State = EntityState.Modified;
            ccm.IdCommande = entity.IdCommande;
            ccm.IdEquipement = entity.IdEquipement;
            ccm.Quantite = entity.Quantite;
            ccm.IdTaille = entity.IdTaille;
            ccm.IdColoris = entity.IdColoris;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ContenuCommande ccm)
        {
            _dbContext.ContenuCommandes.Remove(ccm);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<ContenuCommande>>> IDataRepository<ContenuCommande>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContenuCommande>>> IDataRepository<ContenuCommande>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContenuCommande>>> IDataRepository<ContenuCommande>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContenuCommande>>> IDataRepository<ContenuCommande>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContenuCommande>>> IDataRepository<ContenuCommande>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContenuCommande>>> IDataRepository<ContenuCommande>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContenuCommande>>> IDataRepository<ContenuCommande>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ContenuCommande>>> IDataRepository<ContenuCommande>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<ContenuCommande>> IDataRepository<ContenuCommande>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<ContenuCommande>> IDataRepository<ContenuCommande>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<ContenuCommande>> IDataRepository<ContenuCommande>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }
    }
}
