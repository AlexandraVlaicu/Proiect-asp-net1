using System;
using Microsoft.AspNetCore.Mvc;
using proiectdaw.Models;
using proiectdaw.Data;
using Microsoft.EntityFrameworkCore;

namespace proiectdaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetaliuComandaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DetaliuComandaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DetaliuComanda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetaliuComanda>>> GetDetaliiComanda()
        {
            return await _context.DetaliiComanda.ToListAsync();
        }

        // GET: api/DetaliuComanda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetaliuComanda>> GetDetaliuComanda(int id)
        {
            var detaliuComanda = await _context.DetaliiComanda.FindAsync(id);

            if (detaliuComanda == null)
            {
                return NotFound();
            }

            return detaliuComanda;
        }

        // POST: api/DetaliuComanda
        [HttpPost]
        public async Task<ActionResult<DetaliuComanda>> PostDetaliuComanda(DetaliuComanda detaliuComanda)
        {
            _context.DetaliiComanda.Add(detaliuComanda);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDetaliuComanda), new { id = detaliuComanda.DetaliuComandaID }, detaliuComanda);
        }

        // PUT: api/DetaliuComanda/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetaliuComanda(int id, DetaliuComanda detaliuComanda)
        {
            if (id != detaliuComanda.DetaliuComandaID)
            {
                return BadRequest();
            }

            _context.Entry(detaliuComanda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetaliuComandaExists(id))
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
        public async Task<IActionResult> DeleteDetaliuComanda(int id)
        {
            var detaliuComanda = await _context.DetaliiComanda.FindAsync(id);
            if (detaliuComanda == null)
            {
                return NotFound();
            }

            _context.DetaliiComanda.Remove(detaliuComanda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetaliuComandaExists(int id)
        {
            return _context.DetaliiComanda.Any(e => e.DetaliuComandaID == id);
        }
    }
}

