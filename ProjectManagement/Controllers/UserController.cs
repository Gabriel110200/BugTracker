using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using ProjectManagement.IServices;
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
        public async Task<IActionResult> CreateUser(IdentityUser user)
        {

            var wasUserRegistered = await this._userService.Register(user, "teste12345");

            if (wasUserRegistered.Succeeded)
                return Created("~/api/CreateUser", new { User = user});

            return BadRequest(wasUserRegistered);


        }



    }
}
