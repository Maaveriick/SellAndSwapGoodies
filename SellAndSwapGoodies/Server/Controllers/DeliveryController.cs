﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SellAndSwapGoodies.Server.Data;
using SellAndSwapGoodies.Server.IRepository;
using SellAndSwapGoodies.Shared.Domain;

namespace SellAndSwapGoodies.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliverysController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeliverysController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetDelivery()
        {
            
            var deliverys = await _unitOfWork.Deliverys.GetAll(includes: q => q.Include(x => x.User).Include(x => x.Listing).ThenInclude(listing => listing.User).Include(x => x.DeliveryStatus));
            //if (_context.Makes == null)
            if (deliverys == null)
            {
                return NotFound();
            }
            //return await _context.Makes.ToListAsync();
            return Ok(deliverys);

        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDelivery(int id)
        {
            var delivery = await _unitOfWork.Deliverys.Get(q => q.Id == id);

            if (delivery == null)
            {
                return NotFound();
            }
            return Ok(delivery);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDelivery(int id, Delivery delivery)
        {
            if (id != delivery.Id)
            {
                return BadRequest();
            }

            //_context.Entry(make).State = EntityState.Modified;
            _unitOfWork.Deliverys.Update(delivery);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DeliveryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Delivery>> PostDelivery(Delivery delivery)
        {
            //  if (_context.Makes == null)
            //  {
            //      return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
            //  }
            //    _context.Makes.Add(make);
            //    await _context.SaveChangesAsync();
            await _unitOfWork.Deliverys.Insert(delivery);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetDelivery", new { id = delivery.Id }, delivery);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            //if (_context.Makes == null)
            //{
            //    return NotFound();
            //}
            //var make = await _context.Makes.FindAsync(id);
            var deliver = await _unitOfWork.Deliverys.Get(q => q.Id == id);
            if (deliver == null)
            {
                return NotFound();
            }

            //_context.Makes.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Deliverys.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> DeliveryExists(int id)
        {
            //return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
            var delivery = _unitOfWork.Deliverys.Get(q => q.Id == id);

            return delivery != null;
        }
    }
}

