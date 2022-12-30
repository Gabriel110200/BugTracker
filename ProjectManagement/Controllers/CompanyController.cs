using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using ProjectManagement.Services;
using System;
using System.Threading.Tasks;


namespace ProjectManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        private ICompanyService _company;
        private IUserService _userService;

        public CompanyController(ICompanyService CompanyService, UserManager<IdentityUser> userManager, IUserService userService)
        {
            _company = CompanyService;
            this.userManager = userManager;
            _userService = userService;
        }

        [HttpGet("[Action]")]

        public async  Task<IActionResult> teste()
        {

        

              



            return Ok("haa");
        }


        [HttpPost("/[Action]/{id}")]

        public async Task<IActionResult> CreateCompany(Company company,[FromRoute] Guid UserId)
        {


            var isCompanyCreated = await _company.Create(company);

            return Created(string.Empty,isCompanyCreated);

        }


        [HttpGet("[Action]/{userId}")]

        public async Task<IActionResult> GetUserCompanies(Guid userId)
        {


            var companies = this._company.GetOwnedUserCompanies(userId);

            return Ok(companies);

        }







    }
}
