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
	public class ChatsController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public ChatsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: api/Chats
		[HttpGet]
		public async Task<IActionResult> GetChat()
		{
			var chats = await _unitOfWork.Chats.GetAll(includes: q => q.Include(x => x.Offer.Sender).Include(x => x.Offer.Receiver));
			//if (_context.Makes == null)
			if (chats == null)
			{
				return NotFound();
			}
			//return await _context.Makes.ToListAsync();
			return Ok(chats);

		}

		// GET: api/Chats/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetChat(int id)
		{
			var chat = await _unitOfWork.Chats.Get(q => q.Id == id);

			if (chat == null)
			{
				return NotFound();
			}
			return Ok(chat);
		}

		// PUT: api/Chats/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutChat(int id, Chat chat)
		{
			if (id != chat.Id)
			{
				return BadRequest();
			}

			//_context.Entry(make).State = EntityState.Modified;
			_unitOfWork.Chats.Update(chat);

			try
			{
				//await _context.SaveChangesAsync();
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await ChatExists(id))
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

		// POST: api/Chats
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Chat>> PostChat(Chat chat)
		{
			//  if (_context.Makes == null)
			//  {
			//      return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
			//  }
			//    _context.Makes.Add(make);
			//    await _context.SaveChangesAsync();
			await _unitOfWork.Chats.Insert(chat);
			await _unitOfWork.Save(HttpContext);

			return CreatedAtAction("GetMake", new { id = chat.Id }, chat);
		}

		// DELETE: api/Chats/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteChat(int id)
		{
			//if (_context.Makes == null)
			//{
			//    return NotFound();
			//}
			//var make = await _context.Makes.FindAsync(id);
			var chat = await _unitOfWork.Chats.Get(q => q.Id == id);
			if (chat == null)
			{
				return NotFound();
			}

			//_context.Makes.Remove(make);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Chats.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> ChatExists(int id)
		{
			//return (_context.Chats?.Any(e => e.Id == id)).GetValueOrDefault();
			var chat = await _unitOfWork.Chats.Get(q => q.Id == id);

			return chat != null;
		}
	}
}
