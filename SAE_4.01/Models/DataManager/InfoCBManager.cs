using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace SAE_4._01.Models.DataManager
{
    public class InfoCBManager : IDataRepository<InfoCB>
    {
        readonly BMWDBContext _dbContext;

        public InfoCBManager() { }

        public InfoCBManager (BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<InfoCB>>> GetAllAsync()
        {
            return await _dbContext.InfoCBs.ToListAsync();
        }

        public async Task<ActionResult<InfoCB>> GetByIdAsync(int id)
        {
            return await _dbContext.InfoCBs.FirstOrDefaultAsync(p => p.IdCarte == id);
        }

        public async Task AddAsync(InfoCB entity)
        {
            await _dbContext.InfoCBs.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(InfoCB icb, InfoCB entity)
        {
            _dbContext.Entry(icb).State = EntityState.Modified;
            icb.IdCarte = entity.IdCarte;
            icb.IdClient = entity.IdClient;
            icb.NumCarte = entity.NumCarte;
            icb.DateExpiration = entity.DateExpiration;
            icb.TitulaireCompte = entity.TitulaireCompte;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(InfoCB icb)
        {
            _dbContext.InfoCBs.Remove(icb);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<InfoCB>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Stock>>> IDataRepository<InfoCB>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
