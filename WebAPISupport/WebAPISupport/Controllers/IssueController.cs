using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPISupport.Models;

namespace WebAPISupport.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly SupportApplicationContext _context;

        public IssueController()
        {
            _context = new SupportApplicationContext();
        }

        // GET: api/Issue
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<Issue>>> GetIssues()
        {
            return await _context.Issue.ToListAsync();
        }

        // GET: api/Issue/5
        [Route("[action]")]
        public async Task<ActionResult<Issue>> GetIssue(int id)
        {
            var issue = await _context.Issue.FindAsync(id);

            if (issue == null)
            {
                return NotFound();
            }

            return issue;
        }

        // PUT: api/Issue/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("[action]")]
        public async Task<IActionResult> PutIssue(int id, Issue issue)
        {
            if (id != issue.ReportId)
            {
                return BadRequest();
            }

            _context.Entry(issue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(id))
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

        // POST: api/Issue
        [Route("[action]")]
        public async Task<ActionResult<Issue>> PostIssue(Issue issue)
        {
            _context.Issue.Add(issue);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IssueExists(issue.ReportId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIssue", new { id = issue.ReportId }, issue);
        }

        // DELETE: api/Issue/5
        [Route("[action]")]
        public async Task<ActionResult<Issue>> DeleteIssue(int id)
        {
            var issue = await _context.Issue.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }

            _context.Issue.Remove(issue);
            await _context.SaveChangesAsync();

            return issue;
        }

        private bool IssueExists(int id)
        {
            return _context.Issue.Any(e => e.ReportId == id);
        }

        [EnableCors("GetAllPolicy")]
        [Route("[action]")]
        public async Task<ActionResult<Issue>> getIssue2(Issue2 issue2)
        {
            Issue issue = null;
            _context.Issue.Add(issue);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IssueExists(issue.ReportId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIssue", new { id = issue.ReportId }, issue);
        }


    }
}
