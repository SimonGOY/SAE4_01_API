using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SAE_4._01.Models.DataManager
{
    public class ReservationManager : IDataRepository<Reservation>
    {
        readonly BMWDBContext _dbContext;

        public ReservationManager() { }

        public ReservationManager(BMWDBContext context)
        {
            _dbContext = context;
        }

        public async Task<ActionResult<IEnumerable<Reservation>>> GetAllAsync()
        {
            return await _dbContext.Reservations.ToListAsync();
        }

        public async Task<ActionResult<Reservation>> GetByIdAsync(int id)
        {
            return await _dbContext.Reservations.FirstOrDefaultAsync(p => p.IdReservation == id);
        }

        public async Task AddAsync(Reservation entity)
        {
            await _dbContext.Reservations.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reservation res, Reservation entity)
        {
            _dbContext.Entry(res).State = EntityState.Modified;
            res.IdReservation = entity.IdReservation;
            res.IdMotoDisponible = entity.IdMotoDisponible;
            res.IdClient = entity.IdClient;
            res.IdConcessionnaire = entity.IdConcessionnaire;
            res.DateReservation = entity.DateReservation;
            res.FinancementReservation = entity.FinancementReservation;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Reservation res)
        {
            _dbContext.Reservations.Remove(res);
            await _dbContext.SaveChangesAsync();
        }

        Task<ActionResult<IEnumerable<Reservation>>> IDataRepository<Reservation>.GetByIdTailleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Reservation>>> IDataRepository<Reservation>.GetByIdColorisAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Reservation>>> IDataRepository<Reservation>.GetByIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Reservation>>> IDataRepository<Reservation>.GetByIdMotoAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Reservation>>> IDataRepository<Reservation>.GetByIdOptionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Reservation>>> IDataRepository<Reservation>.GetByIdPackAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Reservation>>> IDataRepository<Reservation>.GetByIdClientAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Reservation>>> IDataRepository<Reservation>.GetByIdConcessionnaireAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Reservation>>> IDataRepository<Reservation>.GetByIdCommandeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Reservation>>> IDataRepository<Reservation>.GetByIdMotoConfigurableAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Reservation>>> IDataRepository<Reservation>.GetByEquIdEquipementAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ActionResult<IEnumerable<Reservation>>> IDataRepository<Reservation>.GetByIdStyleAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
