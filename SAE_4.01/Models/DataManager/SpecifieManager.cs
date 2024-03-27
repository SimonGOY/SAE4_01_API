using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace SAE_4._01.Models.DataManager
{
    public class SpecifieManager : IDataRepository<Specifie>
    {
        readonly BMWDBContext _dbContext;

        public SpecifieManager() { }

        public SpecifieManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Specifie>>> GetAllAsync()
        {
            return await _dbContext.Specifies.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Specifie>>> GetByIdOptionAsync(int id)
        {
            return await _dbContext.Specifies.Where(p => p.IdOption == id).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Specifie>>> GetByIdMotoAsync(int id)
        {
            return await _dbContext.Specifies.Where(p => p.IdMoto == id).ToListAsync();
        }

        public async Task<ActionResult<Specifie>> GetBy2CompositeKeysAsync(int id1, int id2)
        {
            return await _dbContext.Specifies.FirstOrDefaultAsync(e => e.IdOption == id1 && e.IdMoto == id2);
        }
        public async Task AddAsync(Specifie entity)
        {
            await _dbContext.Specifies.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Specifie spe, Specifie entity)
        {
            _dbContext.Entry(spe).State = EntityState.Modified;
            spe.IdOption = entity.IdOption;
            spe.IdMoto = entity.IdMoto;
            spe.OptionSpecifie = entity.OptionSpecifie;
            spe.ModeleMotoSpecifie = entity.ModeleMotoSpecifie;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Specifie spe)
        {
            _dbContext.Specifies.Remove(spe);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<Specifie>> IDataRepository<Specifie>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Specifie>>> IDataRepository<Specifie>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Specifie>>> IDataRepository<Specifie>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Specifie>>> IDataRepository<Specifie>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Specifie>>> IDataRepository<Specifie>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Specifie>>> IDataRepository<Specifie>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Specifie>>> IDataRepository<Specifie>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Specifie>>> IDataRepository<Specifie>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Specifie>>> IDataRepository<Specifie>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Specifie>>> IDataRepository<Specifie>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Specifie>>> IDataRepository<Specifie>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Specifie>> IDataRepository<Specifie>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Specifie>> IDataRepository<Specifie>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Specifie>> IDataRepository<Specifie>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
