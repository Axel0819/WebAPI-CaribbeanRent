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
    public class RentRulesController : ControllerBase
    {
        private readonly caribbeanrentContext _context;
        private readonly IMapper _mapper;

        public RentRulesController(caribbeanrentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/RentRules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentRule>>> GetRentRules()
        {
          if (_context.RentRules == null)
          {
              return NotFound();
          }
            return await _context.RentRules
                .Include("RuleCr")
                .ToListAsync();
        }

        // GET: api/RentRules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentRule>> GetRentRule(int id)
        {
          if (_context.RentRules == null)
          {
              return NotFound();
          }
            var rentRule = await _context.RentRules
                .Include("RuleCr")
                .FirstOrDefaultAsync(r=> r.IdrentRule == id);

            if (rentRule == null)
            {
                return NotFound();
            }

            return rentRule;
        }

        // PUT: api/RentRules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentRule(int id, RentRuleDTO rentRuleDTO)
        {
            RentRule rentRule = _mapper.Map<RentRuleDTO, RentRule>(rentRuleDTO);

            if (id != rentRule.IdrentRule)
            {
                return BadRequest();
            }

            _context.Entry(rentRule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentRuleExists(id))
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

        // POST: api/RentRules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RentRule>> PostRentRule(RentRuleDTO rentRuleDTO)
        {
            List<RentRule> listRules = new List<RentRule>();

          if (_context.RentRules == null)
          {
              return Problem("Entity set 'caribbeanrentContext.RentRules'  is null.");
          }
            foreach (int idRule in rentRuleDTO.Rules)
            {
                listRules.Add(new RentRule() { Idrule = idRule, IdrentPost = rentRuleDTO.IdrentPost });
            }

            await _context.RentRules.AddRangeAsync(listRules);
            await _context.SaveChangesAsync();

            return Created("api/RentRules", listRules);
        }

        // DELETE: api/RentRules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentRule(int id)
        {
            if (_context.RentRules == null)
            {
                return NotFound();
            }
            var rentRule = await _context.RentRules.FindAsync(id);
            if (rentRule == null)
            {
                return NotFound();
            }

            _context.RentRules.Remove(rentRule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentRuleExists(int id)
        {
            return (_context.RentRules?.Any(e => e.IdrentRule == id)).GetValueOrDefault();
        }
    }
}
