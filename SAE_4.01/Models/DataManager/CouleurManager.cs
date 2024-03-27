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


        public async Task<ActionResult<IEnumerable<Couleur>>> GetByIdMotoAsync(int id)
        {
            return await _dbContext.Couleurs.Where(p => p.IdMoto == id).ToListAsync();
        }

        Task<ActionResult<IEnumerable<Couleur>>> IDataRepository<Couleur>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Couleur>>> IDataRepository<Couleur>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Couleur>>> IDataRepository<Couleur>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        

        Task<ActionResult<IEnumerable<Couleur>>> IDataRepository<Couleur>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Couleur>>> IDataRepository<Couleur>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Couleur>>> IDataRepository<Couleur>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Couleur>>> IDataRepository<Couleur>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Couleur>>> IDataRepository<Couleur>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Couleur>>> IDataRepository<Couleur>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Couleur>>> IDataRepository<Couleur>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Couleur>>> IDataRepository<Couleur>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Couleur>> IDataRepository<Couleur>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Couleur>> IDataRepository<Couleur>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Couleur>> IDataRepository<Couleur>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Couleur>> IDataRepository<Couleur>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }
    }
}
