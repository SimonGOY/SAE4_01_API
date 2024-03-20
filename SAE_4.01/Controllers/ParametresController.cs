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
    public class ParametresController : ControllerBase
    {
        private readonly BMWDBContext _context;

        public ParametresController(BMWDBContext context)
        {
            _context = context;
        }

        // GET: api/Parametres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parametres>>> GetParametres()
        {
          if (_context.Parametres == null)
          {
              return NotFound();
          }
            return await _context.Parametres.ToListAsync();
        }

        // GET: api/Parametres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parametres>> GetParametres(string id)
        {
          if (_context.Parametres == null)
          {
              return NotFound();
          }
            var parametres = await _context.Parametres.FindAsync(id);

            if (parametres == null)
            {
                return NotFound();
            }

            return parametres;
        }

        // PUT: api/Parametres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParametres(string id, Parametres parametres)
        {
            if (id != parametres.NomParametre)
            {
                return BadRequest();
            }

            _context.Entry(parametres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParametresExists(id))
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

        // POST: api/Parametres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Parametres>> PostParametres(Parametres parametres)
        {
          if (_context.Parametres == null)
          {
              return Problem("Entity set 'BMWDBContext.Parametres'  is null.");
          }
            _context.Parametres.Add(parametres);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ParametresExists(parametres.NomParametre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetParametres", new { id = parametres.NomParametre }, parametres);
        }

        // DELETE: api/Parametres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParametres(string id)
        {
            if (_context.Parametres == null)
            {
                return NotFound();
            }
            var parametres = await _context.Parametres.FindAsync(id);
            if (parametres == null)
            {
                return NotFound();
            }

            _context.Parametres.Remove(parametres);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParametresExists(string id)
        {
            return (_context.Parametres?.Any(e => e.NomParametre == id)).GetValueOrDefault();
        }
    }
}