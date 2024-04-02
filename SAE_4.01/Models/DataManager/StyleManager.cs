using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class StyleManager : IDataRepository<Style>
    {
        readonly BMWDBContext _dbContext;

        public StyleManager() { }

        public StyleManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Style>>> GetAllAsync()
        {
            return await _dbContext.Styles.ToListAsync();
        }

        public async Task<ActionResult<Style>> GetByIdAsync(int id)
        {
            return await _dbContext.Styles.FirstOrDefaultAsync(p => p.IdStyle == id);
        }

        public async Task AddAsync(Style entity)
        {
            await _dbContext.Styles.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Style sty, Style entity)
        {
            _dbContext.Entry(sty).State = EntityState.Modified;
            sty.IdStyle = entity.IdStyle;
            sty.NomStyle = entity.NomStyle;
            sty.PrixStyle = entity.PrixStyle;
            sty.DescriptionStyle = entity.DescriptionStyle;
            sty.PhotoStyle = entity.PhotoStyle;
            sty.IdMoto = entity.IdMoto;
            sty.PhotoMoto = entity.PhotoMoto;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Style sty)
        {
            _dbContext.Styles.Remove(sty);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<IEnumerable<Style>>> GetByIdMotoAsync(int id)
        {
            return await _dbContext.Styles.Where(p => p.IdMoto == id).ToListAsync();
        }

        Task<ActionResult<IEnumerable<Style>>> IDataRepository<Style>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Style>>> IDataRepository<Style>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Style>>> IDataRepository<Style>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Style>>> IDataRepository<Style>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Style>>> IDataRepository<Style>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Style>>> IDataRepository<Style>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Style>>> IDataRepository<Style>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Style>>> IDataRepository<Style>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Style>>> IDataRepository<Style>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Style>>> IDataRepository<Style>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Style>>> IDataRepository<Style>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Style>> IDataRepository<Style>.GetBy2CompositeKeysAsync(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Style>> IDataRepository<Style>.GetBy3CompositeKeysAsync(int id1, int id2, int id3)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Style>> IDataRepository<Style>.GetBy4CompositeKeysAsync(int id1, int id2, int id3, int id4)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<Style>> IDataRepository<Style>.GetByNomAsync(string nom)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Style>> GetReference(int id)
        {
            throw new NotImplementedException();
        }
    }
}
