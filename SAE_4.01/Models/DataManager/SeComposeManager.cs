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

        public async Task<ActionResult<SeCompose>> GetByIdAsync(int id)
        {
            return await _dbContext.SeComposes.FirstOrDefaultAsync(p => p.IdPack == id);
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
    }
}
