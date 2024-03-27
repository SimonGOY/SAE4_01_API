using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class ConcessionnaireManager : IDataRepository<Concessionnaire>
    {
        readonly BMWDBContext _dbContext;

        public ConcessionnaireManager() { }

        public ConcessionnaireManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Concessionnaire>>> GetAllAsync()
        {
            return await _dbContext.Concessionnaires.ToListAsync();
        }

        public async Task<ActionResult<Concessionnaire>> GetByIdAsync(int id)
        {
            return await _dbContext.Concessionnaires.FirstOrDefaultAsync(p => p.IdConcessionnaire == id);
        }

        public async Task AddAsync(Concessionnaire entity)
        {
            await _dbContext.Concessionnaires.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Concessionnaire con, Concessionnaire entity)
        {
            _dbContext.Entry(con).State = EntityState.Modified;
            con.IdConcessionnaire = entity.IdConcessionnaire;
            con.NomConcessionnaire = entity.NomConcessionnaire;
            con.EmailConcessionnaire = entity.EmailConcessionnaire;
            con.SiteConcessionnaire = entity.SiteConcessionnaire;
            con.TelephoneConcessionnaire = entity.TelephoneConcessionnaire;
            con.AdresseConcessionnaire = entity.AdresseConcessionnaire;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Concessionnaire con)
        {
            _dbContext.Concessionnaires.Remove(con);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Concessionnaire>>> IDataRepository<Concessionnaire>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Concessionnaire>>> IDataRepository<Concessionnaire>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Concessionnaire>>> IDataRepository<Concessionnaire>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Concessionnaire>>> IDataRepository<Concessionnaire>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Concessionnaire>>> IDataRepository<Concessionnaire>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Concessionnaire>>> IDataRepository<Concessionnaire>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Concessionnaire>>> IDataRepository<Concessionnaire>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Concessionnaire>>> IDataRepository<Concessionnaire>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Concessionnaire>>> IDataRepository<Concessionnaire>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Concessionnaire>>> IDataRepository<Concessionnaire>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Concessionnaire>>> IDataRepository<Concessionnaire>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Concessionnaire>>> IDataRepository<Concessionnaire>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Concessionnaire>> IDataRepository<Concessionnaire>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Concessionnaire>> IDataRepository<Concessionnaire>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Concessionnaire>> IDataRepository<Concessionnaire>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }
    }
}
