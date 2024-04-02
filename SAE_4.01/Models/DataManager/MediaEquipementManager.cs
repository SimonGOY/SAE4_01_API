using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace SAE_4._01.Models.DataManager
{
    public class MediaEquipementManager : IDataRepository<MediaEquipement>
    {
        readonly BMWDBContext _dbContext;

        public MediaEquipementManager() { }

        public MediaEquipementManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<MediaEquipement>> GetByIdAsync(int id)
        {
            return await _dbContext.MediasEquipement.FirstOrDefaultAsync(p => p.IdMediaEquipement == id);
        }

        public async Task<ActionResult<IEnumerable<MediaEquipement>>>GetByIdEquipementAsync(int id)
        {
            return await _dbContext.MediasEquipement.Where(p => p.IdEquipement == id).ToListAsync();
        }

        public async Task AddAsync(MediaEquipement entity)
        {
            await _dbContext.MediasEquipement.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(MediaEquipement med, MediaEquipement entity)
        {
            _dbContext.Entry(med).State = EntityState.Modified;
            med.IdMediaEquipement = entity.IdMediaEquipement;
            med.IdEquipement = entity.IdEquipement;
            med.IdMediaEquipement = entity.IdMediaEquipement;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MediaEquipement med)
        {
            _dbContext.MediasEquipement.Remove(med);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<MediaEquipement>>> IDataRepository<MediaEquipement>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaEquipement>>> IDataRepository<MediaEquipement>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaEquipement>>> IDataRepository<MediaEquipement>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaEquipement>>> IDataRepository<MediaEquipement>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaEquipement>>> IDataRepository<MediaEquipement>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaEquipement>>> IDataRepository<MediaEquipement>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaEquipement>>> IDataRepository<MediaEquipement>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaEquipement>>> IDataRepository<MediaEquipement>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaEquipement>>> IDataRepository<MediaEquipement>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaEquipement>>> IDataRepository<MediaEquipement>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaEquipement>>> IDataRepository<MediaEquipement>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }
   
        // Ne fonctionne pasa cause des null sur idmoto ne fonctionne pas
        // Inutile de coder car jamais utilisée dans l'application
        public Task<ActionResult<IEnumerable<MediaEquipement>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<MediaEquipement>> IDataRepository<MediaEquipement>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<MediaEquipement>> IDataRepository<MediaEquipement>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<MediaEquipement>> IDataRepository<MediaEquipement>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<MediaEquipement>> IDataRepository<MediaEquipement>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
