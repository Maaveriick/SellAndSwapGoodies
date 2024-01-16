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
	public class OffersController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public OffersController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: api/Offers
		[HttpGet]
		public async Task<IActionResult> GetOffer()
		{
			var offers = await _unitOfWork.Offers.GetAll();
			//if (_context.Makes == null)
			if (offers == null)
			{
				return NotFound();
			}
			//return await _context.Makes.ToListAsync();
			return Ok(offers);

		}

		// GET: api/Offers/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetOffer(int id)
		{
			var offer = await _unitOfWork.Offers.Get(q => q.Id == id);

			if (offer == null)
			{
				return NotFound();
			}
			return Ok(offer);
		}

		// PUT: api/Offers/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutOffer(int id, Offer offer)
		{
			if (id != offer.Id)
			{
				return BadRequest();
			}

			//_context.Entry(make).State = EntityState.Modified;
			_unitOfWork.Offers.Update(offer);

			try
			{
				//await _context.SaveChangesAsync();
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await OfferExists(id))
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

		// POST: api/Offers
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Offer>> PostOffer(Offer offer)
		{
			//  if (_context.Makes == null)
			//  {
			//      return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
			//  }
			//    _context.Makes.Add(make);
			//    await _context.SaveChangesAsync();
			await _unitOfWork.Offers.Insert(offer);
			await _unitOfWork.Save(HttpContext);

			return CreatedAtAction("GetMake", new { id = offer.Id }, offer);
		}

		// DELETE: api/Offers/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteOffer(int id)
		{
			//if (_context.Makes == null)
			//{
			//    return NotFound();
			//}
			//var make = await _context.Makes.FindAsync(id);
			var offer = await _unitOfWork.Offers.Get(q => q.Id == id);
			if (offer == null)
			{
				return NotFound();
			}

			//_context.Makes.Remove(make);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Offers.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> OfferExists(int id)
		{
			//return (_context.Offers?.Any(e => e.Id == id)).GetValueOrDefault();
			var offer = _unitOfWork.Offers.Get(q => q.Id == id);

			return offer != null;
		}
	}
}
