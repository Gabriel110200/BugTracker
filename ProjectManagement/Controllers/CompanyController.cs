using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using ProjectManagement.Helper;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using ProjectManagement.Models.Request;
using ProjectManagement.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


namespace ProjectManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork unitofWork;
        private readonly ICompanyRepository companyRepository;
        private IUserService userService;

        public CompanyController(IUnitOfWork unitofWork, IUserService userService)
        {
            this.unitofWork = unitofWork;
            this.userService = userService;
            this.companyRepository = this.unitofWork.GetCompanyRepository();
        }




        [HttpPost("[Action]")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyRequest request)
        {
            if (this.companyRepository.IsCompanyAlreadyRegistered(request))
            {
                return BadRequest("Company was already registered!");
            }

            if (!Helpers.ValidateCnpj(request.CNPJ))
            {
                return BadRequest("CNPJ is invalid!");
            }

            var company = new Company()
            {
                Name = request.Name, 
                Description = request.Description, 
                CNPJ = request.CNPJ, 
                CorporateName= request.CorporateName,
                Image = request.Image,
                UserId = request.UserId
                
            };

            await this.companyRepository.AddAsync(company);
            await this.unitofWork.Commit();

            return Created("Empresa criada com sucesso",company);
        }



        [HttpGet("[Action]/{userId}")]

        public async Task<IActionResult> GetUserCompanies(string userId)
        {

            var doesUserExist = await this.userService.Get(userId);

            if (doesUserExist is null)
                throw new ValidationException("The specified user does not exist in our system");

            var companies =  await this.companyRepository.GetOwnedUserCompanies(userId);

            if (companies is null)
                return NotFound();

            return Ok(companies);

        }


    }
}
