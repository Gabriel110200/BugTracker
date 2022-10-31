using ProjectManagement.Data;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Services
{
    public class ProjectServices : IProjectService
    {

        private readonly ApplicationDbContext _context;


        public ProjectServices(ApplicationDbContext context)
        {

            _context = context;


        }

        public async Task<bool> Create(Project project, Guid CompanyId)
        {
            if (this._context.Projects.Any(x => x.Name == x.Name))
                throw new Exception("Current Project was already registered");


           

            this._context.Projects.Add(project);

            await this._context.SaveChangesAsync();

            return true;
        }

        public bool Delete(Guid ProjectId)
        {

            var company = this._context.Companies.Where(x => x.Id == id).FirstOrDefault();

            if (company is null)
                throw new Exception("Company Not found");

            this._context.Companies.Remove(company);

            this._context.SaveChanges();

            return true;
        }

        public Task<List<Project>> ListAllProjects(Guid CompanyId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Project Project)
        {
            throw new NotImplementedException();
        }
    }
}
