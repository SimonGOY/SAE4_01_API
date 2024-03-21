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

        Task<ActionResult<Stock>> IDataRepository<Equipement>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Stock>> IDataRepository<Equipement>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
