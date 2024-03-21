using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class PackManager : IDataRepository<Pack>
    {
        readonly BMWDBContext _dbContext;

        public PackManager() { }

        public PackManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Pack>>> GetAllAsync()
        {
            return await _dbContext.Packs.ToListAsync();
        }

        public async Task<ActionResult<Pack>> GetByIdAsync(int id)
        {
            return await _dbContext.Packs.FirstOrDefaultAsync(p => p.IdPack == id);
        }

        public async Task AddAsync(Pack entity)
        {
            await _dbContext.Packs.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pack pac, Pack entity)
        {
            _dbContext.Entry(pac).State = EntityState.Modified;
            pac.IdPack = entity.IdPack;
            pac.IdMoto = entity.IdMoto;
            pac.NomPack = entity.NomPack;
            pac.DescriptionPack = entity.DescriptionPack;
            pac.PhotoPack = entity.PhotoPack;
            pac.PrixPack = entity.PrixPack;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pack pac)
        {
            _dbContext.Packs.Remove(pac);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Pack>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<Pack>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
