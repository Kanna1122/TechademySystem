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
    public class PaymentRulesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentRulesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentRules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentRule>>> GetPaymentRule()
        {
            return await _context.PaymentRule.ToListAsync();
        }

        // GET: api/PaymentRules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentRule>> GetPaymentRule(int id)
        {
            var paymentRule = await _context.PaymentRule.FindAsync(id);

            if (paymentRule == null)
            {
                return NotFound();
            }

            return paymentRule;
        }

        // PUT: api/PaymentRules/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentRule(int id, PaymentRule paymentRule)
        {
            var exitsRule = await _context.PaymentRule.FirstOrDefaultAsync(x => x.Id == id);
            if (exitsRule != null)
            {
                exitsRule.Rule = paymentRule.Rule;
               

                await _context.SaveChangesAsync();
                return Ok(exitsRule);
            }
            return NotFound("Employee not Found");
        }

        // POST: api/PaymentRules
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PaymentRule>> PostPaymentRule(PaymentRule paymentRule)
        {
            _context.PaymentRule.Add(paymentRule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentRule", new { id = paymentRule.Id }, paymentRule);
        }

        // DELETE: api/PaymentRules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentRule>> DeletePaymentRule(int id)
        {
            var paymentRule = await _context.PaymentRule.FindAsync(id);
            if (paymentRule == null)
            {
                return NotFound();
            }

            _context.PaymentRule.Remove(paymentRule);
            await _context.SaveChangesAsync();

            return paymentRule;
        }

        private bool PaymentRuleExists(int id)
        {
            return _context.PaymentRule.Any(e => e.Id == id);
        }
    }
}
