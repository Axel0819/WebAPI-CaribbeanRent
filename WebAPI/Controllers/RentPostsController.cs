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
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentPostsController : ControllerBase
    {
        private readonly caribbeanrentContext _context;
        private readonly IMapper _mapper;

        public RentPostsController(caribbeanrentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/RentPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentPost>>> GetRentPosts()
        {
          if (_context.RentPosts == null)
          {
              return NotFound();
          }
            return await _context.RentPosts.ToListAsync();
        }

        // GET: api/RentPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentPost>> GetRentPost(int id)
        {
          if (_context.RentPosts == null)
          {
              return NotFound();
          }
            var rentPost = await _context.RentPosts.FindAsync(id);

            if (rentPost == null)
            {
                return NotFound();
            }

            return rentPost;
        }

        // PUT: api/RentPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentPost(int id, RentPostDTO rentPostDTO)
        {
            RentPost rentPost= _mapper.Map< RentPostDTO,RentPost>(rentPostDTO);
            if (id != rentPost.IdrentPost)
            {
                return BadRequest();
            }

            _context.Entry(rentPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentPostExists(_context,id))
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

        // POST: api/RentPosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RentPost>> PostRentPost(RentPostDTO rentPostDTO)
        {
            RentPost rentPost= _mapper.Map<RentPostDTO, RentPost>(rentPostDTO);

          if (_context.RentPosts == null)
          {
              return Problem("Entity set 'caribbeanrentContext.RentPosts'  is null.");
          }
            rentPost.State = Convert.ToInt32(StateEnums.Active);
            rentPost.DateCreated = DateTime.Now;

            _context.RentPosts.Add(rentPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRentPost", new { id = rentPost.IdrentPost }, rentPost);
        }

        // DELETE: api/RentPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentPost(int id)
        {
            if (_context.RentPosts == null)
            {
                return NotFound();
            }
            var rentPost = await _context.RentPosts.FindAsync(id);
            if (rentPost == null)
            {
                return NotFound();
            }

            _context.RentPosts.Remove(rentPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public static bool RentPostExists(caribbeanrentContext _context, int id)
        {
            return (_context.RentPosts?.Any(e => e.IdrentPost == id)).GetValueOrDefault();
        }
    }
}
