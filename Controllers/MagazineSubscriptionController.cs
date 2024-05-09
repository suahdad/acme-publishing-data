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
    public class MagazineSubscriptionController : ControllerBase
    {
        private readonly AcmePublishingDbContext _context;

        public MagazineSubscriptionController(AcmePublishingDbContext context)
        {
            _context = context;
        }

        // GET: api/MagazineSubscription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MagazineSubscription>>> GetMagazineSubscriptions()
        {
            return await _context.MagazineSubscriptions.ToListAsync();
        }

        // GET: api/MagazineSubscription/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MagazineSubscription>> GetMagazineSubscription(uint id)
        {
            var magazineSubscription = await _context.MagazineSubscriptions.FindAsync(id);

            if (magazineSubscription == null)
            {
                return NotFound();
            }

            return magazineSubscription;
        }

        // PUT: api/MagazineSubscription/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagazineSubscription(uint id, MagazineSubscription magazineSubscription)
        {
            if (id != magazineSubscription.Id)
            {
                return BadRequest();
            }

            _context.Entry(magazineSubscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazineSubscriptionExists(id))
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

        // POST: api/MagazineSubscription
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MagazineSubscription>> PostMagazineSubscription(MagazineSubscription magazineSubscription)
        {
            _context.MagazineSubscriptions.Add(magazineSubscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMagazineSubscription", new { id = magazineSubscription.Id }, magazineSubscription);
        }

        // DELETE: api/MagazineSubscription/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagazineSubscription(uint id)
        {
            var magazineSubscription = await _context.MagazineSubscriptions.FindAsync(id);
            if (magazineSubscription == null)
            {
                return NotFound();
            }

            _context.MagazineSubscriptions.Remove(magazineSubscription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MagazineSubscriptionExists(uint id)
        {
            return _context.MagazineSubscriptions.Any(e => e.Id == id);
        }
    }
}
