using ProjectManagement.IServices;
using ProjectManagement.Models;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public class CompanyController
    {

        private ICompanyService _company;

        public CompanyController(ICompanyService CompanyService)
        {
            _company = CompanyService;

        }


        public async Task<bool> CreateCompany(Company company, ApplicationUser User)
        {
            var isCompanyCreated = await _company.Create(company,User);
            return isCompanyCreated;

        }


    }
}
