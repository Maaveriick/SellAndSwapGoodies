using System;
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
    public class OffersController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public OffersController(ApplicationDbContext context)
        public OffersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Offers
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Offer>>> GetOffers()
        public async Task<IActionResult> GetOffers()
        {
            //return await _context.Offers.ToListAsync();
            var offers = await _unitOfWork.Offers.GetAll(includes: q => q.Include(x => x.Sender).Include(x => x.Receiver));
            return Ok(offers);
        }

        // GET: api/Offers/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Offer>> GetOffer(int id)
        public async Task<IActionResult> GetOffer(int id)
        {
            //var offer = await _context.Offers.FindAsync(id);
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

            //_context.Entry(offer).State = EntityState.Modified;
            _unitOfWork.Offers.Update(offer);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!OfferExists(id))
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
            //_context.Offers.Add(offer);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Offers.Insert(offer);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetOffer", new { id = offer.Id }, offer);
        }

        // DELETE: api/Offers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            //var offer = await _context.Offers.FindAsync(id);
            var offer = await _unitOfWork.Offers.Get(q => q.Id == id);
            if (offer == null)
            {
                return NotFound();
            }

            //_context.Offers.Remove(offer);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Offers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> OfferExists(int id)
        {
            //return _context.Offers.Any(e => e.Id == id);
            var offer = await _unitOfWork.Offers.Get(q => q.Id == id);
            return offer != null;
        }
    }
}

