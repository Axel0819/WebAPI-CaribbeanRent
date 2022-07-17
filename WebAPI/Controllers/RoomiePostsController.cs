using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomiePostsController : ControllerBase
    {
        private readonly caribbeanrentContext _context;
        private readonly IMapper _mapper;

        public RoomiePostsController(caribbeanrentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/RoomiePosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomiePost>>> GetRoomiePosts()
        {
          if (_context.RoomiePosts == null)
          {
              return NotFound();
          }
            return await _context.RoomiePosts.ToListAsync();
        }

        // GET: api/RoomiePosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomiePost>> GetRoomiePost(int id)
        {
          if (_context.RoomiePosts == null)
          {
              return NotFound();
          }
            var roomiePost = await _context.RoomiePosts.FindAsync(id);

            if (roomiePost == null)
            {
                return NotFound();
            }

            return roomiePost;
        }

        // PUT: api/RoomiePosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomiePost(int id, RoomiePost roomiePost)
        {
            if (id != roomiePost.IdroomiePost)
            {
                return BadRequest();
            }

            _context.Entry(roomiePost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomiePostExists(id))
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

        // POST: api/RoomiePosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomiePost>> PostRoomiePost(RoomiePostDTO roomiePostDTO)
        {
            RoomiePost roomiePost = _mapper.Map<RoomiePostDTO, RoomiePost>(roomiePostDTO);
            var dateCreated = DateTime.Now;
          if (_context.RoomiePosts == null)
          {
              return Problem("Entity set 'caribbeanrentContext.RoomiePosts'  is null.");
          }
            roomiePost.DateCreated = dateCreated;

            _context.RoomiePosts.Add(roomiePost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomiePost", new { id = roomiePost.IdroomiePost }, roomiePost);
        }

        // DELETE: api/RoomiePosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomiePost(int id)
        {
            if (_context.RoomiePosts == null)
            {
                return NotFound();
            }
            var roomiePost = await _context.RoomiePosts.FindAsync(id);
            if (roomiePost == null)
            {
                return NotFound();
            }

            _context.RoomiePosts.Remove(roomiePost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomiePostExists(int id)
        {
            return (_context.RoomiePosts?.Any(e => e.IdroomiePost == id)).GetValueOrDefault();
        }
    }
}
