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
    }
}
