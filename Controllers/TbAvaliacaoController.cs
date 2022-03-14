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
    public class TbAvaliacaoController : ControllerBase
    {
        private readonly academicoContext _context;

        public TbAvaliacaoController(academicoContext context)
        {
            _context = context;
        }

        // GET: api/TbAvaliacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbAvaliacao>>> GetTbAvaliacaos()
        {
            return await _context.TbAvaliacaos.ToListAsync();
        }

        // GET: api/TbAvaliacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbAvaliacao>> GetTbAvaliacao(int id)
        {
            var tbAvaliacao = await _context.TbAvaliacaos.FindAsync(id);

            if (tbAvaliacao == null)
            {
                return NotFound();
            }

            return tbAvaliacao;
        }

        // PUT: api/TbAvaliacao/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbAvaliacao(int id, TbAvaliacao tbAvaliacao)
        {
            if (id != tbAvaliacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbAvaliacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbAvaliacaoExists(id))
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

        // POST: api/TbAvaliacao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbAvaliacao>> PostTbAvaliacao(TbAvaliacao tbAvaliacao)
        {
            _context.TbAvaliacaos.Add(tbAvaliacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbAvaliacao", new { id = tbAvaliacao.Id }, tbAvaliacao);
        }

        // DELETE: api/TbAvaliacao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbAvaliacao(int id)
        {
            var tbAvaliacao = await _context.TbAvaliacaos.FindAsync(id);
            if (tbAvaliacao == null)
            {
                return NotFound();
            }

            _context.TbAvaliacaos.Remove(tbAvaliacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbAvaliacaoExists(int id)
        {
            return _context.TbAvaliacaos.Any(e => e.Id == id);
        }
    }
}
