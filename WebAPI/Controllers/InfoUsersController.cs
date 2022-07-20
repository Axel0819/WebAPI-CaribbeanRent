using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoUsersController : ControllerBase
    {
        private readonly caribbeanrentContext _context;
        private readonly IMapper _mapper;

        public InfoUsersController(caribbeanrentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/InfoUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoUser>>> GetInfoUsers()
        {
          if (_context.InfoUsers == null)
          {
              return NotFound();
          }
            return await _context.InfoUsers.ToListAsync();
        }

        // GET: api/InfoUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoUser>> GetInfoUser(int id)
        {
          if (_context.InfoUsers == null)
          {
              return NotFound();
          }
            var infoUser = await _context.InfoUsers.FindAsync(id);

            if (infoUser == null)
            {
                return NotFound();
            }

            return infoUser;
        }

        // PUT: api/InfoUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoUser(int id, InfoUserDTO infoUserDTO)
        {
            InfoUser infoUser = _mapper.Map<InfoUserDTO, InfoUser>(infoUserDTO);
            var updatedInfo = DateTime.Now;

            if (id != infoUser.IdinfoUser)
            {
                return BadRequest();
            }
            infoUser.UpdateInfo = updatedInfo;
            _context.Entry(infoUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoUserExists(id))
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

        // POST: api/InfoUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoUser>> PostInfoUser(InfoUserDTO infoUserDTO)
        {
            InfoUser infoUser = _mapper.Map<InfoUserDTO, InfoUser>(infoUserDTO);
            var dateCreated = DateTime.Now;

            if (_context.InfoUsers == null)
          {
              return Problem("Entity set 'caribbeanrentContext.InfoUsers'  is null.");
          }
            infoUser.DateCreated = dateCreated;
            infoUser.UpdateInfo = dateCreated;

            _context.InfoUsers.Add(infoUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoUser", new { id = infoUser.IdinfoUser }, infoUser);
        }

        // DELETE: api/InfoUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoUser(int id)
        {
            if (_context.InfoUsers == null)
            {
                return NotFound();
            }
            var infoUser = await _context.InfoUsers.FindAsync(id);
            if (infoUser == null)
            {
                return NotFound();
            }

            _context.InfoUsers.Remove(infoUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfoUserExists(int id)
        {
            return (_context.InfoUsers?.Any(e => e.IdinfoUser == id)).GetValueOrDefault();
        }
    }
}
