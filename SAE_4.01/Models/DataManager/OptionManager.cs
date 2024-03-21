using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class OptionManager : IDataRepository<Option>
    {
        readonly BMWDBContext _dbContext;

        public OptionManager() { }

        public OptionManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Option>>> GetAllAsync()
        {
            return await _dbContext.Options.ToListAsync();
        }

        public async Task<ActionResult<Option>> GetByIdAsync(int id)
        {
            return await _dbContext.Options.FirstOrDefaultAsync(p => p.IdOption == id);
        }

        public async Task AddAsync(Option entity)
        {
            await _dbContext.Options.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Option opt, Option entity)
        {
            _dbContext.Entry(opt).State = EntityState.Modified;
            opt.IdOption = entity.IdOption;
            opt.NomOption = entity.NomOption;
            opt.PrixOption = entity.PrixOption;
            opt.DetailOption = entity.DetailOption;
            opt.PhotoOption = entity.PhotoOption;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Option opt)
        {
            _dbContext.Options.Remove(opt);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<Stock>> IDataRepository<Option>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Stock>> IDataRepository<Option>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
