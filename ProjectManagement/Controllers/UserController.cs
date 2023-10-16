using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using ProjectManagement.Services;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("[Action]")]
        public async Task<IActionResult> RegisterUser(UserRequest request)
        {

            var iUser = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.Mail,
            };


            var wasUserRegistered = await this._userService.Register(iUser, request.Password);

            if (wasUserRegistered.Succeeded)
                return Created("~/api/CreateUser", new { User = iUser});

            return BadRequest(wasUserRegistered);


        }





    }
}
