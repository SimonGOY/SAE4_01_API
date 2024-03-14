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
    public class EquipementsController : ControllerBase
    {
        private readonly BMWDBContext _context;

        public EquipementsController(BMWDBContext context)
        {
            _context = context;
        }

        // GET: api/Equipements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipement>>> GetEquipements()
        {
            if (_context.Equipements == null)
            {
                return NotFound();
            }
            return await _context.Equipements.ToListAsync();
        }

        // GET: api/Equipements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipement>> GetEquipement(int id)
        {
            if (_context.Equipements == null)
            {
                return NotFound();
            }
            var Equipement = await _context.Equipements.FindAsync(id);

            if (Equipement == null)
            {
                return NotFound();
            }

            return Equipement;
        }

        // PUT: api/Equipements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipement(int id, Equipement Equipement)
        {
            if (id != Equipement.IdEquipement)
            {
                return BadRequest();
            }

            _context.Entry(Equipement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipementExists(id))
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

        // POST: api/Equipements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipement>> PostEquipement(Equipement Equipement)
        {
            if (_context.Equipements == null)
            {
                return Problem("Entity set 'BMWDBContext.Equipements'  is null.");
            }
            _context.Equipements.Add(Equipement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipement", new { id = Equipement.IdEquipement }, Equipement);
        }

        // DELETE: api/Equipements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipement(int id)
        {
            if (_context.Equipements == null)
            {
                return NotFound();
            }
            var Equipement = await _context.Equipements.FindAsync(id);
            if (Equipement == null)
            {
                return NotFound();
            }

            _context.Equipements.Remove(Equipement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipementExists(int id)
        {
            return (_context.Equipements?.Any(e => e.IdEquipement == id)).GetValueOrDefault();
        }
    }
}
