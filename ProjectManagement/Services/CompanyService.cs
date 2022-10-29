using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> Create(Company company,ApplicationUser User)
        {

            if (this._context.Companies.Any(x => x.CNPJ == company.CNPJ || x.CorporateName == company.CorporateName))
                throw new Exception("Current Company was already registered");


            company.Admins.Add(User);

            this._context.Companies.Add(company); 

            await this._context.SaveChangesAsync();

            return true;



        }

        public bool Delete(Guid id)
        {

           var company =  this._context.Companies.Where(x => x.Id == id).FirstOrDefault();

            if (company is null)
                throw new Exception("Company Not found");

             this._context.Companies.Remove(company);

             this._context.SaveChanges();

            return true;

        }


        public async Task<bool> RegisterAdmins(Guid CompanyId,ApplicationUser User)
        {
            var company = await this._context.Companies.Where(x => x.Id == CompanyId).FirstOrDefaultAsync();

            if (company.Admins.Any(x => x.id == User.id))
                throw new Exception("User already registered as admin");


            company.Admins.Add(User); 

            this._context.Companies.Update(company);
            await this._context.SaveChangesAsync();


            return true;




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



        public Task<bool> Update(Company company)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICompanyService.Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
