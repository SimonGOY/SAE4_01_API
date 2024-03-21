using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace SAE_4._01.Models.DataManager
{
    public class EstInclusManager : IDataRepository<EstInclus>
    {
        readonly BMWDBContext _dbContext;

        public EstInclusManager() { }

        public EstInclusManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<EstInclus>>> GetAllAsync()
        {
            return await _dbContext.SontInclus.ToListAsync();
        }

        public async Task<ActionResult<EstInclus>> GetByIdAsync(int id)
        {
            return await _dbContext.SontInclus.FirstOrDefaultAsync(p => p.IdOption == id);
        }

        public async Task AddAsync(EstInclus entity)
        {
            await _dbContext.SontInclus.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(EstInclus ecl, EstInclus entity)
        {
            _dbContext.Entry(ecl).State = EntityState.Modified;
            ecl.IdOption = entity.IdOption;
            ecl.IdStyle = entity.IdStyle;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(EstInclus ecl)
        {
            _dbContext.SontInclus.Remove(ecl);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<Stock>> IDataRepository<EstInclus>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Stock>> IDataRepository<EstInclus>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
