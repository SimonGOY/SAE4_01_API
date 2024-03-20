using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace SAE_4._01.Models.DataManager
{
    public class CouleurManager : IDataRepository<Couleur>
    {
        readonly BMWDBContext _dbContext;

        public CouleurManager() { }

        public CouleurManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Couleur>>> GetAllAsync()
        {
            return await _dbContext.Couleurs.ToListAsync();
        }

        public async Task<ActionResult<Couleur>> GetByIdAsync(int id)
        {
            return await _dbContext.Couleurs.FirstOrDefaultAsync(p => p.IdCouleur == id);
        }

        public async Task AddAsync(Couleur entity)
        {
            await _dbContext.Couleurs.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Couleur clr, Couleur entity)
        {
            _dbContext.Entry(clr).State = EntityState.Modified;
            clr.IdCouleur = entity.IdCouleur;
            clr.IdMoto = entity.IdMoto;
            clr.NomCouleur = entity.NomCouleur;
            clr.PrixCouleur = entity.PrixCouleur;
            clr.DescriptionCouleur = entity.DescriptionCouleur;
            clr.PhotoCouleur = entity.PhotoCouleur;
            clr.MotoCouleur = entity.MotoCouleur;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Couleur clr)
        {
            _dbContext.Couleurs.Remove(clr);
            await _dbContext.SaveChangesAsync();
        }
    }
}
