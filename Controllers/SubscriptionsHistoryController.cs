using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using acme_publishing_data;

namespace acme_publishing_data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsHistoryController : ControllerBase
    {
        private readonly AcmePublishingDbContext _context;

        public SubscriptionsHistoryController(AcmePublishingDbContext context)
        {
            _context = context;
        }

        // GET: api/SubscriptionsHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionsHistory>>> GetSubscriptionsHistories()
        {
            return await _context.SubscriptionsHistories.ToListAsync();
        }

        // GET: api/SubscriptionsHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionsHistory>> GetSubscriptionsHistory(uint id)
        {
            var subscriptionsHistory = await _context.SubscriptionsHistories.FindAsync(id);

            if (subscriptionsHistory == null)
            {
                return NotFound();
            }

            return subscriptionsHistory;
        }

        // PUT: api/SubscriptionsHistory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriptionsHistory(uint id, SubscriptionsHistory subscriptionsHistory)
        {
            if (id != subscriptionsHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(subscriptionsHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriptionsHistoryExists(id))
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

        // POST: api/SubscriptionsHistory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubscriptionsHistory>> PostSubscriptionsHistory(SubscriptionsHistory subscriptionsHistory)
        {
            _context.SubscriptionsHistories.Add(subscriptionsHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriptionsHistory", new { id = subscriptionsHistory.Id }, subscriptionsHistory);
        }

        // DELETE: api/SubscriptionsHistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriptionsHistory(uint id)
        {
            var subscriptionsHistory = await _context.SubscriptionsHistories.FindAsync(id);
            if (subscriptionsHistory == null)
            {
                return NotFound();
            }

            _context.SubscriptionsHistories.Remove(subscriptionsHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriptionsHistoryExists(uint id)
        {
            return _context.SubscriptionsHistories.Any(e => e.Id == id);
        }
    }
}
