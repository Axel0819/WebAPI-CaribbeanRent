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
    public class RuleCrsController : ControllerBase
    {
        private readonly caribbeanrentContext _context;
        private readonly IMapper _mapper;

        public RuleCrsController(caribbeanrentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/RuleCrs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RuleCr>>> GetRuleCrs()
        {
          if (_context.RuleCrs == null)
          {
              return NotFound();
          }
            return await _context.RuleCrs.ToListAsync();
        }

        // GET: api/RuleCrs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RuleCr>> GetRuleCr(int id)
        {
          if (_context.RuleCrs == null)
          {
              return NotFound();
          }
            var ruleCr = await _context.RuleCrs.FindAsync(id);

            if (ruleCr == null)
            {
                return NotFound();
            }

            return ruleCr;
        }

        // PUT: api/RuleCrs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRuleCr(int id, RuleCrDTO ruleCrDTO)
        {
            RuleCr ruleCr = _mapper.Map<RuleCrDTO, RuleCr>(ruleCrDTO);

            if (id != ruleCr.Idrule)
            {
                return BadRequest();
            }

            _context.Entry(ruleCr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RuleCrExists(id))
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

        // POST: api/RuleCrs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RuleCr>> PostRuleCr(RuleCrDTO ruleCrDTO)
        {
            RuleCr ruleCr = _mapper.Map<RuleCrDTO, RuleCr>(ruleCrDTO);

            if (_context.RuleCrs == null)
          {
              return Problem("Entity set 'caribbeanrentContext.RuleCrs'  is null.");
          }
            _context.RuleCrs.Add(ruleCr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRuleCr", new { id = ruleCr.Idrule }, ruleCr);
        }

        // DELETE: api/RuleCrs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRuleCr(int id)
        {
            if (_context.RuleCrs == null)
            {
                return NotFound();
            }
            var ruleCr = await _context.RuleCrs.FindAsync(id);
            if (ruleCr == null)
            {
                return NotFound();
            }

            _context.RuleCrs.Remove(ruleCr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RuleCrExists(int id)
        {
            return (_context.RuleCrs?.Any(e => e.Idrule == id)).GetValueOrDefault();
        }
    }
}
