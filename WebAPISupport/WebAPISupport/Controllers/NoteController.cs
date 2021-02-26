using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPISupport.Models;

namespace WebAPISupport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly SupportApplicationContext _context;

        public NoteController()
        {
            _context = new SupportApplicationContext();
        }

        // GET: api/Note
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotes()
        {
            return await _context.Note.ToListAsync();
        }

        
        [Route("[action]/{id}")]
        public Note GetNoteForIssue(int id)
        {
            var student = _context.Note.Where(a => a.IssueId.Equals(id)).First();
            return student;

        }

        // GET: api/Note/5
        [Route("[action]")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            var note = await _context.Note.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return note;
        }

        // PUT: api/Note/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("[action]/{id}")]
        public async Task<IActionResult> PutNote(int id, Note note)
        {
            if (id != note.IssueId)
            {
                return BadRequest();
            }

            _context.Entry(note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
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

        // POST: api/Note
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("[action]")]
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            _context.Note.Add(note);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NoteExists(note.EmployeeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNote", new { id = note.EmployeeId }, note);
        }

        // DELETE: api/Note/5
        [Route("[action]")]
        public async Task<ActionResult<Note>> DeleteNote(int id)
        {
            var note = await _context.Note.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            _context.Note.Remove(note);
            await _context.SaveChangesAsync();

            return note;
        }

        private bool NoteExists(int id)
        {
            return _context.Note.Any(e => e.EmployeeId == id);
        }
    }
}
