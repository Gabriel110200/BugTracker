using Microsoft.AspNetCore.Mvc;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using System;
using System.Threading.Tasks;

namespace ProjectManagement.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectService _project;


        public ProjectController(IProjectService ProjectService)
        {
            _project = ProjectService;

        }

        public async Task<IActionResult> CreateProject(Project project,Guid CompanyId)
        {
            var isCompanyCreated = await _project.Create(project, CompanyId);

            return Created(string.Empty, isCompanyCreated);

        }



    }
}
