using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileStore.BL.Interface;
using MobileStore.BL.Model;

namespace MobileStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileItemController : ControllerBase
    {
        private readonly IMobileBLL _mobileRepository;

        public MobileItemController(IMobileBLL mobileRepository)
        {
            _mobileRepository = mobileRepository;
        }

        [HttpGet]
        public List<MobileItems> GetMobileItems()
        {
            var dataT= _mobileRepository.GetMobileItemsBL();
            return dataT;
        }

        //[HttpGet("search")]

        //public IActionResult GetSearch([FromQuery] string searchstring)
        //{
        //    var mobiles = from m in _context.MobileItems select m;
        //    List<MobileItems> mobileItems = new List<MobileItems>();

        //    if(!string.IsNullOrEmpty(searchstring))
        //    {
        //        mobileItems = mobiles.Include(a => a.AccessoryItems).Where(m => m.MobileName.Contains(searchstring)).ToList();
              
        //    }
        //    else
        //    {
        //        mobileItems = mobiles.ToList();


        //    }


        //    return Ok(mobileItems);


        //}

       

        //[HttpGet("{id}")]

        //public IActionResult GetMobileList(int id)
        //{
        //    var mobileitems = _context.MobileItems.Include(a=>a.AccessoryItems).SingleOrDefault(m=>m.MobileItemsId==id);

        //    if (mobileitems == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(mobileitems);

        //}

        //[HttpGet("sort")]
        //public IQueryable GetSort([FromQuery] string sortletter,string sortorder)
        //{
            
        //    var mobiles = from m in _context.MobileItems.Include(a=>a.AccessoryItems) select m;
            
           
        //        switch (sortorder)
        //        {
        //            case "name_desc":
        //                mobiles = mobiles.OrderByDescending(m => m.MobileName);
        //                break;
        //            case "price_desc":
        //                mobiles = mobiles.OrderByDescending(z => z.MobilePrice);
        //                break;

        //        }
            
            
        //       // var mobile = _context.MobileItems.Where(m => m.MobileName.StartsWith(sortletter)).OrderByDescending(x => x.MobileName);
            
        //     return mobiles;

        //}

        //[HttpPost]

        //public IActionResult AddMobile([FromBody] MobileItems mobile)
        //{
        //    try
        //    {
        //           _context.MobileItems.Add(mobile);
                
        //        _context.SaveChanges();
        //        return CreatedAtAction("GetMobileList", mobile);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}


        //[HttpDelete("{id}")]

        //public IActionResult DeleteMobile(int id)
        //{
        //        var mobileitems = _context.MobileItems.Find(id);
        //        if (mobileitems == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.MobileItems.Remove(mobileitems);
        //          _context.SaveChanges();

        //    return Ok(mobileitems);
        //}



        

        //[HttpPut("{id}")]
        //public IActionResult PutMobileDetail(int id, MobileItems mobile)
        //{

        //    if (id != mobile.MobileItemsId)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Entry(mobile).State = EntityState.Modified;
        //    _context.AccessoryItems.UpdateRange(mobile.AccessoryItems);

        //    try
        //    {
        //        _context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (!MobileItemsExists(id))
        //        {
        //            return NotFound(ex);
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return Ok();
        //}

        
        //bool MobileItemsExists(int id)
        //{
        //    return _context.MobileItems.Any(e => e.MobileItemsId == id);
        //}

    }
}