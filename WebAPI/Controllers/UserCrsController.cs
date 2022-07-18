using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Helpers;
using WebAPI.Models.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCrsController : ControllerBase
    {
        private readonly caribbeanrentContext _context;
        private readonly IMapper _mapper;

        public UserCrsController(caribbeanrentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public async Task<ActionResult<UserCr>> GetUserCr(int id)
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
        public async Task<IActionResult> PutUserCr(int id, UserCr userCr)
        {
            if (id != userCr.Uid)
            {
                return BadRequest();
            }
            userCr.Password = Password.HashPassword(userCr.Password);

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

        // POST: api/UserCrs/register
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserCr>> PostUserCr(UserCrDTO userCrDTO)
        {
            UserCr userCr = _mapper.Map<UserCrDTO, UserCr>(userCrDTO);

            var infoUserDTO = new InfoUserDTO();
            var infoUser = new InfoUsersController(_context,_mapper);

            var dbUser = _context.UserCrs.Where(u => u.Email == userCr.Email).FirstOrDefault();

            if (dbUser != null)
            {
                return BadRequest("User already exists with this email");
            }
            userCr.Password = Password.HashPassword(userCr.Password);
            userCr.State = 1;

            var userCreated= _context.UserCrs.Add(userCr);

            await _context.SaveChangesAsync();

            infoUserDTO.Uid = userCreated.Entity.Uid;
            infoUserDTO.Name = userCrDTO.Name;
            infoUserDTO.FirstSurname = userCrDTO.FirstSurname;
            infoUserDTO.SecondSurname = userCrDTO.SecondSurname;
            infoUserDTO.Description = "";
            infoUserDTO.Age = 0;
            infoUserDTO.UrlPhoto = "";

            await infoUser.PostInfoUser(infoUserDTO);

            return Ok($"Successfully registered");
        }

        // DELETE: api/UserCrs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCr(int id)
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

        private bool UserCrExists(int id)
        {
            return (_context.UserCrs?.Any(e => e.Uid == id)).GetValueOrDefault();
        }
    }
}