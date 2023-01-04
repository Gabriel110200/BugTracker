using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Helper;
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

            validateCompany(company);
            this._context.Companies.Add(company); 
            await this._context.SaveChangesAsync();
            return true;



        }

        private void validateCompany(Company company)
        {
            if (this._context.Companies.Any(x => x.CNPJ == company.CNPJ))
                throw new Exception("Company was already registered!");

            if (this._context.Companies.Any(x => x.UserId == company.UserId && x.Name == company.Name))
                throw new Exception("There is a company regitered with that name!");

            if (!Helpers.ValidateCnpj(company.CNPJ))
                throw new Exception("CNPJ is invalid!");
        }

        public async Task Delete(Guid id)
        {

            var company =  this._context.Companies.Where(x => x.Id == id).FirstOrDefault();

            if (company is null)
                throw new Exception("Company not found!");

           this._context.Companies.Remove(company);
           this._context.SaveChanges();



        }


        //public async Task<bool> RegisterAdmins(Guid CompanyId,User User)
        //{
        //    var company = await this._context.Companies.Where(x => x.Id == CompanyId).FirstOrDefaultAsync();

        //    if (company.Admins.Any(x => x.UserId == User.Id))
        //        throw new Exception("User already registered as admin");


        //    company.Admins.Add(User); 

        //    this._context.Companies.Update(company);
        //    await this._context.SaveChangesAsync();


        //    return true;




        //}

        public async Task<Company> Get(Guid id)
        {

             var company = await this._context.Companies.Where((x) => x.Id == id).FirstOrDefaultAsync();
             return company;
        }

    

        public async Task<List<Company>> ListAllCompanies()
        {

            return await this._context.Companies.ToListAsync();

        }

        public async Task<List<Company>> GetOwnedUserCompanies(string id)
        {


            var companies = await this._context.Companies.Where(x => x.UserId == id).ToListAsync();

            return companies;
            
        }

        public Task<bool> RegisterAdmins(Guid CompanyId, User User)
        {
            throw new NotImplementedException();
        }

        //public async List<List<<Company>> GetOwnedUserCompanies(Guid userId)
        //{

        //    var companies = await this._context.Companies
        //                                        .SelectMany(company => company.Admins)
        //                                        .Where(user => user.Id == userId)
        //                                        .Select(user => user.Company).ToListAsync();




        //    //            return this._context.Companies.Where(x => x.Admins.Select(x=> x.Id).FirstOrDefault() == userId) ).ToListAsync();

        //    return companies;
        //}
    }
}
