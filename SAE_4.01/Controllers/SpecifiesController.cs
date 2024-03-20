﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAE_4._01.Models.EntityFramework;

namespace SAE_4._01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecifiesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        public SpecifiesController(BMWDBContext context)
        {
            _context = context;
        }

        // GET: api/Specifies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specifie>>> GetSpecifies()
        {
          if (_context.Specifies == null)
          {
              return NotFound();
          }
            return await _context.Specifies.ToListAsync();
        }

        // GET: api/Specifies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Specifie>> GetSpecifie(int id)
        {
          if (_context.Specifies == null)
          {
              return NotFound();
          }
            var specifie = await _context.Specifies.FindAsync(id);

            if (specifie == null)
            {
                return NotFound();
            }

            return specifie;
        }

        // PUT: api/Specifies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecifie(int id, Specifie specifie)
        {
            if (id != specifie.IdMoto)
            {
                return BadRequest();
            }

            _context.Entry(specifie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecifieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Specifies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Specifie>> PostSpecifie(Specifie specifie)
        {
          if (_context.Specifies == null)
          {
              return Problem("Entity set 'BMWDBContext.Specifies'  is null.");
          }
            _context.Specifies.Add(specifie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpecifieExists(specifie.IdMoto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSpecifie", new { id = specifie.IdMoto }, specifie);
        }

        // DELETE: api/Specifies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecifie(int id)
        {
            if (_context.Specifies == null)
            {
                return NotFound();
            }
            var specifie = await _context.Specifies.FindAsync(id);
            if (specifie == null)
            {
                return NotFound();
            }

            _context.Specifies.Remove(specifie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecifieExists(int id)
        {
            return (_context.Specifies?.Any(e => e.IdMoto == id)).GetValueOrDefault();
        }
    }
}