using Microsoft.AspNetCore.Mvc;
using ProjectManagement.IServices;
using ProjectManagement.IServices.TicketStrategy;
using ProjectManagement.Models;
using ProjectManagement.Services;
using System;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public class CompanyController : Controller
    {

        private ICompanyService _company;
       
        public CompanyController(ICompanyService CompanyService)
        {
            _company = CompanyService;

        }

        [HttpPost("/[Controller]/[Action]")]

        public async Task<IActionResult> CreateCompany(Company company, ApplicationUser User)
        {


            var isCompanyCreated = await _company.Create(company,User);

            return Created(string.Empty,isCompanyCreated);

        }


        [HttpGet("/[Controller]/[Action]/{id}")]

        public async Task<IActionResult> Delete(Guid Id)
        {

            var wasCompanyDeleted = await _company.Delete(Id);

            return NoContent();
        }





    }
}
