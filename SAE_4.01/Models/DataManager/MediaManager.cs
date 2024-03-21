using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace SAE_4._01.Models.DataManager
{
    public class MediaManager : IDataRepository<Media>
    {
        readonly BMWDBContext _dbContext;

        public MediaManager() { }

        public MediaManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Media>>> GetAllAsync()
        {
            return await _dbContext.Medias.ToListAsync();
        }

        public async Task<ActionResult<Media>> GetByIdAsync(int id)
        {
            return await _dbContext.Medias.FirstOrDefaultAsync(p => p.IdMedia == id);
        }

        public async Task AddAsync(Media entity)
        {
            await _dbContext.Medias.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Media med, Media entity)
        {
            _dbContext.Entry(med).State = EntityState.Modified;
            med.IdMedia = entity.IdMedia;
            med.IdEquipement = entity.IdEquipement;
            med.IdMedia = entity.IdMedia;
            med.LienMedia = entity.LienMedia;
            med.IdPresentation = entity.IdPresentation;
            med.IsPresentation = entity.IsPresentation;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Media med)
        {
            _dbContext.Medias.Remove(med);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Media>>> IDataRepository<Media>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Media>>> IDataRepository<Media>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Media>>> IDataRepository<Media>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Media>>> IDataRepository<Media>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Media>>> IDataRepository<Media>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Media>>> IDataRepository<Media>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Media>>> IDataRepository<Media>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Media>>> IDataRepository<Media>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Media>>> IDataRepository<Media>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Media>>> IDataRepository<Media>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Media>>> IDataRepository<Media>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Media>>> IDataRepository<Media>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
