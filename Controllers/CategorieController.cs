using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proiectdaw.Data;
using proiectdaw.Models;

namespace proiectdaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategorieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DetaliuComanda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorie>>> GetCategorie()
        {
            return await _context.Categorii.ToListAsync();
        }

        // GET: api/DetaliuComanda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorie>> GetCategorie(int id)
        {
            var Categorie = await _context.Categorii.FindAsync(id);

            if (Categorie == null)
            {
                return NotFound();
            }

            return Categorie;
        }

        // POST: api/DetaliuComanda
        [HttpPost]
        public async Task<ActionResult<DetaliuComanda>> PostCategorie(Categorie Categorii)
        {
            _context.Categorii.Add(Categorii);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategorie), new { id = Categorii.CategorieID }, Categorii);
        }

        // PUT: api/DetaliuComanda/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetaliuComanda(int id, Categorie Categorii)
        {
            if (id != Categorii.CategorieID)
            {
                return BadRequest();
            }

            _context.Entry(Categorii).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
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

        // DELETE: api/DetaliuComanda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorie(int id)
        {
            var Categorie = await _context.Categorii.FindAsync(id);
            if (Categorie == null)
            {
                return NotFound();
            }

            _context.Categorii.Remove(Categorie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategorieExists(int id)
        {
            return _context.Categorii.Any(e => e.CategorieID == id);
        }
    }
}




