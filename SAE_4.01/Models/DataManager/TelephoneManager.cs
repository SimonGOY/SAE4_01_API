﻿using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class TelephoneManager : IDataRepository<Telephone>
    {
        readonly BMWDBContext _dbContext;

        public TelephoneManager() { }

        public TelephoneManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Telephone>>> GetAllAsync()
        {
            return await _dbContext.Telephones.ToListAsync();
        }

        public async Task<ActionResult<Telephone>> GetByIdAsync(int id)
        {
            return await _dbContext.Telephones.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Telephone entity)
        {
            await _dbContext.Telephones.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Telephone tel, Telephone entity)
        {
            _dbContext.Entry(tel).State = EntityState.Modified;
            tel.Id = entity.Id;
            tel.IdClient = entity.IdClient;
            tel.NumTelephone = entity.NumTelephone;
            tel.Type = entity.Type;
            tel.Fonction = entity.Fonction;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Telephone use)
        {
            _dbContext.Telephones.Remove(use);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Telephone>>> IDataRepository<Telephone>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Telephone>>> IDataRepository<Telephone>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Telephone>>> IDataRepository<Telephone>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Telephone>>> IDataRepository<Telephone>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Telephone>>> IDataRepository<Telephone>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Telephone>>> IDataRepository<Telephone>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Telephone>>> IDataRepository<Telephone>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Telephone>>> IDataRepository<Telephone>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Telephone>>> IDataRepository<Telephone>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Telephone>>> IDataRepository<Telephone>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Telephone>>> IDataRepository<Telephone>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Telephone>>> IDataRepository<Telephone>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Telephone>> IDataRepository<Telephone>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Telephone>> IDataRepository<Telephone>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Telephone>> IDataRepository<Telephone>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Telephone>> IDataRepository<Telephone>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Telephone>> GetReference(int id)
        {
            throw new NotImplementedException();
        }
    }
}
