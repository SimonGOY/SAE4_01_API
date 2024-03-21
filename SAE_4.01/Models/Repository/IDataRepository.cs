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
        Task<ActionResult<IEnumerable<TEntity>>> GetByIdTailleAsync(int id);
        Task<ActionResult<IEnumerable<TEntity>>> GetByIdColorisAsync(int id);
        Task<ActionResult<IEnumerable<TEntity>>> GetByIdEquipementAsync(int id);
        Task<ActionResult<IEnumerable<TEntity>>> GetByIdMotoAsync(int id);
        Task<ActionResult<IEnumerable<TEntity>>> GetByIdOptionAsync(int id);
        Task<ActionResult<IEnumerable<TEntity>>> GetByIdPackAsync(int id);
        Task<ActionResult<IEnumerable<TEntity>>> GetByIdClientAsync(int id);
        Task<ActionResult<IEnumerable<TEntity>>> GetByIdConcessionnaireAsync(int id);
        Task<ActionResult<IEnumerable<TEntity>>> GetByIdCommandeAsync(int id);
        Task<ActionResult<IEnumerable<TEntity>>> GetByIdMotoConfigurableAsync(int id);
        Task<ActionResult<IEnumerable<TEntity>>> GetByEquIdEquipementAsync(int id);

        Task<ActionResult<IEnumerable<TEntity>>> GetByIdStyleAsync(int id);
    }
}
