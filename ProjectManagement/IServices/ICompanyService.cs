using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.IServices
{
    public interface ICompanyService
    {
         Task<List<Company>> ListAllCompanies();

         Task<bool> Create(Company company,ApplicationUser user);

         Task<Company> Get(Guid id);


         Task<bool> RegisterAdmins(Guid CompanyId, ApplicationUser User);



        

    }
}
