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
    public class TbProfessorController : ControllerBase
    {
        private readonly academicoContext _context;

        public TbProfessorController(academicoContext context)
        {
            _context = context;
        }

        // GET: api/TbProfessor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbProfessor>>> GetTbProfessors()
        {
            return await _context.TbProfessors.ToListAsync();
        }

        // GET: api/TbProfessor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbProfessor>> GetTbProfessor(int id)
        {
            var tbProfessor = await _context.TbProfessors.FindAsync(id);

            if (tbProfessor == null)
            {
                return NotFound();
            }

            return tbProfessor;
        }

        // PUT: api/TbProfessor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbProfessor(int id, TbProfessor tbProfessor)
        {
            if (id != tbProfessor.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbProfessor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbProfessorExists(id))
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

        // POST: api/TbProfessor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbProfessor>> PostTbProfessor(TbProfessor tbProfessor)
        {
            _context.TbProfessors.Add(tbProfessor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbProfessor", new { id = tbProfessor.Id }, tbProfessor);
        }

        // DELETE: api/TbProfessor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbProfessor(int id)
        {
            var tbProfessor = await _context.TbProfessors.FindAsync(id);
            if (tbProfessor == null)
            {
                return NotFound();
            }

            _context.TbProfessors.Remove(tbProfessor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbProfessorExists(int id)
        {
            return _context.TbProfessors.Any(e => e.Id == id);
        }
    }
}
