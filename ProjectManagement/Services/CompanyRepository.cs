using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Helper;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManagement.Services
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {

        private readonly ApplicationDbContext context;
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Company>> GetOwnedUserCompanies(string id)
        {
            return  await context.Companies.Where(x => x.UserId == id).ToListAsync();
        }

        public bool IsCompanyAlreadyRegistered(string cnpj)
        {
            return this.context.Companies.Any(x => x.CNPJ == cnpj);
        }

        public bool IsCompanyAlreadyRegisteredSameName(string name)
        {
            return this.context.Companies.Any(x => x.CNPJ == name);
        }


        //public async Task<List<Company>> GetOwnedUserCompanies(string id)
        //{

        //    var doesUserExist = this._context.Users.Any(x=> x.Id == id);
        //    if (!doesUserExist)
        //        throw new ValidationException("User not found!");

        //    var companies = await this._context.Companies.Where(x => x.UserId == id).ToListAsync();



        //    return companies;

        //}


        //public async Task<Company> Create(Company company)
        //{


        //    this._context.Companies.Add(company); 
        //    await this._context.SaveChangesAsync();

        //    return await this._context.Companies.FirstOrDefaultAsync(x => x.Id == company.Id);


        //}



        //public async Task Delete(Guid id)
        //{

        //    var company =  this._context.Companies.Where(x => x.Id == id).FirstOrDefault();

        //    if (company is null)
        //        throw new ValidationException("Company not found!");

        //   this._context.Companies.Remove(company);
        //   this._context.SaveChanges();



        //}


        //public async Task<Company> Get(Guid id)
        //{

        //     var company = await this._context.Companies.Where((x) => x.Id == id).FirstOrDefaultAsync();
        //     return company;
        //}



        //public async Task<List<Company>> ListAllCompanies()
        //{

        //    return await this._context.Companies.ToListAsync();

        //}



        //public Task<bool> RegisterAdmins(Guid CompanyId, User User)
        //{
        //    throw new NotImplementedException();
        //}

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
