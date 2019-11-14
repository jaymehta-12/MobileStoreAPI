﻿using System;
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

            if (mobileitems == null)
            {
                return NotFound();
            }

            return Ok(mobileitems);

        }

        [HttpPost]

        public IActionResult AddMobile([FromBody] List<MobileItems> mobile)
        {
            try
            {
                for (var i = 0; i < mobile.ToArray().Length; i++)
                {
                    _context.MobileItems.Add(mobile[i]);
                }
                _context.SaveChanges();
                return CreatedAtAction("GetMobileList", mobile);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteMobile(int id)
        {
            var mobileitems = _context.MobileItems.Find(id);
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
         public IActionResult  PutMobileDetail(int id,List<MobileItems> mobile)
         {
             try
             {
                
                    for (var i=0;i<mobile.ToArray().Length;i++)
                {
                    if (id != mobile[i].Id)
                    {
                        _context.MobileItems.Add(mobile[i]);
                    }
                    else
                    _context.Entry(mobile[i]).State = EntityState.Modified;
                }
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
         bool MobileItemsExists(int id)
        {
            return _context.MobileItems.Any(e => e.Id == id);
        }

    }
}