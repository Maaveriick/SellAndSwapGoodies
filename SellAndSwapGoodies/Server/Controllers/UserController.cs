﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SellAndSwapGoodies.Server.Data;
using SellAndSwapGoodies.Shared.Domain;
using SellAndSwapGoodies.Server.IRepository;
using SellAndSwapGoodies.Server.IRepository;

namespace SellAndSwapGoodies.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public UsersController(ApplicationDbContext context)
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Users
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        public async Task<IActionResult> GetUsers()
        {
            //return await _context.Users.ToListAsync();
            var users = await _unitOfWork.Users.GetAll(includes: q => q.Include(x => x.Offers));
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUser(int id)
        public async Task<IActionResult> GetUser(int id)
        {
            //var user = await _context.Users.FindAsync(id);
            var user = await _unitOfWork.Users.Get(q => q.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            //_context.Entry(user).State = EntityState.Modified;
            _unitOfWork.Users.Update(user);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!UserExists(id))
                if (!await UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            //_context.Users.Add(user);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Users.Insert(user);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            //var datinguser = await _context.DatingUsers.FindAsync(id);
            var user = await _unitOfWork.Users.Get(q => q.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            //_context.Users.Remove(user);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Users.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> UserExists(int id)
        {
            //return _context.Users.Any(e => e.Id == id);
            var user = await _unitOfWork.Users.Get(q => q.Id == id);
            return user != null;
        }
    }
}
