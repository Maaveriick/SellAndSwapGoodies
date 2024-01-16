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
	public class ReviewsController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public ReviewsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: api/Reviews
		[HttpGet]
		public async Task<IActionResult> GetReview()
		{
			var Reviews = await _unitOfWork.Reviews.GetAll(includes: q => q.Include(x => x.User));
			//return await _context.Makes.ToListAsync();
			return Ok(Reviews);

		}

		// GET: api/Reviews/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetReview(int id)
		{
			var review = await _unitOfWork.Reviews.Get(q => q.Id == id);

			if (review == null)
			{
				return NotFound();
			}
			return Ok(review);
		}

		// PUT: api/Reviews/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutReview(int id, Review review)
		{
			if (id != review.Id)
			{
				return BadRequest();
			}

			//_context.Entry(make).State = EntityState.Modified;
			_unitOfWork.Reviews.Update(review);

			try
			{
				//await _context.SaveChangesAsync();
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await ReviewExists(id))
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

		// POST: api/Reviews
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Review>> PostReview(Review review)
		{
			//  if (_context.Makes == null)
			//  {
			//      return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
			//  }
			//    _context.Makes.Add(make);
			//    await _context.SaveChangesAsync();
			await _unitOfWork.Reviews.Insert(review);
			await _unitOfWork.Save(HttpContext);

			return CreatedAtAction("GetMake", new { id = review.Id }, review);
		}

		// DELETE: api/Reviews/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteReview(int id)
		{
			//if (_context.Makes == null)
			//{
			//    return NotFound();
			//}
			//var make = await _context.Makes.FindAsync(id);
			var review = await _unitOfWork.Reviews.Get(q => q.Id == id);
			if (review == null)
			{
				return NotFound();
			}

			//_context.Makes.Remove(make);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Reviews.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> ReviewExists(int id)
		{
			//return (_context.Reviews?.Any(e => e.Id == id)).GetValueOrDefault();
			var review = _unitOfWork.Reviews.Get(q => q.Id == id);

			return review != null;
		}
	}
}
