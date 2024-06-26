﻿using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class ColorisManager : IDataRepository<Coloris>
    {
        readonly BMWDBContext _dbContext;

        public ColorisManager() { }

        public ColorisManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Coloris>>> GetAllAsync()
        {
            return await _dbContext.LesColoris.ToListAsync();
        }

        public async Task<ActionResult<Coloris>> GetByIdAsync(int id)
        {
            return await _dbContext.LesColoris.FirstOrDefaultAsync(p => p.IdColoris == id);
        }

        public async Task AddAsync(Coloris entity)
        {
            await _dbContext.LesColoris.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Coloris cls, Coloris entity)
        {
            _dbContext.Entry(cls).State = EntityState.Modified;
            cls.IdColoris = entity.IdColoris;
            cls.NomColoris = entity.NomColoris;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Coloris cls)
        {
            _dbContext.LesColoris.Remove(cls);
            await _dbContext.SaveChangesAsync();
        }


        Task<ActionResult<IEnumerable<Coloris>>> IDataRepository<Coloris>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Coloris>>> IDataRepository<Coloris>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Coloris>>> IDataRepository<Coloris>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Coloris>>> IDataRepository<Coloris>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Coloris>>> IDataRepository<Coloris>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Coloris>>> IDataRepository<Coloris>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Coloris>>> IDataRepository<Coloris>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Coloris>>> IDataRepository<Coloris>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Coloris>>> IDataRepository<Coloris>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Coloris>>> IDataRepository<Coloris>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Coloris>>> IDataRepository<Coloris>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Coloris>>> IDataRepository<Coloris>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Coloris>> IDataRepository<Coloris>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Coloris>> IDataRepository<Coloris>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Coloris>> IDataRepository<Coloris>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Coloris>> IDataRepository<Coloris>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Coloris>> GetReference(int id)
        {
            throw new NotImplementedException();
        }
    }
}
