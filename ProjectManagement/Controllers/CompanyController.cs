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

        private ICompanyRepository _company;
        private IUserService _userService;
        private readonly ApplicationDbContext _context;

        public CompanyController(ICompanyRepository CompanyRepository, IUserService userService)
        {
            _company = CompanyRepository;
            _userService = userService;
        }




        [HttpPost("[Action]")]

        public async Task<IActionResult> CreateCompany(Company company)
        {

            validateCompany(company);
            await _company.AddAsync(company);
            var CompanyCreated = await _company.GetByIdAsync(company.Id);
            return Created(string.Empty,CompanyCreated);

        }


        private void validateCompany(Company company)
        {
            if (this._company.IsCompanyAlreadyRegistered(company.CNPJ))
                throw new ValidationException("Company was already registered!");

            if (this._company.IsCompanyAlreadyRegisteredSameName(company.Name))
                throw new ValidationException("There is a company regitered with that name!");

            if (!Helpers.ValidateCnpj(company.CNPJ))
                throw new ValidationException("CNPJ is invalid!");
        }


        [HttpGet("[Action]/{userId}")]

        public async Task<IActionResult> GetUserCompanies(string userId)
        {


            var doesUserExist = await _userService.Get(userId);

            if (doesUserExist is null)
                throw new ValidationException("User not found!");

            var companies =  await this._company.GetOwnedUserCompanies(userId);

            return Ok(companies);

        }


        







    }
}
