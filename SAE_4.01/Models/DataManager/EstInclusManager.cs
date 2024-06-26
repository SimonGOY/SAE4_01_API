﻿using SAE_4._01.Models.EntityFramework;
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
            return await _dbContext.SontInclus.ToListAsync(); ;
        }

        public async Task<ActionResult<IEnumerable<EstInclus>>> GetByIdOptionAsync(int id)
        {
            return await _dbContext.SontInclus.Where(p => p.IdOption == id).ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<EstInclus>>> GetByIdStyleAsync(int id)
        {
            return await _dbContext.SontInclus.Where(p => p.IdStyle == id).ToListAsync();
        }

        public async Task<ActionResult<EstInclus>> GetBy2CompositeKeysAsync(int id1, int id2)
        {
            return await _dbContext.SontInclus.FirstOrDefaultAsync(e => e.IdOption == id1 && e.IdStyle == id2);
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

        Task<ActionResult<EstInclus>> IDataRepository<EstInclus>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstInclus>>> IDataRepository<EstInclus>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstInclus>>> IDataRepository<EstInclus>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstInclus>>> IDataRepository<EstInclus>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstInclus>>> IDataRepository<EstInclus>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstInclus>>> IDataRepository<EstInclus>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstInclus>>> IDataRepository<EstInclus>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstInclus>>> IDataRepository<EstInclus>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstInclus>>> IDataRepository<EstInclus>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstInclus>>> IDataRepository<EstInclus>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<EstInclus>>> IDataRepository<EstInclus>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<EstInclus>> IDataRepository<EstInclus>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<EstInclus>> IDataRepository<EstInclus>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<EstInclus>> IDataRepository<EstInclus>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<EstInclus>> GetReference(int id)
        {
            throw new NotImplementedException();
        }
    }
}
