using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using acme_publishing_data;
using NuGet.Common;

namespace acme_publishing_data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSubscriptionController : ControllerBase
    {
        private readonly AcmePublishingDbContext _context;

        public CustomerSubscriptionController(AcmePublishingDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerSubscription
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerSubscription>>> GetCustomerSubscriptions()
        {
            return await _context.CustomerSubscriptions.ToListAsync();
        }

        // GET: api/CustomerSubscription/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerSubscription>> GetCustomerSubscription(uint id)
        {
            var customerSubscription = await _context.CustomerSubscriptions.FindAsync(id);

            if (customerSubscription == null)
            {
                return NotFound();
            }

            return customerSubscription;
        }

        [HttpGet("Subscription/{subId}")]
        public async Task<ActionResult<CustomerSubscription[]>> GetCustomerSubscription(string subId)
        {
            IEnumerable<CustomerSubscription> customerSubscription = await _context.CustomerSubscriptions.Where(x => x.SubscriptionId == subId).ToListAsync();

            if (customerSubscription.Count() == 0)
            {
                return NotFound();
            }

            return customerSubscription.ToArray();
        }

        // PUT: api/CustomerSubscription/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerSubscription(uint id, CustomerSubscription customerSubscription)
        {
            if (id != customerSubscription.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerSubscription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerSubscriptionExists(id))
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

        // POST: api/CustomerSubscription
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerSubscription>> PostCustomerSubscription(CustomerSubscription customerSubscription)
        {
            _context.CustomerSubscriptions.Add(customerSubscription);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerSubscription", new { id = customerSubscription.Id }, customerSubscription);
        }

        // DELETE: api/CustomerSubscription/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerSubscription(uint id)
        {
            var customerSubscription = await _context.CustomerSubscriptions.FindAsync(id);
            if (customerSubscription == null)
            {
                return NotFound();
            }

            _context.CustomerSubscriptions.Remove(customerSubscription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerSubscriptionExists(uint id)
        {
            return _context.CustomerSubscriptions.Any(e => e.Id == id);
        }
    }
}
