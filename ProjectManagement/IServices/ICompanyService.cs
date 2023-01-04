using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.IServices
{
    public interface ICompanyService
    {
         Task<List<Company>> ListAllCompanies();

         Task<bool> Create(Company company);



        Task<Company> Get(Guid id);
         

         Task<List<Company>> GetOwnedUserCompanies(string id);


         Task<bool> RegisterAdmins(Guid CompanyId, User User);



        

    }
}
