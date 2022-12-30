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
        private readonly UserManager<User> userManager;

        private ICompanyService _company;

        public CompanyController(ICompanyService CompanyService, UserManager<User> userManager)
        {
            _company = CompanyService;
            this.userManager = userManager;
        }

        [HttpGet("[Action]")]

        public async  Task<IActionResult> teste()
        {

        

                try
                {

                   var teste = new User() {  UserName = "Teste" };

                    var r = await userManager.CreateAsync(teste, "Abcd@123456");

                }
                catch (Exception ex)
                {
                    throw ex;
                }




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
