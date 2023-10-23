using ProjectManagement.Models;
using ProjectManagement.Models.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.IServices
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        // Task<List<Company>> ListAllCompanies();


        Task<List<Company>> GetOwnedUserCompanies(string id);

        bool IsCompanyAlreadyRegistered(CompanyRequest company);

        // Task<bool> RegisterAdmins(Guid CompanyId, User User);





    }
}
