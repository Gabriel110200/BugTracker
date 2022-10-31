using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Data.Migrations;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using System;
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


        public async Task<IActionResult> CreateProject(Project project,Guid CompanyId)
        {
            var isCompanyCreated = await _project.Create(project, CompanyId);

            return Created(string.Empty, isCompanyCreated);

        }


        [HttpGet("/[Controller]/[Action]")]

        public async Task<IActionResult> GetProjectMean(Guid projectId)
        {

            var project = await _context.Projects.Where(x => x.Id == projectId).FirstOrDefaultAsync();
            

            if(project is null)
            {
                throw new Exception("Projeto não encontrado encontrado!");
            }


            return Ok(_project.UrgentPriorityArithmeticMean(project));


        }


        [HttpGet("/[Controller]/Action")]

        public  IActionResult Delete(Guid projectId)
        {
            var isProjectDeleted =  _project.Delete(projectId);

            return NoContent();

        }



    }
}
