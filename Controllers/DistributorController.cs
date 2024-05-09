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
    public class DistributorController : ControllerBase
    {
        private readonly AcmePublishingDbContext _context;

        public DistributorController(AcmePublishingDbContext context)
        {
            _context = context;
        }

        // GET: api/Distributor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distributor>>> GetDistributors()
        {
            return await _context.Distributors.ToListAsync();
        }

        // GET: api/Distributor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Distributor>> GetDistributor(string id)
        {
            var distributor = await _context.Distributors.FindAsync(id);

            if (distributor == null)
            {
                return NotFound();
            }

            return distributor;
        }

        // PUT: api/Distributor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistributor(string id, Distributor distributor)
        {
            if (id != distributor.Id)
            {
                return BadRequest();
            }

            _context.Entry(distributor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistributorExists(id))
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

        // POST: api/Distributor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Distributor>> PostDistributor(Distributor distributor)
        {
            _context.Distributors.Add(distributor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DistributorExists(distributor.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDistributor", new { id = distributor.Id }, distributor);
        }

        // DELETE: api/Distributor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistributor(string id)
        {
            var distributor = await _context.Distributors.FindAsync(id);
            if (distributor == null)
            {
                return NotFound();
            }

            _context.Distributors.Remove(distributor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DistributorExists(string id)
        {
            return _context.Distributors.Any(e => e.Id == id);
        }
    }
}
