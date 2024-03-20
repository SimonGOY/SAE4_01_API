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
    public class SeComposeController : ControllerBase
    {
        private readonly BMWDBContext _context;

        public SeComposeController(BMWDBContext context)
        {
            _context = context;
        }

        // GET: api/SeCompose
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeCompose>>> GetSeComposes()
        {
          if (_context.SeComposes == null)
          {
              return NotFound();
          }
            return await _context.SeComposes.ToListAsync();
        }

        // GET: api/SeCompose/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeCompose>> GetSeCompose(int id)
        {
          if (_context.SeComposes == null)
          {
              return NotFound();
          }
            var seCompose = await _context.SeComposes.FindAsync(id);

            if (seCompose == null)
            {
                return NotFound();
            }

            return seCompose;
        }

        // PUT: api/SeCompose/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeCompose(int id, SeCompose seCompose)
        {
            if (id != seCompose.IdPack)
            {
                return BadRequest();
            }

            _context.Entry(seCompose).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeComposeExists(id))
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

        // POST: api/SeCompose
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeCompose>> PostSeCompose(SeCompose seCompose)
        {
          if (_context.SeComposes == null)
          {
              return Problem("Entity set 'BMWDBContext.SeComposes'  is null.");
          }
            _context.SeComposes.Add(seCompose);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SeComposeExists(seCompose.IdPack))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSeCompose", new { id = seCompose.IdPack }, seCompose);
        }

        // DELETE: api/SeCompose/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeCompose(int id)
        {
            if (_context.SeComposes == null)
            {
                return NotFound();
            }
            var seCompose = await _context.SeComposes.FindAsync(id);
            if (seCompose == null)
            {
                return NotFound();
            }

            _context.SeComposes.Remove(seCompose);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeComposeExists(int id)
        {
            return (_context.SeComposes?.Any(e => e.IdPack == id)).GetValueOrDefault();
        }
    }
}