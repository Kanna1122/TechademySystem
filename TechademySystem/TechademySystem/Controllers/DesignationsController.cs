using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechademySystem.Models;

namespace TechademySystem.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DesignationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Designations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Designation>>> GetDesignation()
        {
            return await _context.Designation.ToListAsync();
        }

        // GET: api/Designations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Designation>> GetDesignation(int id)
        {
            var designation = await _context.Designation.FindAsync(id);

            if (designation == null)
            {
                return NotFound();
            }

            return designation;
        }

        // PUT: api/Designations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesignation(int id, Designation designation)
        {
            var exitsdesignation = await _context.Designation.FirstOrDefaultAsync(x => x.Id == id);
            if (exitsdesignation != null)
            {
                exitsdesignation.DesignationName = designation.DesignationName;
                exitsdesignation.RollName = designation.RollName;
                exitsdesignation.DepartmentName = designation.DepartmentName;

                await _context.SaveChangesAsync();
                return Ok(exitsdesignation);
            }
            return NotFound("Employee not Found");
        }

        // POST: api/Designations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Designation>> PostDesignation(Designation designation)
        {
            _context.Designation.Add(designation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesignation", new { id = designation.Id }, designation);
        }

        // DELETE: api/Designations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Designation>> DeleteDesignation(int id)
        {
            var designation = await _context.Designation.FindAsync(id);
            if (designation == null)
            {
                return NotFound();
            }

            _context.Designation.Remove(designation);
            await _context.SaveChangesAsync();

            return designation;
        }

        private bool DesignationExists(int id)
        {
            return _context.Designation.Any(e => e.Id == id);
        }
    }
}
