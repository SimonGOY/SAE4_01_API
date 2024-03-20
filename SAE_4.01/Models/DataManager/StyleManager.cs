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
    }
}
