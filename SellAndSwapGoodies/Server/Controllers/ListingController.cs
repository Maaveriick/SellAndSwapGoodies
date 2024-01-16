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
	public class ListingsController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public ListingsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
    
        // GET: api/Listings
        [HttpGet]
		public async Task<IActionResult> GetListing()
		{
			var Listings = await _unitOfWork.Listings.GetAll(includes: q => q.Include(x => x.User).Include(x => x.Category).Include(x => x.Condition));
			//return await _context.Makes.ToListAsync();
			return Ok(Listings);

		}

		// GET: api/Listings/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetListing (int id)
		{
			var listing = await _unitOfWork.Listings.Get(q => q.Id == id);

			if (listing == null)
			{
				return NotFound();
			}
			return Ok(listing);
		}

		// PUT: api/Listings/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutListing(int id, Listing listing)
		{
			if (id != listing.Id)
			{
				return BadRequest();
			}

			//_context.Entry(make).State = EntityState.Modified;
			_unitOfWork.Listings.Update(listing);

			try
			{
				//await _context.SaveChangesAsync();
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await ListingExists(id))
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

		// POST: api/Listings
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Listing>> PostListing(Listing listing)
		{
			//  if (_context.Makes == null)
			//  {
			//      return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
			//  }
			//    _context.Makes.Add(make);
			//    await _context.SaveChangesAsync();
			await _unitOfWork.Listings.Insert(listing);
			await _unitOfWork.Save(HttpContext);

			return CreatedAtAction("GetMake", new { id = listing.Id }, listing);
		}

		// DELETE: api/Listings/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteListing(int id)
		{
			//if (_context.Makes == null)
			//{
			//    return NotFound();
			//}
			//var make = await _context.Makes.FindAsync(id);
			var listing = await _unitOfWork.Listings.Get(q => q.Id == id);
			if (listing == null)
			{
				return NotFound();
			}

			//_context.Makes.Remove(make);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Listings.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> ListingExists(int id)
		{
			//return (_context.Listings?.Any(e => e.Id == id)).GetValueOrDefault();
			var listing = _unitOfWork.Listings.Get(q => q.Id == id);

			return listing != null;
		}
	}
}
