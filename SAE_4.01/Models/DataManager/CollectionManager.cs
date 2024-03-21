using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class CollectionManager : IDataRepository<Collection>
    {
        readonly BMWDBContext _dbContext;

        public CollectionManager() { }

        public CollectionManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Collection>>> GetAllAsync()
        {
            return await _dbContext.Collections.ToListAsync();
        }

        public async Task<ActionResult<Collection>> GetByIdAsync(int id)
        {
            return await _dbContext.Collections.FirstOrDefaultAsync(p => p.IdCollection == id);
        }

        public async Task AddAsync(Collection entity)
        {
            await _dbContext.Collections.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Collection cln, Collection entity)
        {
            _dbContext.Entry(cln).State = EntityState.Modified;
            cln.IdCollection = entity.IdCollection;
            cln.NomCollection = entity.NomCollection;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Collection cln)
        {
            _dbContext.Collections.Remove(cln);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Collection>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Collection>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
