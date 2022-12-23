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

        private ICompanyService _company;
       
        public CompanyController(ICompanyService CompanyService)
        {
            _company = CompanyService;

        }





        [HttpPost("/[Action]/{id}")]

        public async Task<IActionResult> CreateCompany(Company company,[FromRoute] Guid UserId)
        {


            var isCompanyCreated = await _company.Create(company);

            return Created(string.Empty,isCompanyCreated);

        }







    }
}
