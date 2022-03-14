#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using academico.Models;

namespace academico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbTurmaController : ControllerBase
    {
        private readonly academicoContext _context;

        public TbTurmaController(academicoContext context)
        {
            _context = context;
        }

        // GET: api/TbTurma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbTurma>>> GetTbTurmas()
        {
            return await _context.TbTurmas.ToListAsync();
        }

        // GET: api/TbTurma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbTurma>> GetTbTurma(int id)
        {
            var tbTurma = await _context.TbTurmas.FindAsync(id);

            if (tbTurma == null)
            {
                return NotFound();
            }

            return tbTurma;
        }

        // PUT: api/TbTurma/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbTurma(int id, TbTurma tbTurma)
        {
            if (id != tbTurma.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbTurma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbTurmaExists(id))
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

        // POST: api/TbTurma
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbTurma>> PostTbTurma(TbTurma tbTurma)
        {
            _context.TbTurmas.Add(tbTurma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbTurma", new { id = tbTurma.Id }, tbTurma);
        }

        // DELETE: api/TbTurma/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbTurma(int id)
        {
            var tbTurma = await _context.TbTurmas.FindAsync(id);
            if (tbTurma == null)
            {
                return NotFound();
            }

            _context.TbTurmas.Remove(tbTurma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbTurmaExists(int id)
        {
            return _context.TbTurmas.Any(e => e.Id == id);
        }
    }
}
