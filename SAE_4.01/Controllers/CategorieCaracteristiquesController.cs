﻿using System;
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
    public class CategorieCaracteristiquesController : ControllerBase
    {
        private readonly BMWDBContext _context;

        private readonly IDataRepository<CategorieCaracteristique> dataRepository;

        public CategorieCaracteristiquesController(IDataRepository<CategorieCaracteristique> dataRepo)
        {
            dataRepository = dataRepo;
        }

        // GET: api/CategorieCaracteristiques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieCaracteristique>>> GetCategorieCaracteristiques()
        {
            return await dataRepository.GetAllAsync();
        }

        // GET: api/CategorieCaracteristiques/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorieCaracteristique>> GetCategorieCaracteristique(int id)
        {

            var categorieCaracteristique  = await dataRepository.GetByIdAsync(id);

            if (categorieCaracteristique == null)
            {
                return NotFound();
            }

            return categorieCaracteristique;
        }

        // POST: api/CategorieCaracteristiques
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = Policies.Type2)]
        public async Task<ActionResult<CategorieCaracteristique>> PostCategorieCaracteristique(CategorieCaracteristique categorieCaracteristique)
        {
            if (categorieCaracteristique == null)
            {
                return Problem("Entity set 'BMWDBContext.CategorieCaracteristique'  is null.");
            }
            await dataRepository.AddAsync(categorieCaracteristique);

            return CreatedAtAction("GetCategorieCaracteristique", new { id = categorieCaracteristique.IdCatCaracteristique }, categorieCaracteristique);
        }

        // DELETE: api/CategorieCaracteristiques/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Type2)]
        public async Task<IActionResult> DeleteCategorieCaracteristique(int id)
        {
            var categorieCaracteristique = await dataRepository.GetByIdAsync(id);

            if (categorieCaracteristique == null)
            {
                return NotFound();
            }

            await dataRepository.DeleteAsync(categorieCaracteristique.Value);

            return NoContent();
        }

        private bool CategorieCaracteristiqueExists(int id)
        {
            return (_context.CategorieCaracteristiques?.Any(e => e.IdCatCaracteristique == id)).GetValueOrDefault();
        }
    }
}
