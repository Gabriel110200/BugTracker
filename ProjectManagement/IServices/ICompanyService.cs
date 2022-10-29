using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.IServices
{
    public interface ICompanyService
    {
        public Task<List<Company>> ListAllCompanies();

        public Task<bool> Create(Company company);

        public Task<bool> Update(Company company);


        public Task<Company> Get(Guid id);

        public Task<List<ApplicationUser>> ListAdmins();


        public Task<bool> RegisterUser();


        public Task<bool> Delete(Guid id); 



        

    }
}
