using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proiectdaw.Data;
using proiectdaw.Models;

namespace proiectdaw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClienti()
        {
            return await _context.Clienti
                .Include(c => c.Comenzi)
                .Include(c => c.Reviews)
                .ToListAsync();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Clienti
                .Include(c => c.Comenzi)
                .Include(c => c.Reviews)
                .FirstOrDefaultAsync(c => c.ClientID == id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // POST: api/Client
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Clienti.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.ClientID }, client);
        }
        // POST: api/Client/AdaugaClientCuComanda
        [HttpPost("AdaugaClientCuComanda")]
        public ActionResult<Client> AdaugaClientCuComanda([FromBody] ClientComandaDto clientComandaDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                
                _context.Clienti.Add(clientComandaDto.Client);

               
                clientComandaDto.Comanda.Client = clientComandaDto.Client;
                _context.Comenzi.Add(clientComandaDto.Comanda);

                _context.SaveChanges();

                return CreatedAtAction(nameof(GetClient), new { id = clientComandaDto.Client.ClientID }, clientComandaDto.Client);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpPost("AdaugaClientCuReview")]
        public ActionResult<Client> AdaugaClientCuReview([FromBody] ClientReviewDto clientReviewDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

           
                _context.Clienti.Add(clientReviewDto.Client);

                
                clientReviewDto.Review.Client = clientReviewDto.Client;
                _context.Reviews.Add(clientReviewDto.Review);

                _context.SaveChanges();

                return CreatedAtAction(nameof(GetClient), new { id = clientReviewDto.Client.ClientID }, clientReviewDto.Client);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.ClientID)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clienti.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clienti.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return _context.Clienti.Any(e => e.ClientID == id);
        }
    }

}

