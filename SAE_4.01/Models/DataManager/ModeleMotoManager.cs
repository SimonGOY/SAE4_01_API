using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace SAE_4._01.Models.DataManager
{
    public class ModeleMotoManager : IDataRepository<ModeleMoto>
    {
        readonly BMWDBContext _dbContext;

        public ModeleMotoManager() { }

        public ModeleMotoManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<ModeleMoto>>> GetAllAsync()
        {
            return await _dbContext.ModeleMotos.ToListAsync();
        }

        public async Task<ActionResult<ModeleMoto>> GetByIdAsync(int id)
        {
            return await _dbContext.ModeleMotos.FirstOrDefaultAsync(p => p.IdMoto == id);
        }

        public async Task AddAsync(ModeleMoto entity)
        {
            await _dbContext.ModeleMotos.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ModeleMoto mod, ModeleMoto entity)
        {
            _dbContext.Entry(mod).State = EntityState.Modified;
            mod.IdMoto = entity.IdMoto;
            mod.IdGamme = entity.IdGamme;
            mod.NomMoto = entity.NomMoto;
            mod.DescriptifMoto = entity.DescriptifMoto;
            mod.PrixMoto = entity.PrixMoto;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ModeleMoto mod)
        {
            _dbContext.ModeleMotos.Remove(mod);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<ModeleMoto>>> IDataRepository<ModeleMoto>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ModeleMoto>>> IDataRepository<ModeleMoto>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ModeleMoto>>> IDataRepository<ModeleMoto>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ModeleMoto>>> IDataRepository<ModeleMoto>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ModeleMoto>>> IDataRepository<ModeleMoto>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ModeleMoto>>> IDataRepository<ModeleMoto>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ModeleMoto>>> IDataRepository<ModeleMoto>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ModeleMoto>>> IDataRepository<ModeleMoto>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ModeleMoto>>> IDataRepository<ModeleMoto>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ModeleMoto>>> IDataRepository<ModeleMoto>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ModeleMoto>>> IDataRepository<ModeleMoto>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<ModeleMoto>>> IDataRepository<ModeleMoto>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<ModeleMoto>> IDataRepository<ModeleMoto>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<ModeleMoto>> IDataRepository<ModeleMoto>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<ModeleMoto>> IDataRepository<ModeleMoto>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<ModeleMoto>> IDataRepository<ModeleMoto>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<ModeleMoto>> GetReference(int id)
        {
            throw new NotImplementedException();
        }
    }
}
