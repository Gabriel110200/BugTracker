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
    public class ProjectRepository : RepositoryBase<Project> , IProjectRepository
    {

        private readonly ApplicationDbContext _context;
        

        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

   
    }
}
