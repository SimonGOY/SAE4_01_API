﻿using SAE_4._01.Models.EntityFramework;
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

        Task<ActionResult<IEnumerable<InfoCB>>> IDataRepository<InfoCB>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<InfoCB>>> IDataRepository<InfoCB>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<InfoCB>>> IDataRepository<InfoCB>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<InfoCB>>> IDataRepository<InfoCB>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<InfoCB>>> IDataRepository<InfoCB>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<InfoCB>>> IDataRepository<InfoCB>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<InfoCB>>> IDataRepository<InfoCB>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<InfoCB>>> IDataRepository<InfoCB>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<InfoCB>>> IDataRepository<InfoCB>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<InfoCB>>> IDataRepository<InfoCB>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<InfoCB>>> IDataRepository<InfoCB>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<InfoCB>>> IDataRepository<InfoCB>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<InfoCB>> IDataRepository<InfoCB>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<InfoCB>> IDataRepository<InfoCB>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<InfoCB>> IDataRepository<InfoCB>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<InfoCB>> IDataRepository<InfoCB>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<InfoCB>> GetReference(int id)
        {
            throw new NotImplementedException();
        }
    }
}
