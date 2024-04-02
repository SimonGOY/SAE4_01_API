using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace SAE_4._01.Models.DataManager
{
    public class EquipementManager : IDataRepository<Equipement>
    {
        readonly BMWDBContext _dbContext;

        public EquipementManager() { }

        public EquipementManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Equipement>>> GetAllAsync()
        {
            return await _dbContext.Equipements.ToListAsync();
        }

        public async Task<ActionResult<Equipement>> GetByIdAsync(int id)
        {
            return await _dbContext.Equipements.FirstOrDefaultAsync(p => p.IdEquipement == id);
        }

        public async Task AddAsync(Equipement entity)
        {
            await _dbContext.Equipements.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Equipement equ, Equipement entity)
        {
            _dbContext.Entry(equ).State = EntityState.Modified;
            equ.IdEquipement = entity.IdEquipement;
            equ.IdCatEquipement = entity.IdCatEquipement;
            equ.NomEquipement = entity.NomEquipement;
            equ.DescriptionEquipement = entity.DescriptionEquipement;
            equ.SexeEquipement = entity.SexeEquipement;
            equ.PrixEquipement = entity.PrixEquipement;
            equ.DureeGarantie = entity.DureeGarantie;
            equ.Tendance = entity.Tendance;
            equ.Segment = entity.Segment;
            equ.IdCollection = entity.IdCollection;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Equipement equ)
        {
            _dbContext.Equipements.Remove(equ);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Equipement>>> IDataRepository<Equipement>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Equipement>>> IDataRepository<Equipement>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Equipement>>> IDataRepository<Equipement>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Equipement>>> IDataRepository<Equipement>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Equipement>>> IDataRepository<Equipement>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Equipement>>> IDataRepository<Equipement>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Equipement>>> IDataRepository<Equipement>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Equipement>>> IDataRepository<Equipement>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Equipement>>> IDataRepository<Equipement>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Equipement>>> IDataRepository<Equipement>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Equipement>>> IDataRepository<Equipement>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Equipement>>> IDataRepository<Equipement>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Equipement>> IDataRepository<Equipement>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Equipement>> IDataRepository<Equipement>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Equipement>> IDataRepository<Equipement>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Equipement>> IDataRepository<Equipement>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Equipement>> GetReference(int id)
        {
            throw new NotImplementedException();
        }
    }
}
