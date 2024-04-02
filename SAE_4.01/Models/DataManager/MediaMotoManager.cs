using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace SAE_4._01.Models.DataManager
{
    public class MediaMotoManager : IDataRepository<MediaMoto>
    {
        readonly BMWDBContext _dbContext;

        public MediaMotoManager() { }

        public MediaMotoManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<MediaMoto>>> GetAllAsync()
        {
            return await _dbContext.MediasMoto.ToListAsync();
        }

        public async Task<ActionResult<MediaMoto>> GetByIdAsync(int id)
        {
            return await _dbContext.MediasMoto.FirstOrDefaultAsync(p => p.IdMediaMoto == id);
        }

        public async Task<ActionResult<IEnumerable<MediaMoto>>>GetByIdMotoAsync(int id)
        {
            return await _dbContext.MediasMoto.Where(p => p.IdMoto == id).ToListAsync();
        }

        // Sera utilisée dans ce controller comme GetReference pour eviter d'ajouter une nouvelle méthode non implémentée dans tous les controllers
        public async Task<ActionResult<MediaMoto>> GetReference(int id)
        {
            return await _dbContext.MediasMoto.FirstOrDefaultAsync(p => p.IsReference && p.IdMoto == id);
        }


        public async Task AddAsync(MediaMoto entity)
        {
            await _dbContext.MediasMoto.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(MediaMoto med, MediaMoto entity)
        {
            _dbContext.Entry(med).State = EntityState.Modified;
            med.IdMediaMoto = entity.IdMediaMoto;
            med.IdMoto = entity.IdMoto;
            med.IdMediaMoto = entity.IdMediaMoto;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MediaMoto med)
        {
            _dbContext.MediasMoto.Remove(med);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<MediaMoto>>> IDataRepository<MediaMoto>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaMoto>>> IDataRepository<MediaMoto>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaMoto>>> IDataRepository<MediaMoto>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaMoto>>> IDataRepository<MediaMoto>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaMoto>>> IDataRepository<MediaMoto>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaMoto>>> IDataRepository<MediaMoto>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaMoto>>> IDataRepository<MediaMoto>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaMoto>>> IDataRepository<MediaMoto>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaMoto>>> IDataRepository<MediaMoto>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaMoto>>> IDataRepository<MediaMoto>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }


        Task<ActionResult<MediaMoto>> IDataRepository<MediaMoto>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<MediaMoto>> IDataRepository<MediaMoto>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<MediaMoto>> IDataRepository<MediaMoto>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<MediaMoto>>> IDataRepository<MediaMoto>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<MediaMoto>> GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
