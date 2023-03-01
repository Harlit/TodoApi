using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcupacionesControladores : ControllerBase
    {
        private readonly Context _context;

        public OcupacionesControladores(Context context)
        {
            _context = context;
        }

        // GET: api/OcupacionesControladores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ocupaciones>>> GetOcupaciones()
        {
          if (_context.Ocupaciones == null)
          {
              return NotFound();
          }
            return await _context.Ocupaciones.ToListAsync();
        }

        // GET: api/OcupacionesControladores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ocupaciones>> GetOcupaciones(int id)
        {
          if (_context.Ocupaciones == null)
          {
              return NotFound();
          }
            var ocupaciones = await _context.Ocupaciones.FindAsync(id);

            if (ocupaciones == null)
            {
                return NotFound();
            }

            return ocupaciones;
        }

        // PUT: api/OcupacionesControladores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOcupaciones(int id, Ocupaciones ocupaciones)
        {
            if (id != ocupaciones.OcupacionId)
            {
                return BadRequest();
            }

            _context.Entry(ocupaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcupacionesExists(id))
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

        // POST: api/OcupacionesControladores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ocupaciones>> PostOcupaciones(Ocupaciones ocupaciones)
        {
          if (_context.Ocupaciones == null)
          {
              return Problem("Entity set 'Context.Ocupaciones'  is null.");
          }
            _context.Ocupaciones.Add(ocupaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOcupaciones", new { id = ocupaciones.OcupacionId }, ocupaciones);
        }

        // DELETE: api/OcupacionesControladores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOcupaciones(int id)
        {
            if (_context.Ocupaciones == null)
            {
                return NotFound();
            }
            var ocupaciones = await _context.Ocupaciones.FindAsync(id);
            if (ocupaciones == null)
            {
                return NotFound();
            }

            _context.Ocupaciones.Remove(ocupaciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OcupacionesExists(int id)
        {
            return (_context.Ocupaciones?.Any(e => e.OcupacionId == id)).GetValueOrDefault();
        }
    }
}
