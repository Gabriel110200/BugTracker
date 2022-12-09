using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.IServices
{
    public interface IProjectService
    {
        Task<List<Project>> ListAllProjects(Guid CompanyId);

        Task<bool> Create(Project Project,Guid CompanyId);

        Task<bool> Update(Project Project);

        bool Delete(Guid ProjectId);






    }
}
