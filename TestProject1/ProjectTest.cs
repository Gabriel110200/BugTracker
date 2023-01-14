using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectManagement.Controllers;
using ProjectManagement.Data;
using ProjectManagement.Data.Migrations;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using ProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class ProjectTest
    {

        private readonly Mock<IProjectService> proj;
        private ApplicationDbContext context;

        
        public ProjectTest()
        {

           
            //this.config = new Mock<IConfiguration>();

            this.context = null;

            this.proj = new Mock<IProjectService>();
            Connect connect = new Connect();

            this.context = connect.CriarContextInMemory();
            this.context.Database.EnsureDeleted();



        }



        //[TestMethod]
        //public async Task ProjectControllerIsValid()
        //{

        //    try 
        //    {


        //    var service = new ProjectServices(this.context);

        //    Project project = new Project()
        //    {
        //            Name = "Projeto teste",
        //    };

        //    service.Create(project, Guid.Parse("d4e0dc03-f766-470b-9594-78a756032d1c"));


        //    return;

        //    }
        //    catch(Exception ex)
        //    {
        //        Assert.Fail(ex.Message);
        //    }

        //}


        [TestMethod]
        public async Task CreateProjectIsValid()
        {

            try
            {


                var service = new ProjectServices(this.context);

                Project project = new Project()
                {
                    Name = "Projeto teste",
                };

                await service.Create(project);

                return;

            }
            catch (Exception ex)
            {
                Assert.Fail();
            }


        }


        [TestMethod]
        public async Task ListAllProjects()
        {

            try
            {


                PrepararDatabase();

                var service = new ProjectServices(this.context);
                var projects = await service.ListAllProjects(Guid.Parse("d4e0dc03-f766-470b-9594-78a756032d1c"));
                Assert.IsInstanceOfType(projects, typeof(List<Project>));



            }
            catch (Exception ex)
            {
                Assert.Fail();
            }



        }


        [TestMethod]
        public async Task DeleteProjectNotFoundException()
        {

            try
            {

                ProjectServices service = new ProjectServices(this.context);
                service.Delete(Guid.Parse("a3485d47-f1a9-4b40-ba15-acd9f251c4dd"));


            }catch(Exception ex)
            {
                Assert.AreEqual("Project not found", ex.Message);
            }

        }


        


        [TestMethod]

        public async Task DeleteProjectSuccessful()
        {
            try
            {

                PrepararDatabase();
                ProjectServices service = new ProjectServices(this.context);
                var wasProjectDeleted = service.Delete(Guid.Parse("0b93cf51-4927-4097-bf76-9e1fc165ea24"));
                Assert.IsTrue(wasProjectDeleted);

            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }


        public void PrepararDatabase()
        {


            Project project = new Project()
            {
                Id = Guid.Parse("0b93cf51-4927-4097-bf76-9e1fc165ea24"),
                Name = "Projeto repetido",
                CompanyId_FK = Guid.Parse("d4e0dc03-f766-470b-9594-78a756032d1c")

            };

            Company companny = new Company()
            {
                Id = Guid.Parse("d4e0dc03-f766-470b-9594-78a756032d1c"),
                Name = "Empresa teste"
            };

            

            this.context.Projects.Add(project);
            this.context.Companies.Add(companny);
            this.context.SaveChanges();


        }

    }
}
