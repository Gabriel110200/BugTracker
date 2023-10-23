using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.Data.Migrations;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using ProjectManagement.Models.Request;
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

        public IUnitOfWork UnitOfWork { get; }
        public IProjectRepository ProjectRepository { get; }

        public ProjectController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            this.ProjectRepository = this.UnitOfWork.GetProjectRepository();
        }

        [HttpPost("/[Controller]/[Action]")]

        public async Task<IActionResult> CreateProject([FromBody] ProjectRequest request)
        {

            var project = new Project()
            {
                CompanyId_FK = request.CompanyID,
                Name = request.ProjectName,
                Description = request.Description,
                Status = Enum.ProjectStatus.Development,
                IsActive = true,
            }; 



            await this.ProjectRepository.AddAsync(project);
            await this.UnitOfWork.Commit();
            var CreatedProject = await this.ProjectRepository.GetByIdAsync(project.Id);
            return Created(string.Empty,CreatedProject);

        }


        [HttpPost("/[Controller]/[Action]")]

        public async Task<IActionResult> UpdateProject([FromBody]  Project project)
        {

            await this.ProjectRepository.UpdateAsync(project);
            return Ok();


        }



        [HttpGet("/[Controller]/[Action]")]
        public async Task<IActionResult> ListProjects(Guid CompanyId)
        {
             var projects = await this.ProjectRepository.GetAsync();
             return Ok(projects);


        }




        [HttpGet("/[Controller]/[Action]")]

        public async  Task<IActionResult> Delete(Guid projectId)
        {

            var project =await this.ProjectRepository.GetByIdAsync(projectId);

            if(project == null)
            {
                return BadRequest("Projeto não encontrado");
            }

            await this.ProjectRepository.DeleteAsync(project);
            await this.UnitOfWork.Commit();

            return Ok("Projeto deletado com sucesso");

        }



    }
}
