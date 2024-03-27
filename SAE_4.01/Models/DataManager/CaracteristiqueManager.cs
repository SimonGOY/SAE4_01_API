using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class CaracteristiqueManager : IDataRepository<Caracteristique>
    {
        readonly BMWDBContext _dbContext;

        public CaracteristiqueManager() { }

        public CaracteristiqueManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Caracteristique>>> GetAllAsync()
        {
            return await _dbContext.Caracteristiques.ToListAsync();
        }

        public async Task<ActionResult<Caracteristique>> GetByIdAsync(int id)
        {
            return await _dbContext.Caracteristiques.FirstOrDefaultAsync(p => p.IdCaracteristique == id);
        }

        public async Task AddAsync(Caracteristique entity)
        {
            await _dbContext.Caracteristiques.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Caracteristique car, Caracteristique entity)
        {
            _dbContext.Entry(car).State = EntityState.Modified;
            car.IdCaracteristique = entity.IdCaracteristique;
            car.IdMoto = entity.IdMoto;
            car.IdCatCaracteristique = entity.IdCatCaracteristique;
            car.NomCaracteristique = entity.NomCaracteristique;
            car.ValeurCaracteristique = entity.ValeurCaracteristique;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Caracteristique car)
        {
            _dbContext.Caracteristiques.Remove(car);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Caracteristique>>> IDataRepository<Caracteristique>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Caracteristique>>> IDataRepository<Caracteristique>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Caracteristique>>> IDataRepository<Caracteristique>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Caracteristique>>> IDataRepository<Caracteristique>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Caracteristique>>> IDataRepository<Caracteristique>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Caracteristique>>> IDataRepository<Caracteristique>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Caracteristique>>> IDataRepository<Caracteristique>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Caracteristique>>> IDataRepository<Caracteristique>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Caracteristique>>> IDataRepository<Caracteristique>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Caracteristique>>> IDataRepository<Caracteristique>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Caracteristique>>> IDataRepository<Caracteristique>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Caracteristique>>> IDataRepository<Caracteristique>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Caracteristique>> IDataRepository<Caracteristique>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Caracteristique>> IDataRepository<Caracteristique>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Caracteristique>> IDataRepository<Caracteristique>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Caracteristique>> IDataRepository<Caracteristique>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
