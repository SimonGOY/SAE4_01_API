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

        Task<ActionResult<IEnumerable<Professionnel>>> IDataRepository<Professionnel>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Professionnel>>> IDataRepository<Professionnel>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Professionnel>>> IDataRepository<Professionnel>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Professionnel>>> IDataRepository<Professionnel>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Professionnel>>> IDataRepository<Professionnel>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Professionnel>>> IDataRepository<Professionnel>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Professionnel>>> IDataRepository<Professionnel>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Professionnel>>> IDataRepository<Professionnel>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Professionnel>>> IDataRepository<Professionnel>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Professionnel>>> IDataRepository<Professionnel>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Professionnel>>> IDataRepository<Professionnel>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Professionnel>>> IDataRepository<Professionnel>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Professionnel>> IDataRepository<Professionnel>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Professionnel>> IDataRepository<Professionnel>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Professionnel>> IDataRepository<Professionnel>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Professionnel>> IDataRepository<Professionnel>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
