using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class AccessoireManager : IDataRepository<Accessoire>
    {
        readonly BMWDBContext _dbContext;

        public AccessoireManager() { }

        public AccessoireManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Accessoire>>> GetAllAsync()
        {
            return await _dbContext.Accessoires.ToListAsync();
        }

        public async Task<ActionResult<Accessoire>> GetByIdAsync(int id)
        {
            return await _dbContext.Accessoires.FirstOrDefaultAsync(p => p.IdAccessoire == id);
        }

        public async Task AddAsync(Accessoire entity)
        {
            await _dbContext.Accessoires.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Accessoire acc, Accessoire entity)
        {
            _dbContext.Entry(acc).State = EntityState.Modified;
            acc.IdAccessoire = entity.IdAccessoire;
            acc.IdMoto = entity.IdMoto;
            acc.IdCatAcc = entity.IdCatAcc;
            acc.NomAccessoire = entity.NomAccessoire;
            acc.PrixAccessoire = entity.PrixAccessoire;
            acc.DetailAccessoire = entity.DetailAccessoire;
            acc.PhotoAccessoire = entity.PhotoAccessoire;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Accessoire etu)
        {
            _dbContext.Accessoires.Remove(etu);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Accessoire>>> GetByIdMotoAsync(int id)
        {
            return await _dbContext.Accessoires.Where(p => p.IdMoto == id).ToListAsync();
        }

        Task<ActionResult<IEnumerable<Accessoire>>> IDataRepository<Accessoire>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Accessoire>>> IDataRepository<Accessoire>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Accessoire>>> IDataRepository<Accessoire>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Accessoire>>> IDataRepository<Accessoire>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Accessoire>>> IDataRepository<Accessoire>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Accessoire>>> IDataRepository<Accessoire>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Accessoire>>> IDataRepository<Accessoire>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Accessoire>>> IDataRepository<Accessoire>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Accessoire>>> IDataRepository<Accessoire>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Accessoire>>> IDataRepository<Accessoire>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Accessoire>>> IDataRepository<Accessoire>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Accessoire>> IDataRepository<Accessoire>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Accessoire>> IDataRepository<Accessoire>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Accessoire>> IDataRepository<Accessoire>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Accessoire>> IDataRepository<Accessoire>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Accessoire>> GetReference(int id)
        {
            throw new NotImplementedException();
        }
    }
}
