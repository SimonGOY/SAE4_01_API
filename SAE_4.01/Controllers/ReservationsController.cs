using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_4._01.Models.EntityFramework;
using SAE_4._01.Models.Repository;

namespace SAE_4._01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<Reservation> dataRepository;

        public ReservationsController(IDataRepository<Reservation> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/Reservations
        [HttpGet]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {

            var reservation = await dataRepository.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        // PUT: api/Reservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.IdReservation)
            {
                return BadRequest();
            }

            var resToUpdate = await dataRepository.GetByIdAsync(id);

            if (resToUpdate == null)
            {
                return NotFound();
            }
            else
            {
                await dataRepository.UpdateAsync(resToUpdate.Value, reservation);
                return NoContent();
            }
        }

        // POST: api/Reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type0)]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                return Problem("Entity set 'BMWDBContext.Reservations'  is null.");
            }
            await dataRepository.AddAsync(reservation);

            return CreatedAtAction("GetReservation", new { id = reservation.IdReservation }, reservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await dataRepository.GetByIdAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(reservation.Value);

            return NoContent();
        }

        private bool ReservationExists(int id)
        {
            return (_context.Reservations?.Any(e => e.IdReservation == id)).GetValueOrDefault();
        }
    }
}
