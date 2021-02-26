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
    public class EmployeeServiceController : ControllerBase
    {
        private readonly SupportApplicationContext _context;

        public EmployeeServiceController()
        {
            _context = new SupportApplicationContext();
        }

        // GET: api/EmployeeService
        [Route("[action]")]
        public async Task<ActionResult<IEnumerable<EmployeeService>>> GetEmployeeServices()
        {
            return await _context.EmployeeService.ToListAsync();
        }

        // GET: api/EmployeeService/5
        [Route("[action]")]
        public async Task<ActionResult<EmployeeService>> GetEmployeeService(int id)
        {
            var employeeService = await _context.EmployeeService.FindAsync(id);

            if (employeeService == null)
            {
                return NotFound();
            }

            return employeeService;
        }

        [Route("[action]/{id}")]
        public  List<EmployeeService> GetEmployeeServiceByIdService(int id)
        {

            return _context.EmployeeService.Where(a => a.ServiceId == id).ToList(); ;
        }


        // PUT: api/EmployeeService/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("[action]")]
        public async Task<IActionResult> PutEmployeeService(int id, EmployeeService employeeService)
        {
            if (id != employeeService.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeServiceExists(id))
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

        // POST: api/EmployeeService
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("[action]")]
        public async Task<ActionResult<EmployeeService>> PostEmployeeService(EmployeeService employeeService)
        {
            _context.EmployeeService.Add(employeeService);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeServiceExists(employeeService.EmployeeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeService", new { id = employeeService.EmployeeId }, employeeService);
        }

        // DELETE: api/EmployeeService/5
        [Route("[action]")]
        public async Task<ActionResult<EmployeeService>> DeleteEmployeeService(int id)
        {
            var employeeService = await _context.EmployeeService.FindAsync(id);
            if (employeeService == null)
            {
                return NotFound();
            }

            _context.EmployeeService.Remove(employeeService);
            await _context.SaveChangesAsync();

            return employeeService;
        }

        private bool EmployeeServiceExists(int id)
        {
            return _context.EmployeeService.Any(e => e.EmployeeId == id);
        }
    }
}
