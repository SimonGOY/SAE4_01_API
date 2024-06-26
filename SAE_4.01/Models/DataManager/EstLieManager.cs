﻿using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace SAE_4._01.Models.DataManager
{
    public class EstLieManager : IDataRepository<EstLie>
    {
        readonly BMWDBContext _dbContext;

        public EstLieManager() { }

        public EstLieManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<EstLie>>> GetAllAsync()
        {
            return await _dbContext.SontLies.ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<EstLie>>> GetByIdEquipementAsync(int id)
        {
            return await _dbContext.SontLies.Where(p => p.IdEquipement == id).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<EstLie>>> GetByEquIdEquipementAsync(int id)
        {
            return await _dbContext.SontLies.Where(p => p.EquIdEquipement == id).ToListAsync();
        }

        public async Task<ActionResult<EstLie>> GetBy2CompositeKeysAsync(int id1, int id2)
        {
            return await _dbContext.SontLies.FirstOrDefaultAsync(e => e.IdEquipement == id1 && e.EquIdEquipement == id2);
        }

        public async Task AddAsync(EstLie entity)
        {
            await _dbContext.SontLies.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(EstLie eli, EstLie entity)
        {
            _dbContext.Entry(eli).State = EntityState.Modified;
            eli.IdEquipement = entity.IdEquipement;
            eli.EquIdEquipement = entity.EquIdEquipement;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(EstLie eli)
        {
            _dbContext.SontLies.Remove(eli);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<EstLie>> IDataRepository<EstLie>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstLie>>> IDataRepository<EstLie>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstLie>>> IDataRepository<EstLie>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstLie>>> IDataRepository<EstLie>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstLie>>> IDataRepository<EstLie>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstLie>>> IDataRepository<EstLie>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstLie>>> IDataRepository<EstLie>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstLie>>> IDataRepository<EstLie>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstLie>>> IDataRepository<EstLie>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstLie>>> IDataRepository<EstLie>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstLie>>> IDataRepository<EstLie>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<EstLie>> IDataRepository<EstLie>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<EstLie>> IDataRepository<EstLie>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<EstLie>> IDataRepository<EstLie>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<EstLie>> GetReference(int id)
        {
            throw new NotImplementedException();
        }
    }
}
