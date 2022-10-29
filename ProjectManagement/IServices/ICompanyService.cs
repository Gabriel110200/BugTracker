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

         Task<bool> Update(Company company);


         Task<Company> Get(Guid id);

         Task<List<ApplicationUser>> ListAdmins();


         Task<bool> RegisterAdmins(Guid CompanyId, ApplicationUser User);


         Task<bool> Delete(Guid id); 



        

    }
}
