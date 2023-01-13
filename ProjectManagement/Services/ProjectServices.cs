using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Data.Migrations;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProjectManagement.Services
{
    public class ProjectServices : IProjectService
    {

        private readonly ApplicationDbContext _context;
        



        public ProjectServices(ApplicationDbContext context)
        {

            _context = context;


        }

        public async Task Create(Project project, Guid CompanyId)
        {
            if (this._context.Projects.Any(x => x.Name == x.Name))
                throw new Exception("Current Project was already registered");

            this._context.Projects.Add(project);
            await this._context.SaveChangesAsync();

        }

     

        public bool Delete(Guid projectId)
        {

            var project = this._context.Projects.Where(x => x.Id == projectId)
                                                 .FirstOrDefault();

            if (project is null)
                throw new Exception("Project not found");

            this._context.Projects.Remove(project);

            this._context.SaveChanges();

            return true;
        }



        public Task<List<Project>> ListAllProjects(Guid CompanyId)
        {
            return this._context.Projects.Where(x => x.CompanyId_FK == CompanyId).ToListAsync();
        }

        public async Task<bool> Update(Project project)
        {

            this._context.Update(project);
            await this._context.SaveChangesAsync();

            return true;

        }
    }
}
