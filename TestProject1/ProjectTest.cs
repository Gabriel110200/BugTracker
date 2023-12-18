using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectManagement.Controllers;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using ProjectManagement.Models.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Tests
{
    [TestClass]
    public class ProjectControllerTests
    {
        [TestMethod]
        public async Task CreateProject_ValidRequest_ReturnsCreatedResult()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var projectRepositoryMock = new Mock<IProjectRepository>();
            unitOfWorkMock.Setup(u => u.GetProjectRepository()).Returns(projectRepositoryMock.Object);
            var controller = new ProjectController(unitOfWorkMock.Object);
            var request = new ProjectRequest
            {
                CompanyID = Guid.NewGuid(),
                ProjectName = "Test Project",
                Description = "Test Description",
            };

            var result = await controller.CreateProject(request) as CreatedResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(201, result.StatusCode);
        }

        [TestMethod]
        public async Task UpdateProject_ValidProject_ReturnsOkResult()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var projectRepositoryMock = new Mock<IProjectRepository>();
            unitOfWorkMock.Setup(u => u.GetProjectRepository()).Returns(projectRepositoryMock.Object);
            var controller = new ProjectController(unitOfWorkMock.Object);
            var project = new Project
            {
                Id = Guid.NewGuid(),
            };

            var result = await controller.UpdateProject(project) as OkResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public async Task ListProjects_ReturnsListOfProjects()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var projectRepositoryMock = new Mock<IProjectRepository>();
            unitOfWorkMock.Setup(u => u.GetProjectRepository()).Returns(projectRepositoryMock.Object);
            var controller = new ProjectController(unitOfWorkMock.Object);
            var projects = new List<Project>
            {
                new Project { Id = Guid.NewGuid(), /* Set other properties */ },
                new Project { Id = Guid.NewGuid(), /* Set other properties */ },
            };
            projectRepositoryMock.Setup(r => r.GetAsync(null)).ReturnsAsync(projects);

            var result = await controller.ListProjects(Guid.NewGuid()) as OkObjectResult;
            var projectList = result.Value as List<Project>;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(projectList);
            Assert.AreEqual(2, projectList.Count); // Adjust this based on your sample data
        }

        [TestMethod]
        public async Task Delete_ExistingProject_ReturnsOkResult()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var projectRepositoryMock = new Mock<IProjectRepository>();
            unitOfWorkMock.Setup(u => u.GetProjectRepository()).Returns(projectRepositoryMock.Object);
            var controller = new ProjectController(unitOfWorkMock.Object);
            var projectId = Guid.NewGuid();
            var existingProject = new Project { Id = projectId, /* Set other properties */ };
            projectRepositoryMock.Setup(r => r.GetByIdAsync(projectId)).ReturnsAsync(existingProject);

            var result = await controller.Delete(projectId) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public async Task Delete_NonExistentProject_ReturnsBadRequest()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var projectRepositoryMock = new Mock<IProjectRepository>();
            unitOfWorkMock.Setup(u => u.GetProjectRepository()).Returns(projectRepositoryMock.Object);
            var controller = new ProjectController(unitOfWorkMock.Object);
            var projectId = Guid.NewGuid();
            projectRepositoryMock.Setup(r => r.GetByIdAsync(projectId)).ReturnsAsync((Project)null);

            var result = await controller.Delete(projectId) as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Projeto não encontrado", result.Value);
        }
    }
}
