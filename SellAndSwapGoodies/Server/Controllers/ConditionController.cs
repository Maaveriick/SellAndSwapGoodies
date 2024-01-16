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
    public class ConditionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConditionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Conditions
        [HttpGet]
        public async Task<IActionResult> GetCondition()
        {
            var conditions = await _unitOfWork.Conditions.GetAll();
            //if (_context.Makes == null)
            if (conditions == null)
            {
                return NotFound();
            }
            //return await _context.Makes.ToListAsync();
            return Ok(conditions);

        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCondition(int id)
        {
            var condition = await _unitOfWork.Conditions.Get(q => q.Id == id);

            if (condition == null)
            {
                return NotFound();
            }
            return Ok(condition);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondition(int id, Condition condition)
        {
            if (id != condition.Id)
            {
                return BadRequest();
            }

            //_context.Entry(make).State = EntityState.Modified;
            _unitOfWork.Conditions.Update(condition);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ConditionExists(id))
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
        public async Task<ActionResult<Condition>> PostCondition(Condition condition)
        {
            //  if (_context.Makes == null)
            //  {
            //      return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
            //  }
            //    _context.Makes.Add(make);
            //    await _context.SaveChangesAsync();
            await _unitOfWork.Conditions.Insert(condition);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCondition", new { id = condition.Id }, condition);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondition(int id)
        {
            //if (_context.Makes == null)
            //{
            //    return NotFound();
            //}
            //var make = await _context.Makes.FindAsync(id);
            var condition = await _unitOfWork.Conditions.Get(q => q.Id == id);
            if (condition == null)
            {
                return NotFound();
            }

            //_context.Makes.Remove(make);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Conditions.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ConditionExists(int id)
        {
            //return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
            var condition = _unitOfWork.Conditions.Get(q => q.Id == id);

            return condition != null;
        }
    }
}
