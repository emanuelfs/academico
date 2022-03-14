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
    public class TbAlunoController : ControllerBase
    {
        private readonly academicoContext _context;

        public TbAlunoController(academicoContext context)
        {
            _context = context;
        }

        // GET: api/TbAluno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbAluno>>> GetTbAlunos()
        {
            return await _context.TbAlunos.ToListAsync();
        }

        // GET: api/TbAluno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbAluno>> GetTbAluno(int id)
        {
            var tbAluno = await _context.TbAlunos.FindAsync(id);

            if (tbAluno == null)
            {
                return NotFound();
            }

            return tbAluno;
        }

        // PUT: api/TbAluno/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbAluno(int id, TbAluno tbAluno)
        {
            if (id != tbAluno.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbAluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbAlunoExists(id))
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

        // POST: api/TbAluno
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbAluno>> PostTbAluno(TbAluno tbAluno)
        {
            _context.TbAlunos.Add(tbAluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbAluno", new { id = tbAluno.Id }, tbAluno);
        }

        // DELETE: api/TbAluno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbAluno(int id)
        {
            var tbAluno = await _context.TbAlunos.FindAsync(id);
            if (tbAluno == null)
            {
                return NotFound();
            }

            _context.TbAlunos.Remove(tbAluno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbAlunoExists(int id)
        {
            return _context.TbAlunos.Any(e => e.Id == id);
        }
    }
}
