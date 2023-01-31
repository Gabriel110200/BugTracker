using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using ProjectManagement.Helper;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using ProjectManagement.Services;
using System;
using System.ComponentModel.DataAnnotations;
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

        private ICompanyRepository companyRepository;
        private IUserService _userService;
        private readonly ApplicationDbContext _context;

        public CompanyController(ICompanyRepository CompanyRepository, IUserService userService)
        {
            companyRepository = CompanyRepository;
            _userService = userService;
        }




        [HttpPost("[Action]")]

        public async Task<IActionResult> CreateCompany(Company company)
        {

            validateNewCompany(company);
            await companyRepository.AddAsync(company);
            var CompanyCreated = await companyRepository.GetByIdAsync(company.Id);
            return Created(string.Empty,CompanyCreated);

        }


        private void validateNewCompany(Company company)
        {
            if (companyRepository.IsCompanyAlreadyRegistered(company))
                throw new ValidationException("Company was already registered!");

            if (!Helpers.ValidateCnpj(company.CNPJ))
                throw new ValidationException("CNPJ is invalid!");
        }


        [HttpGet("[Action]/{userId}")]

        public async Task<IActionResult> GetUserCompanies(string userId)
        {


            var doesUserExist = await _userService.Get(userId);

            if (doesUserExist is null)
                throw new ValidationException("The specified user does not exist in our system");

            var companies =  await this.companyRepository.GetOwnedUserCompanies(userId);

            if (companies is null)
                return NotFound();

            return Ok(companies);

        }


        







    }
}
