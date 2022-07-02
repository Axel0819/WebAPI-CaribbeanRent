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
    public class UserCrsController : ControllerBase
    {
        private readonly caribbeanrentContext _context;

        public UserCrsController(caribbeanrentContext context)
        {
            _context = context;
        }

        // GET: api/UserCrs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCr>>> GetUserCrs()
        {
          if (_context.UserCrs == null)
          {
              return NotFound();
          }
            return await _context.UserCrs.ToListAsync();
        }

        // GET: api/UserCrs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCr>> GetUserCr(Guid id)
        {
          if (_context.UserCrs == null)
          {
              return NotFound();
          }
            var userCr = await _context.UserCrs.FindAsync(id);

            if (userCr == null)
            {
                return NotFound();
            }

            return userCr;
        }

        // PUT: api/UserCrs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCr(Guid id, UserCr userCr)
        {
            if (id != userCr.Uid)
            {
                return BadRequest();
            }

            _context.Entry(userCr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCrExists(id))
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

        // POST: api/UserCrs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserCr>> PostUserCr(UserCr userCr)
        {
          if (_context.UserCrs == null)
          {
              return Problem("Entity set 'caribbeanrentContext.UserCrs'  is null.");
          }
            _context.UserCrs.Add(userCr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserCr", new { id = userCr.Uid }, userCr);
        }

        // DELETE: api/UserCrs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCr(Guid id)
        {
            if (_context.UserCrs == null)
            {
                return NotFound();
            }
            var userCr = await _context.UserCrs.FindAsync(id);
            if (userCr == null)
            {
                return NotFound();
            }

            _context.UserCrs.Remove(userCr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserCrExists(Guid id)
        {
            return (_context.UserCrs?.Any(e => e.Uid == id)).GetValueOrDefault();
        }
    }
}
