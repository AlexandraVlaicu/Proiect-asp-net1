using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proiectdaw.Data;
using proiectdaw.Models;

namespace proiectdaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComandaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Comanda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comanda>>> GetComenzi()
        {
            return await _context.Comenzi
                .Include(c => c.Produse)
                .Include(c => c.DetaliiComanda)
                .Include(c => c.Livrare)
                .Include(c => c.Client)
                .ToListAsync();
        }

        // GET: api/Comanda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comanda>> GetComanda(int id)
        {
            var comanda = await _context.Comenzi
                .Include(c => c.Produse)
                .Include(c => c.DetaliiComanda)
                .Include(c => c.Livrare)
                .Include(c => c.Client)
                .FirstOrDefaultAsync(c => c.ComandaID == id);

            if (comanda == null)
            {
                return NotFound();
            }

            return comanda;
        }

        // POST: api/Comanda
        [HttpPost]
        public async Task<ActionResult<Comanda>> PostComanda(Comanda comanda)
        {
            _context.Comenzi.Add(comanda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComanda", new { id = comanda.ComandaID }, comanda);
        }
        [HttpPost("AdaugaComandaCuProduse")]
        public async Task<ActionResult<Comanda>> AdaugaComandaCuProduse([FromBody] ComandaProduseDto comandaProduseDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

            
                _context.Comenzi.Add(comandaProduseDto.Comanda);

                
                comandaProduseDto.Produse.ForEach(p => comandaProduseDto.Comanda.Produse.Add(p));

                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetComanda), new { id = comandaProduseDto.Comanda.ComandaID }, comandaProduseDto.Comanda);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/DetaliuComanda/AdaugaDetaliiComanda
        [HttpPost("AdaugaDetaliiComanda")]
        public async Task<ActionResult<List<DetaliuComanda>>> AdaugaDetaliiComanda([FromBody] List<DetaliuComanda> detaliiComanda)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                
                _context.DetaliiComanda.AddRange(detaliiComanda);

                await _context.SaveChangesAsync();

                return detaliiComanda;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }



        // PUT: api/Comanda/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComanda(int id, Comanda comanda)
        {
            if (id != comanda.ComandaID)
            {
                return BadRequest();
            }

            _context.Entry(comanda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComandaExists(id))
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

        // DELETE: api/Comanda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComanda(int id)
        {
            var comanda = await _context.Comenzi.FindAsync(id);
            if (comanda == null)
            {
                return NotFound();
            }

            _context.Comenzi.Remove(comanda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComandaExists(int id)
        {
            return _context.Comenzi.Any(e => e.ComandaID == id);
        }
    }

}

