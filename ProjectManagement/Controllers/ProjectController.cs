using Microsoft.AspNetCore.Authorization;
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
    //  [Authorize]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {

        public IUnitOfWork UnitOfWork { get; }
        public IProjectRepository ProjectRepository { get; }

        public ICompanyRepository CompanyRepository { get; }

        public ProjectController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            this.ProjectRepository = this.UnitOfWork.GetProjectRepository();
            this.CompanyRepository = this.UnitOfWork.GetCompanyRepository();
        }

        [HttpPost("[Action]")]

        public async Task<IActionResult> CreateProject([FromBody] ProjectRequest request)
        {

            var company = await this.CompanyRepository.GetOwnedUserCompanies(request.UserId.ToString()); 

            var project = new Project()
            {
                CompanyId_FK = company.Id,
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


        [HttpPut("update")]

        public async Task<IActionResult> UpdateProject([FromBody]  Project project)
        {

            await this.ProjectRepository.UpdateAsync(project);
            return Ok();


        }



        [HttpGet("list")]
        public async Task<IActionResult> ListProjects()
        {
             var projects = await this.ProjectRepository.GetAsync();
             return Ok(projects);


        }




        [HttpDelete("{projectId}")]

        public async Task<IActionResult> Delete([FromRoute] Guid projectId)
        {

            var project = await this.ProjectRepository.GetByIdAsync(projectId);

            if (project == null)
            {
                return BadRequest("Projeto não encontrado");
            }

            await this.ProjectRepository.DeleteAsync(project);
            await this.UnitOfWork.Commit();

            return Ok("Projeto deletado com sucesso");

        }



    }
}
