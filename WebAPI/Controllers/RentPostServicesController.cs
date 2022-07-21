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
    public class RentPostServicesController : ControllerBase
    {
        private readonly caribbeanrentContext _context;
        private readonly IMapper _mapper;

        public RentPostServicesController(caribbeanrentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/RentPostServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentPostService>>> GetRentPostServices()
        {
          if (_context.RentPostServices == null)
          {
              return NotFound();
          }
            return await _context.RentPostServices.ToListAsync();
        }

        // GET: api/RentPostServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentPostService>> GetRentPostService(int id)
        {
          if (_context.RentPostServices == null)
          {
              return NotFound();
          }
            var rentPostService = await _context.RentPostServices.FindAsync(id);

            if (rentPostService == null)
            {
                return NotFound();
            }

            return rentPostService;
        }

        // PUT: api/RentPostServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentPostService(int id, RentPostService rentPostService)
        {
            if (id != rentPostService.IdrentService)
            {
                return BadRequest();
            }

            _context.Entry(rentPostService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentPostServiceExists(id))
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

        // POST: api/RentPostServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RentPostService>> PostRentPostService(RentPostServiceDTO rentPostServiceDTO)
        {
            List<RentPostService> listServices = new List<RentPostService>();

            if (_context.RentPostServices == null)
          {
              return Problem("Entity set 'caribbeanrentContext.RentPostServices'  is null.");
          }

            foreach(int idService in rentPostServiceDTO.listIdServices)
            {
                listServices.Add(new RentPostService() { IdrentPost= rentPostServiceDTO.IdrentPost, Idservice= idService});
            }
            await _context.RentPostServices.AddRangeAsync(listServices);
            await _context.SaveChangesAsync();

            return Created("api/RentPostService", listServices);
        }

        // DELETE: api/RentPostServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentPostService(int id)
        {
            if (_context.RentPostServices == null)
            {
                return NotFound();
            }
            var rentPostService = await _context.RentPostServices.FindAsync(id);
            if (rentPostService == null)
            {
                return NotFound();
            }

            _context.RentPostServices.Remove(rentPostService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentPostServiceExists(int id)
        {
            return (_context.RentPostServices?.Any(e => e.IdrentService == id)).GetValueOrDefault();
        }
    }
}
