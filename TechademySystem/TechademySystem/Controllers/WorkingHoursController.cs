using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechademySystem.Data;
using TechademySystem.Models;

namespace TechademySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHoursController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WorkingHoursController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkingHours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkingHours>>> GetWorkingHours()
        {
            return await _context.WorkingHours.ToListAsync();
        }

        // GET: api/WorkingHours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkingHours>> GetWorkingHours(int id)
        {
            var workingHours = await _context.WorkingHours.FindAsync(id);

            if (workingHours == null)
            {
                return NotFound();
            }

            return workingHours;
        }

        // PUT: api/WorkingHours/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkingHours(int id, WorkingHours workingHours)
        {
            var exitsHour = await _context.WorkingHours.FirstOrDefaultAsync(x => x.Id == id);
            if (exitsHour != null)
            {
                exitsHour.EmployeeWorkingHours = workingHours.EmployeeWorkingHours;
                exitsHour.EmployeeId = workingHours.EmployeeId;
                exitsHour.Date = workingHours.Date;

                await _context.SaveChangesAsync();
                return Ok(exitsHour);
            }
            return NotFound("Employee not Found");
        }

        // POST: api/WorkingHours
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WorkingHours>> PostWorkingHours(WorkingHours workingHours)
        {
            _context.WorkingHours.Add(workingHours);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkingHours", new { id = workingHours.Id }, workingHours);
        }

        // DELETE: api/WorkingHours/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkingHours>> DeleteWorkingHours(int id)
        {
            var workingHours = await _context.WorkingHours.FindAsync(id);
            if (workingHours == null)
            {
                return NotFound();
            }

            _context.WorkingHours.Remove(workingHours);
            await _context.SaveChangesAsync();

            return workingHours;
        }

        private bool WorkingHoursExists(int id)
        {
            return _context.WorkingHours.Any(e => e.Id == id);
        }
    }
}
