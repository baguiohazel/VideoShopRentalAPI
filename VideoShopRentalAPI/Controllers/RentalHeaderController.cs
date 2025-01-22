using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoShopRentalAPI.Data;
using VideoShopRentalAPI.Models;

namespace VideoShopRentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalHeadersController : ControllerBase
    {
        private readonly VideoRentalShopDbContext _context;

        public RentalHeadersController(VideoRentalShopDbContext context)
        {
            _context = context;
        }

        // GET: api/RentalHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalHeader>>> GetRentalHeaders()
        {
            return await _context.RentalHeaders
                .Include(rh => rh.Customer)
                .Include(rh => rh.RentalDetails)
                .ThenInclude(rd => rd.Movies)
                .ToListAsync();
        }

        // GET: api/RentalHeaders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalHeader>> GetRentalHeader(int id)
        {
            var rentalHeader = await _context.RentalHeaders
                .Include(rh => rh.Customer)
                .Include(rh => rh.RentalDetails)
                .ThenInclude(rd => rd.Movies)
                .FirstOrDefaultAsync(rh => rh.Id == id);

            if (rentalHeader == null)
                return NotFound();

            return rentalHeader;
        }

        // POST: api/RentalHeaders
        [HttpPost]
        public async Task<ActionResult<RentalHeader>> CreateRentalHeader(RentalHeader rentalHeader)
        {
            _context.RentalHeaders.Add(rentalHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRentalHeader), new { id = rentalHeader.Id }, rentalHeader);
        }

        // PUT: api/RentalHeaders/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRentalHeader(int id, RentalHeader rentalHeader)
        {
            if (id != rentalHeader.Id)
                return BadRequest();

            _context.Entry(rentalHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RentalHeaders.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/RentalHeaders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentalHeader(int id)
        {
            var rentalHeader = await _context.RentalHeaders.FindAsync(id);
            if (rentalHeader == null)
                return NotFound();

            _context.RentalHeaders.Remove(rentalHeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
