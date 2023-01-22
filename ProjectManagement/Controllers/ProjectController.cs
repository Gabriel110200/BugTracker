using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Data.Migrations;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectService _project;
        private readonly ApplicationDbContext _context;


        public ProjectController(IProjectService ProjectService, ApplicationDbContext context)
        {
            _project = ProjectService;
            _context = context;

        }

        [HttpPost("/[Controller]/[Action]")]

        public async Task<IActionResult> CreateProject(Project project)
        {
            await _project.Create(project);
            return Created(string.Empty,"");

        }


        [HttpPost("/[Controller]/[Action]")]

        public async Task<IActionResult> UpdateProject(Project project)
        {

            await _project.Update(project);
            return Ok();


        }



        [HttpGet("/[Controller]/[Action]")]
        public async Task<List<Project>> Read(Guid CompanyId)
        {
            var projects = await _project.ListAllProjects(CompanyId);
            return projects;

        }




        [HttpGet("/[Controller]/Action")]

        public  IActionResult Delete(Guid projectId)
        {
            var isProjectDeleted =  _project.Delete(projectId);
            return NoContent();

        }



    }
}
