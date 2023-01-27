using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.IServices
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        // Task<List<Company>> ListAllCompanies();


         Task<List<Company>> GetOwnedUserCompanies(string id);

        bool IsCompanyAlreadyRegistered(string cnpj);


        bool IsCompanyAlreadyRegisteredSameName(string name);





        // Task<bool> RegisterAdmins(Guid CompanyId, User User);





    }
}
