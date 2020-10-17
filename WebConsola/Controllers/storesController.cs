using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CEntidades;
using WebConsola.Data;

namespace WebConsola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class storesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public storesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/stores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<stores>>> Getstores()
        {
            return await _context.stores.ToListAsync();
        }

        // GET: api/stores/5
        /// <summary>
        /// GET por ID del Store
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<stores>> Getstores(int id)
        {
            var stores = await _context.stores.FindAsync(id);

            if (stores == null)
            {
                return NotFound();
            }

            return stores;
        }

        // PUT: api/stores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putstores(int id, stores stores)
        {
            if (id != stores.storesid)
            {
                return BadRequest();
            }

            _context.Entry(stores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!storesExists(id))
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

        // POST: api/stores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// POST DE STORES 
        /// </summary>
        /// <param name="stores"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<stores>> Poststores(stores stores)
        {
            _context.stores.Add(stores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getstores", new { id = stores.storesid }, stores);
        }

        // DELETE: api/stores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<stores>> Deletestores(int id)
        {
            var stores = await _context.stores.FindAsync(id);
            if (stores == null)
            {
                return NotFound();
            }

            _context.stores.Remove(stores);
            await _context.SaveChangesAsync();

            return stores;
        }

        private bool storesExists(int id)
        {
            return _context.stores.Any(e => e.storesid == id);
        }
    }
}
