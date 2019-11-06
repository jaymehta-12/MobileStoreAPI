using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileItemController : ControllerBase
    {
        private readonly MobileContext _context;

        public MobileItemController(MobileContext context)
        {
            _context = context;
        }

       

        [HttpGet]

        public List<MobileItems> GetMobileList()
        {
            return _context.MobileItems.ToList();
        }

        [HttpGet("{id}")]

        public IActionResult GetMobileList(int id)
        {
            var mobileitems = _context.MobileItems.Find(id);

            if(mobileitems== null)
            {
                return NotFound();
            }

            return Ok(mobileitems);

        }

        [HttpPost]

        public IActionResult AddMobile(MobileItems mobile)
        {
            _context.MobileItems.Add(mobile);
            _context.SaveChanges();

            return CreatedAtAction("GetMobileList", new { id = mobile.Id }, mobile);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteMobile(int id)
        {
            var mobileitems =  _context.MobileItems.Find(id);
            if (mobileitems == null)
            {
                return NotFound();
            }

            _context.MobileItems.Remove(mobileitems);
            _context.SaveChanges();

            return Ok(mobileitems);
        }

        [HttpPut("id")]

        [HttpPut("{id}")]
        public IActionResult  PutMobileDetail(int id, MobileItems mobile)
        {
            if (id != mobile.Id)
            {
                return BadRequest();
            }
            _context.Entry(mobile).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
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
        private bool MobileItemsExists(int id)
        {
            return _context.MobileItems.Any(e => e.Id == id);
        }

    }
}