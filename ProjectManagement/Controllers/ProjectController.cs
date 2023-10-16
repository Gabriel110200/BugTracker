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
        private IProjectRepository _projectRepository;
   


        public ProjectController(IProjectRepository ProjectRepository)
        {
            _projectRepository = ProjectRepository;
            

        }

        [HttpPost("/[Controller]/[Action]")]

        public async Task<IActionResult> CreateProject([FromBody] Project project)
        {
            await _projectRepository.AddAsync(project);
            var CreatedProject = await _projectRepository.GetByIdAsync(project.Id);
            return Created(string.Empty,CreatedProject);

        }


        [HttpPost("/[Controller]/[Action]")]

        public async Task<IActionResult> UpdateProject([FromBody]  Project project)
        {

            await _projectRepository.UpdateAsync(project);
            return Ok();


        }



        [HttpGet("/[Controller]/[Action]")]
        public async Task<List<Project>> Read(Guid CompanyId)
        {
            // var projects = await _projectRepository.ListAllProjects(CompanyId);
            //  return projects;

            throw new NotImplementedException();

        }




        [HttpGet("/[Controller]/Action")]

        public  IActionResult Delete(Guid projectId)
        {
            //var isProjectDeleted =  _projectRepository.DeleteAsync(projectId);
            return NoContent();

        }



    }
}
