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
	public class ProfilesController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProfilesController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		// GET: api/Profiles
		[HttpGet]
		public async Task<IActionResult> GetProfile()
		{
			var profiles = await _unitOfWork.Profiles.GetAll();
			//if (_context.Makes == null)
			if (profiles == null)
			{
				return NotFound();
			}
			//return await _context.Makes.ToListAsync();
			return Ok(profiles);

		}

		// GET: api/Profiles/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetProfile(int id)
		{
			var profile = await _unitOfWork.Profiles.Get(q => q.Id == id);

			if (profile == null)
			{
				return NotFound();
			}
			return Ok(profile);
		}

		// PUT: api/Profiles/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutProfile(int id, Profile profile)
		{
			if (id != profile.Id)
			{
				return BadRequest();
			}

			//_context.Entry(make).State = EntityState.Modified;
			_unitOfWork.Profiles.Update(profile);

			try
			{
				//await _context.SaveChangesAsync();
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await ProfileExists(id))
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

		// POST: api/Profiles
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Profile>> PostProfile(Profile profile)
		{
			//  if (_context.Makes == null)
			//  {
			//      return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
			//  }
			//    _context.Makes.Add(make);
			//    await _context.SaveChangesAsync();
			await _unitOfWork.Profiles.Insert(profile);
			await _unitOfWork.Save(HttpContext);

			return CreatedAtAction("GetMake", new { id = profile.Id }, profile);
		}

		// DELETE: api/Profiles/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProfile(int id)
		{
			//if (_context.Makes == null)
			//{
			//    return NotFound();
			//}
			//var make = await _context.Makes.FindAsync(id);
			var profile = await _unitOfWork.Profiles.Get(q => q.Id == id);
			if (profile == null)
			{
				return NotFound();
			}

			//_context.Makes.Remove(make);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Profiles.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> ProfileExists(int id)
		{
			//return (_context.Profiles?.Any(e => e.Id == id)).GetValueOrDefault();
			var profile = _unitOfWork.Profiles.Get(q => q.Id == id);

			return profile != null;
		}
	}
}
