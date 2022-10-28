using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NesrinBooks.API.DataAccess.Entities;
using NesrinBookStore.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NesrinBookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var foundUsr = await _userManager.FindByNameAsync(registerModel.Username);
            if (foundUsr != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User already exists." });
            }
            var user = new AppUser
            {
                Email = registerModel.Email,
                UserName = registerModel.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User creation failed!" });
            }
            return Ok(new ResponseModel { Status = "Success", Message = "User created successfully" });
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Register(LoginModel loginModel)
        {
            var foundUsr = await _userManager.FindByNameAsync(loginModel.Username);
            if (foundUsr != null && await _userManager.CheckPasswordAsync(foundUsr, loginModel.Password))
            {
                var roles = await _userManager.GetRolesAsync(foundUsr);
                List<Claim> claims = new List<Claim>();
                Claim claim1 = new Claim(ClaimTypes.Name, foundUsr.UserName);
                Claim claim2 = new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());
                claims.Add(claim1);
                claims.Add(claim2);
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));

                var token = new JwtSecurityToken(_configuration["Jwt:ValidIssuer"], _configuration["Jwt:ValidAudience"], claims, expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256));

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
          
        }
    }
}
