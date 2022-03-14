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
    public class TbrAlunoTurmaController : ControllerBase
    {
        private readonly academicoContext _context;

        public TbrAlunoTurmaController(academicoContext context)
        {
            _context = context;
        }

        // GET: api/TbrAlunoTurma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbrAlunoTurma>>> GetTbrAlunoTurmas()
        {
            return await _context.TbrAlunoTurmas.ToListAsync();
        }

        // GET: api/TbrAlunoTurma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbrAlunoTurma>> GetTbrAlunoTurma(int id)
        {
            var tbrAlunoTurma = await _context.TbrAlunoTurmas.FindAsync(id);

            if (tbrAlunoTurma == null)
            {
                return NotFound();
            }

            return tbrAlunoTurma;
        }

        // PUT: api/TbrAlunoTurma/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbrAlunoTurma(int id, TbrAlunoTurma tbrAlunoTurma)
        {
            if (id != tbrAlunoTurma.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbrAlunoTurma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbrAlunoTurmaExists(id))
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

        // POST: api/TbrAlunoTurma
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbrAlunoTurma>> PostTbrAlunoTurma(TbrAlunoTurma tbrAlunoTurma)
        {
            _context.TbrAlunoTurmas.Add(tbrAlunoTurma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbrAlunoTurma", new { id = tbrAlunoTurma.Id }, tbrAlunoTurma);
        }

        // DELETE: api/TbrAlunoTurma/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbrAlunoTurma(int id)
        {
            var tbrAlunoTurma = await _context.TbrAlunoTurmas.FindAsync(id);
            if (tbrAlunoTurma == null)
            {
                return NotFound();
            }

            _context.TbrAlunoTurmas.Remove(tbrAlunoTurma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbrAlunoTurmaExists(int id)
        {
            return _context.TbrAlunoTurmas.Any(e => e.Id == id);
        }
    }
}
