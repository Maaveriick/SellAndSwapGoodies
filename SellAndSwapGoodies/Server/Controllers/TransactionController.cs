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
	public class TransactionsController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public TransactionsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: api/Transactions
		[HttpGet]
		public async Task<IActionResult> GetTransaction()
		{
			var transactions = await _unitOfWork.Transactions.GetAll();
			//if (_context.Makes == null)
			if (transactions == null)
			{
				return NotFound();
			}
			//return await _context.Makes.ToListAsync();
			return Ok(transactions);

		}

		// GET: api/Transactions/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetMake(int id)
		{
			var transaction = await _unitOfWork.Transactions.Get(q => q.Id == id);

			if (transaction == null)
			{
				return NotFound();
			}
			return Ok(transaction);
		}

		// PUT: api/Transactions/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
		{
			if (id != transaction.Id)
			{
				return BadRequest();
			}

			//_context.Entry(make).State = EntityState.Modified;
			_unitOfWork.Transactions.Update(transaction);

			try
			{
				//await _context.SaveChangesAsync();
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await TransactionExists(id))
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

		// POST: api/Transactions
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
		{
			//  if (_context.Makes == null)
			//  {
			//      return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
			//  }
			//    _context.Makes.Add(make);
			//    await _context.SaveChangesAsync();
			await _unitOfWork.Transactions.Insert(transaction);
			await _unitOfWork.Save(HttpContext);

			return CreatedAtAction("GetMake", new { id = transaction.Id }, transaction);
		}

		// DELETE: api/Transactions/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTransaction(int id)
		{
			//if (_context.Makes == null)
			//{
			//    return NotFound();
			//}
			//var make = await _context.Makes.FindAsync(id);
			var make = await _unitOfWork.Transactions.Get(q => q.Id == id);
			if (make == null)
			{
				return NotFound();
			}

			//_context.Makes.Remove(make);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Transactions.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> TransactionExists(int id)
		{
			//return (_context.Transactions?.Any(e => e.Id == id)).GetValueOrDefault();
			var transaction = _unitOfWork.Transactions.Get(q => q.Id == id);

			return transaction != null;
		}
	}
}
