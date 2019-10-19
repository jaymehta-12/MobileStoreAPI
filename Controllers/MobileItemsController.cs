using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileItemsController : ControllerBase
    {
        private readonly MobileContext _context;

        public MobileItemsController(MobileContext context)
        {
            _context = context;
        }

        // GET: api/MobileItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MobileItems>>> GetMobileItems()
        {
            return await _context.MobileItems.ToListAsync();
        }

        // GET: api/MobileItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MobileItems>> GetMobileItems(int id)
        {
            var mobileItems = await _context.MobileItems.FindAsync(id);

            if (mobileItems == null)
            {
                return NotFound();
            }

            return mobileItems;
        }

        // PUT: api/MobileItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobileItems(int id, MobileItems mobileItems)
        {
            if (id != mobileItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(mobileItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobileItemsExists(id))
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

        // POST: api/MobileItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MobileItems>> PostMobileItems(MobileItems mobileItems)
        {
            _context.MobileItems.Add(mobileItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMobileItems", new { id = mobileItems.Id }, mobileItems);
        }

        // DELETE: api/MobileItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MobileItems>> DeleteMobileItems(int id)
        {
            var mobileItems = await _context.MobileItems.FindAsync(id);
            if (mobileItems == null)
            {
                return NotFound();
            }

            _context.MobileItems.Remove(mobileItems);
            await _context.SaveChangesAsync();

            return mobileItems;
        }

        private bool MobileItemsExists(int id)
        {
            return _context.MobileItems.Any(e => e.Id == id);
        }
    }
}
