﻿using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;

namespace SAE_4._01.Models.DataManager
{
    public class MotoDisponibleManager : IDataRepository<MotoDisponible>
    {
        readonly BMWDBContext _dbContext;

        public MotoDisponibleManager() { }

        public MotoDisponibleManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<MotoDisponible>>> GetAllAsync()
        {
            return await _dbContext.MotoDisponibles.ToListAsync();
        }

        public async Task<ActionResult<MotoDisponible>> GetByIdAsync(int id)
        {
            return await _dbContext.MotoDisponibles.FirstOrDefaultAsync(p => p.IdMotoDisponible == id);
        }

        public async Task AddAsync(MotoDisponible entity)
        {
            await _dbContext.MotoDisponibles.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(MotoDisponible mdp, MotoDisponible entity)
        {
            _dbContext.Entry(mdp).State = EntityState.Modified;
            mdp.IdMotoDisponible = entity.IdMotoDisponible;
            mdp.PrixMotoDisponible = entity.PrixMotoDisponible;
            mdp.IdMoto = entity.IdMoto;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MotoDisponible mdp)
        {
            _dbContext.MotoDisponibles.Remove(mdp);
            await _dbContext.SaveChangesAsync();
        }
    }
}
