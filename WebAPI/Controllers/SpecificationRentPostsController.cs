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
    public class SpecificationRentPostsController : ControllerBase
    {
        private readonly caribbeanrentContext _context;
        private readonly IMapper _mappper;
        public SpecificationRentPostsController(caribbeanrentContext context, IMapper mapper)
        {
            _context = context;
            _mappper = mapper;
        }

        // GET: api/SpecificationRentPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecificationRentPost>>> GetSpecificationRentPosts()
        {
          if (_context.SpecificationRentPosts == null)
          {
              return NotFound();
          }
            return await _context.SpecificationRentPosts.ToListAsync();
        }

        // GET: api/SpecificationRentPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecificationRentPost>> GetSpecificationRentPost(int id)
        {
          if (_context.SpecificationRentPosts == null)
          {
              return NotFound();
          }
            var specificationRentPost = await _context.SpecificationRentPosts.FindAsync(id);

            if (specificationRentPost == null)
            {
                return NotFound();
            }

            return specificationRentPost;
        }

        // PUT: api/SpecificationRentPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecificationRentPost(int id, SpecificationRentPostDTO specificationRentPostDTO)
        {
            SpecificationRentPost specificationRentPost = _mappper.Map<SpecificationRentPostDTO, SpecificationRentPost>(specificationRentPostDTO);
            
            if (id != specificationRentPost.IdspecificationRentPost)
            {
                return BadRequest();
            }

            _context.Entry(specificationRentPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecificationRentPostExists(id))
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

        // POST: api/SpecificationRentPosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpecificationRentPost>> PostSpecificationRentPost(SpecificationRentPostDTO specificationRentPostDTO)
        {
            SpecificationRentPost specificationRentPost = _mappper.Map<SpecificationRentPostDTO, SpecificationRentPost>(specificationRentPostDTO);
            if (_context.SpecificationRentPosts == null)
          {
              return Problem("Entity set 'caribbeanrentContext.SpecificationRentPosts'  is null.");
          }
            _context.SpecificationRentPosts.Add(specificationRentPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecificationRentPost", new { id = specificationRentPost.IdspecificationRentPost }, specificationRentPost);
        }

        // DELETE: api/SpecificationRentPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecificationRentPost(int id)
        {
            if (_context.SpecificationRentPosts == null)
            {
                return NotFound();
            }
            var specificationRentPost = await _context.SpecificationRentPosts.FindAsync(id);
            if (specificationRentPost == null)
            {
                return NotFound();
            }

            _context.SpecificationRentPosts.Remove(specificationRentPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecificationRentPostExists(int id)
        {
            return (_context.SpecificationRentPosts?.Any(e => e.IdspecificationRentPost == id)).GetValueOrDefault();
        }
    }
}
