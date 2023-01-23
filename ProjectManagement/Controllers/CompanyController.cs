using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using ProjectManagement.Helper;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using ProjectManagement.Services;
using System;
using System.Linq;
using System.Net;
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
        private readonly ApplicationDbContext _context;

        public CompanyController(ICompanyService CompanyService, UserManager<IdentityUser> userManager, IUserService userService, ApplicationDbContext context)
        {
            _company = CompanyService;
            this.userManager = userManager;
            _userService = userService;
            _context = context;
        }




        [HttpPost("[Action]")]

        public async Task<IActionResult> CreateCompany(Company company)
        {

            var CompanyCreated = await _company.Create(company);

            return Created(string.Empty,CompanyCreated);
        }


        [HttpGet("[Action]/{userId}")]

        public async Task<IActionResult> GetUserCompanies(string userId)
        {

            

            var companies =  await this._company.GetOwnedUserCompanies(userId);

            return Ok(companies);

        }







    }
}
