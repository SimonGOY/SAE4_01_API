using Microsoft.AspNetCore.Mvc;
using SAE_4._01.Models.EntityFramework;

namespace SAE_4._01.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync();
        Task<ActionResult<TEntity>> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entityToUpdate, TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<ActionResult<Stock>> GetByIdTailleAsync(int id);
        Task<ActionResult<Stock>> GetByIdColorisAsync(int id);
    }
}
