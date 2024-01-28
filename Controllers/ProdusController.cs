using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiectdaw.Models;
using proiectdaw.Data;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectdaw.Controllers
{ 
 

    [Route("api/[controller]")]
    [ApiController]
    public class ProdusController : ControllerBase
    {
        private readonly ApplicationDbContext _context; 

        public ProdusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Produs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produs>>> GetProduse()
        {
            
            var produse = await _context.Produse
                .Include(p => p.Categorii)
                .Include(p => p.Reviews)
                .ToListAsync();

            return produse;
        }

        // GET: api/Produs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produs>> GetProdus(int id)
        {
           
            var produs = await _context.Produse
                .Include(p => p.Categorii)
                .Include(p => p.Reviews)
                .Where(p => p.ProdusID == id)
                .FirstOrDefaultAsync();

            if (produs == null)
            {
                return NotFound();
            }

            return produs;
        }

        // GET: api/Produs/Categorie/1
        [HttpGet("Categorie/{categorieId}")]
        public async Task<ActionResult<IEnumerable<Produs>>> GetProduseByCategorie(int categorieId)
        {
           
            var produse = await _context.Produse
                .Where(p => p.CategorieId == categorieId)
                .ToListAsync();

            return produse;
        }

        // GET: api/Produs/Grupare
        [HttpGet("Grupare")]
        public async Task<ActionResult<IEnumerable<IGrouping<int, Produs>>>> GetProduseGroupedByCategorie()
        {
            
            var produseGrupate = await _context.Produse
                .GroupBy(p => p.CategorieId)
                .ToListAsync();

            return produseGrupate;
        }
        //
        [HttpPost]
        public async Task<ActionResult<Produs>> PostProdus(Produs produs)
        {
            _context.Produse.Add(produs);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdus), new { id = produs.ProdusID }, produs);
        }
        [HttpPost("AdaugaProdusCuDetalii")]
        public async Task<ActionResult<Produs>> AdaugaProdusCuDetalii([FromBody] ProdusDTo ProdusDto)
        {
           
            _context.Produse.Add(ProdusDto.Produs);

           
            ProdusDto.DetaliiComanda.ForEach(dc => ProdusDto.Produs.DetaliiComanda.Add(dc));

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdus), new { id = ProdusDto.Produs.ProdusID }, ProdusDto.Produs);
        }


        [HttpPost("AdaugaProdusCuCategorie")]
        public async Task<ActionResult<Produs>> AdaugaProdusCuCategorie([FromBody] CategorieDto adaugaProdusDto)
        {
            try
            {
            
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

               
                _context.Categorii.Add(adaugaProdusDto.Categorie);

               
                adaugaProdusDto.Produs.Categorii = adaugaProdusDto.Categorie;

          
                _context.Produse.Add(adaugaProdusDto.Produs);

                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProdus), new { id = adaugaProdusDto.Produs.ProdusID }, adaugaProdusDto.Produs);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }



        // PUT: api/Produs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdus(int id, Produs produs)
        {
            
            var existingProdus = await _context.Produse
                .Where(p => p.ProdusID == id)
                .FirstOrDefaultAsync();

            if (existingProdus == null)
            {
                return NotFound();
            }

            
            existingProdus.Nume = produs.Nume;
            existingProdus.Pret = produs.Pret;
            existingProdus.Stoc = produs.Stoc;
            existingProdus.Descriere = produs.Descriere;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Produs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdus(int id)
        {
            
            var produsToDelete = await _context.Produse
                .Where(p => p.ProdusID == id)
                .Include(p => p.DetaliiComanda)
                .FirstOrDefaultAsync();

            if (produsToDelete == null)
            {
                return NotFound();
            }

            _context.Produse.Remove(produsToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdusExists(int id)
        {
            return _context.Produse.Any(e => e.ProdusID == id);
        }
    }


}

