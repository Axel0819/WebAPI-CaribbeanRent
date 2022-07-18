using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomiePostServicesController : ControllerBase
    {
        private readonly caribbeanrentContext _context;

        public RoomiePostServicesController(caribbeanrentContext context)
        {
            _context = context;
        }

        // GET: api/RoomiePostServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomiePostService>>> GetRoomiePostServices()
        {
          if (_context.RoomiePostServices == null)
          {
              return NotFound();
          }
            return await _context.RoomiePostServices.ToListAsync();
        }

        // GET: api/RoomiePostServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomiePostService>> GetRoomiePostService(int id)
        {
          if (_context.RoomiePostServices == null)
          {
              return NotFound();
          }
            var roomiePostService = await _context.RoomiePostServices.FindAsync(id);

            if (roomiePostService == null)
            {
                return NotFound();
            }

            return roomiePostService;
        }

        // PUT: api/RoomiePostServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomiePostService(int id, RoomiePostService roomiePostService)
        {
            if (id != roomiePostService.IdroomieService)
            {
                return BadRequest();
            }

            _context.Entry(roomiePostService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomiePostServiceExists(id))
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

        // POST: api/RoomiePostServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomiePostService>> PostRoomiePostService(RoomiePostService roomiePostService)
        {
          if (_context.RoomiePostServices == null)
          {
              return Problem("Entity set 'caribbeanrentContext.RoomiePostServices'  is null.");
          }
            _context.RoomiePostServices.Add(roomiePostService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomiePostService", new { id = roomiePostService.IdroomieService }, roomiePostService);
        }

        // DELETE: api/RoomiePostServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomiePostService(int id)
        {
            if (_context.RoomiePostServices == null)
            {
                return NotFound();
            }
            var roomiePostService = await _context.RoomiePostServices.FindAsync(id);
            if (roomiePostService == null)
            {
                return NotFound();
            }

            _context.RoomiePostServices.Remove(roomiePostService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomiePostServiceExists(int id)
        {
            return (_context.RoomiePostServices?.Any(e => e.IdroomieService == id)).GetValueOrDefault();
        }
    }
}
