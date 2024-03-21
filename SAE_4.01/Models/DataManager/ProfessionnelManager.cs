using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class ProfessionnelManager : IDataRepository<Professionnel>
    {
        readonly BMWDBContext _dbContext;

        public ProfessionnelManager() { }

        public ProfessionnelManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Professionnel>>> GetAllAsync()
        {
            return await _dbContext.Professionnels.ToListAsync();
        }

        public async Task<ActionResult<Professionnel>> GetByIdAsync(int id)
        {
            return await _dbContext.Professionnels.FirstOrDefaultAsync(p => p.IdPro == id);
        }

        public async Task AddAsync(Professionnel entity)
        {
            await _dbContext.Professionnels.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Professionnel pro, Professionnel entity)
        {
            _dbContext.Entry(pro).State = EntityState.Modified;
            pro.IdPro = entity.IdPro;
            pro.IdClient = entity.IdClient;
            pro.NomCompagnie = entity.NomCompagnie;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Professionnel pro)
        {
            _dbContext.Professionnels.Remove(pro);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Professionnel>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Professionnel>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
