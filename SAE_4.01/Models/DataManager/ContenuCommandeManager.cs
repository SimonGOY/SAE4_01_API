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

        public async Task<ActionResult<ContenuCommande>> GetByIdAsync(int id)
        {
            return await _dbContext.ContenuCommandes.FirstOrDefaultAsync(p => p.IdCommande == id);
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
    }
}
