using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class AdresseManager : IDataRepository<Adresse>
    {
        readonly BMWDBContext _dbContext;

        public AdresseManager() { }

        public AdresseManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Adresse>>> GetAllAsync()
        {
            return await _dbContext.Adresses.ToListAsync();
        }

        public async Task<ActionResult<Adresse>> GetByIdAsync(int id)
        {
            return await _dbContext.Adresses.FirstOrDefaultAsync(p => p.NumAdresse == id);
        }

        public async Task AddAsync(Adresse entity)
        {
            await _dbContext.Adresses.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Adresse adr, Adresse entity)
        {
            _dbContext.Entry(adr).State = EntityState.Modified;
            adr.NumAdresse = entity.NumAdresse;
            adr.NomPays = entity.NomPays;
            adr.AdresseAdresse = entity.AdresseAdresse;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Adresse adr)
        {
            _dbContext.Adresses.Remove(adr);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Adresse>>> IDataRepository<Adresse>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Adresse>>> IDataRepository<Adresse>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Adresse>>> IDataRepository<Adresse>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Adresse>>> IDataRepository<Adresse>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Adresse>>> IDataRepository<Adresse>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Adresse>>> IDataRepository<Adresse>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Adresse>>> IDataRepository<Adresse>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Adresse>>> IDataRepository<Adresse>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Adresse>>> IDataRepository<Adresse>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Adresse>>> IDataRepository<Adresse>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Adresse>>> IDataRepository<Adresse>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Adresse>>> IDataRepository<Adresse>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
