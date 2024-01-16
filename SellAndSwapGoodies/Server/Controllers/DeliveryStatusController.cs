using System;
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
	public class DeliveryStatusesController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeliveryStatusesController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: api/DeliveryStatuses
		[HttpGet]
		public async Task<IActionResult> GetDeliveryStatus()
		{
			var deliverystatuses = await _unitOfWork.DeliveryStatuses.GetAll();
			//if (_context.Makes == null)
			if (deliverystatuses == null)
			{
				return NotFound();
			}
			//return await _context.Makes.ToListAsync();
			return Ok(deliverystatuses);

		}

		// GET: api/DeliveryStatuses/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetMake(int id)
		{
			var deliverystatus = await _unitOfWork.DeliveryStatuses.Get(q => q.Id == id);

			if (deliverystatus == null)
			{
				return NotFound();
			}
			return Ok(deliverystatus);
		}

		// PUT: api/DeliveryStatuses/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutDeliveryStatus(int id, DeliveryStatus deliverystatus)
		{
			if (id != deliverystatus.Id)
			{
				return BadRequest();
			}

			//_context.Entry(make).State = EntityState.Modified;
			_unitOfWork.DeliveryStatuses.Update(deliverystatus);

			try
			{
				//await _context.SaveChangesAsync();
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await DeliveryStatusExists(id))
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

		// POST: api/DeliveryStatuses
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<DeliveryStatus>> PostDeliveryStatus(DeliveryStatus deliverystatus)
		{
			//  if (_context.Makes == null)
			//  {
			//      return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
			//  }
			//    _context.Makes.Add(make);
			//    await _context.SaveChangesAsync();
			await _unitOfWork.DeliveryStatuses.Insert(deliverystatus);
			await _unitOfWork.Save(HttpContext);

			return CreatedAtAction("GetMake", new { id = deliverystatus.Id }, deliverystatus);
		}

		// DELETE: api/DeliveryStatuses/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteDeliveryStatus(int id)
		{
			//if (_context.Makes == null)
			//{
			//    return NotFound();
			//}
			//var make = await _context.Makes.FindAsync(id);
			var make = await _unitOfWork.DeliveryStatuses.Get(q => q.Id == id);
			if (make == null)
			{
				return NotFound();
			}

			//_context.Makes.Remove(make);
			//await _context.SaveChangesAsync();
			await _unitOfWork.DeliveryStatuses.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> DeliveryStatusExists(int id)
		{
			//return (_context.DeliveryStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
			var deliverystatus = _unitOfWork.DeliveryStatuses.Get(q => q.Id == id);

			return deliverystatus != null;
		}
	}
}
