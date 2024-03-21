using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace SAE_4._01.Models.DataManager
{
    public class DemandeEssaiManager : IDataRepository<DemandeEssai>
    {
        readonly BMWDBContext _dbContext;

        public DemandeEssaiManager() { }

        public DemandeEssaiManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<DemandeEssai>>> GetAllAsync()
        {
            return await _dbContext.DemandeEssais.ToListAsync();
        }

        public async Task<ActionResult<DemandeEssai>> GetByIdAsync(int id)
        {
            return await _dbContext.DemandeEssais.FirstOrDefaultAsync(p => p.IdDemandeEssai == id);
        }

        public async Task AddAsync(DemandeEssai entity)
        {
            await _dbContext.DemandeEssais.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(DemandeEssai dmd, DemandeEssai entity)
        {
            _dbContext.Entry(dmd).State = EntityState.Modified;
            dmd.IdDemandeEssai = entity.IdDemandeEssai;
            dmd.IdConcessionnaire = entity.IdConcessionnaire;
            dmd.IdMoto = entity.IdMoto;
            dmd.IdContact = entity.IdContact;
            dmd.DescriptifDemandeEssai = entity.DescriptifDemandeEssai;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(DemandeEssai dmd)
        {
            _dbContext.DemandeEssais.Remove(dmd);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<DemandeEssai>>> IDataRepository<DemandeEssai>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<DemandeEssai>>> IDataRepository<DemandeEssai>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<DemandeEssai>>> IDataRepository<DemandeEssai>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<DemandeEssai>>> IDataRepository<DemandeEssai>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<DemandeEssai>>> IDataRepository<DemandeEssai>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<DemandeEssai>>> IDataRepository<DemandeEssai>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<DemandeEssai>>> IDataRepository<DemandeEssai>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<DemandeEssai>>> IDataRepository<DemandeEssai>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<DemandeEssai>>> IDataRepository<DemandeEssai>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<DemandeEssai>>> IDataRepository<DemandeEssai>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<DemandeEssai>>> IDataRepository<DemandeEssai>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<DemandeEssai>>> IDataRepository<DemandeEssai>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
