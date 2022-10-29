using ProjectManagement.Data;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Services
{
    public class CompanyService : ICompanyService
    {

        private readonly ApplicationDbContext _context;

        public CompanyService(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<bool> Create(Company company)
        {

            if (this._context.Companies.Any(x => x.CNPJ == company.CNPJ || x.CorporateName == company.CorporateName))
                throw new Exception("Current Company was already registered");

            this._context.Companies.Add(company); 

            await this._context.SaveChangesAsync();

            return true;



        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUser>> ListAdmins()
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> ListAllCompanies()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterUser()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
