using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;
using WebAPI.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly caribbeanrentContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(caribbeanrentContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        public IConfiguration Configuration { get; }

        [HttpPost]
        [Route("login")]
        public IActionResult UserLogin(UserCr user)
        {
            try
            {
                string password = Password.HashPassword(user.Password);

                //.Select(u => new{u.Uid,u.Email,u.Role,u.State}).

                var dbUser = _context.UserCrs.Where(u => u.Email == user.Email && u.Password == password).FirstOrDefault();

                if (dbUser == null)
                {
                    return BadRequest("Username or password is incorrect");
                }
                string token= CreateToken(dbUser);

                return Ok(token);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string CreateToken(UserCr user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim("Role", Convert.ToString(user.Role))
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
