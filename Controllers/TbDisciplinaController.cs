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
    public class TbDisciplinaController : ControllerBase
    {
        private readonly academicoContext _context;

        public TbDisciplinaController(academicoContext context)
        {
            _context = context;
        }

        // GET: api/TbDisciplina
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDisciplina>>> GetTbDisciplinas()
        {
            return await _context.TbDisciplinas.ToListAsync();
        }

        // GET: api/TbDisciplina/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDisciplina>> GetTbDisciplina(int id)
        {
            var tbDisciplina = await _context.TbDisciplinas.FindAsync(id);

            if (tbDisciplina == null)
            {
                return NotFound();
            }

            return tbDisciplina;
        }

        // PUT: api/TbDisciplina/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDisciplina(int id, TbDisciplina tbDisciplina)
        {
            if (id != tbDisciplina.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbDisciplina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDisciplinaExists(id))
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

        // POST: api/TbDisciplina
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbDisciplina>> PostTbDisciplina(TbDisciplina tbDisciplina)
        {
            _context.TbDisciplinas.Add(tbDisciplina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbDisciplina", new { id = tbDisciplina.Id }, tbDisciplina);
        }

        // DELETE: api/TbDisciplina/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDisciplina(int id)
        {
            var tbDisciplina = await _context.TbDisciplinas.FindAsync(id);
            if (tbDisciplina == null)
            {
                return NotFound();
            }

            _context.TbDisciplinas.Remove(tbDisciplina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDisciplinaExists(int id)
        {
            return _context.TbDisciplinas.Any(e => e.Id == id);
        }
    }
}
