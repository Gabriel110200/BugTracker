using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Data;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using ProjectManagement.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Threading.Tasks;
using ProjectManagement.Models.Request;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }


        [HttpPost("[Action]")]
        public async Task<IActionResult> RegisterUser(UserRequest request)
        {

            var iUser = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.Mail,
            };


            var wasUserRegistered = await this.UserService.Register(iUser, request.Password);

            if (wasUserRegistered.Succeeded)
                return Created("~/api/CreateUser", new { User = iUser });

            return BadRequest(wasUserRegistered);


        }


        [HttpPost("[Action]")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {

            var result = await this.UserService.SignIn(request);

            var jwtToken = this.GenerateJwtToken(request.Mail);

            if (result.Succeeded)
            {
                return Ok(new
                {
                    Result = result,
                    Jwt = jwtToken
                });

            }else
            {
                return BadRequest("Usuário não encontrado");
            }



        }

        private string GenerateJwtToken(string username)
        {

            string key = "this is my custom Secret key for authentication"; // Your key as a string
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var securityKey = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: new[] { new Claim(ClaimTypes.Name, username) },
                expires: DateTime.Now.AddMinutes(90),
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }



    }
}
