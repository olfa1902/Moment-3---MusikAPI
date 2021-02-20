using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moment_3___MusikAPI.Data;
using Moment_3___MusikAPI.Models;

namespace Moment_3___MusikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusikController : ControllerBase
    {
        private readonly MusikKontext _context;

        public MusikController(MusikKontext context)
        {
            _context = context;
        }

        // GET: api/Musik
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musik>>> Getmusik()
        {
            return await _context.musik.ToListAsync();
        }

        // GET: api/Musik/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musik>> GetMusik(int id)
        {
            var musik = await _context.musik.FindAsync(id);

            if (musik == null)
            {
                return NotFound();
            }

            return musik;
        }

        // PUT: api/Musik/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusik(int id, Musik musik)
        {
            if (id != musik.Id)
            {
                return BadRequest();
            }

            _context.Entry(musik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusikExists(id))
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

        // POST: api/Musik
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Musik>> PostMusik(Musik musik)
        {
            _context.musik.Add(musik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusik", new { id = musik.Id }, musik);
        }

        // DELETE: api/Musik/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusik(int id)
        {
            var musik = await _context.musik.FindAsync(id);
            if (musik == null)
            {
                return NotFound();
            }

            _context.musik.Remove(musik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusikExists(int id)
        {
            return _context.musik.Any(e => e.Id == id);
        }
    }
}
