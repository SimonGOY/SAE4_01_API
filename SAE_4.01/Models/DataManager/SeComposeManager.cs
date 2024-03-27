using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class SeComposeManager : IDataRepository<SeCompose>
    {
        readonly BMWDBContext _dbContext;

        public SeComposeManager() { }

        public SeComposeManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<SeCompose>>> GetAllAsync()
        {
            return await _dbContext.SeComposes.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<SeCompose>>> GetByIdPackAsync(int id)
        {
            return await _dbContext.SeComposes.Where(p => p.IdPack == id).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<SeCompose>>> GetByIdOptionAsync(int id)
        {
            return await _dbContext.SeComposes.Where(p => p.IdOption == id).ToListAsync();
        }

        public async Task<ActionResult<SeCompose>> GetBy2CompositeKeysAsync(int id1, int id2)
        {
            return await _dbContext.SeComposes.FirstOrDefaultAsync(e => e.IdPack == id1 && e.IdOption == id2);
        }

        public async Task AddAsync(SeCompose entity)
        {
            await _dbContext.SeComposes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SeCompose sec, SeCompose entity)
        {
            _dbContext.Entry(sec).State = EntityState.Modified;
            sec.IdPack = entity.IdPack;
            sec.IdOption = entity.IdOption;
            sec.PackSeCompose = entity.PackSeCompose;
            sec.OptionSeCompose = entity.OptionSeCompose;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(SeCompose sec)
        {
            _dbContext.SeComposes.Remove(sec);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<SeCompose>> IDataRepository<SeCompose>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<SeCompose>>> IDataRepository<SeCompose>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<SeCompose>>> IDataRepository<SeCompose>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<SeCompose>>> IDataRepository<SeCompose>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<SeCompose>>> IDataRepository<SeCompose>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<SeCompose>>> IDataRepository<SeCompose>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<SeCompose>>> IDataRepository<SeCompose>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<SeCompose>>> IDataRepository<SeCompose>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<SeCompose>>> IDataRepository<SeCompose>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<SeCompose>>> IDataRepository<SeCompose>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<SeCompose>>> IDataRepository<SeCompose>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<SeCompose>> IDataRepository<SeCompose>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<SeCompose>> IDataRepository<SeCompose>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<SeCompose>> IDataRepository<SeCompose>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
