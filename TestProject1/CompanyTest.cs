﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectManagement.Controllers;
using ProjectManagement.Data;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using ProjectManagement.Models.Request;
using ProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject1
{
    [TestClass]
    public class CompanyTest
    {

        private ApplicationDbContext context;

        private Mock<ICompanyRepository> companyRepository;
        private Mock<IUserService> _userService;
        private Mock<IUnitOfWork> UnitOfWork; 



        public CompanyTest()
        {
            Connect connect = new Connect();
        }



        [TestMethod]
        public async Task CreateCompanyIsValid()
        {

            this._userService = new Mock<IUserService>();
            this.UnitOfWork = new Mock<IUnitOfWork>();
            var companyRepository = new Mock<ICompanyRepository>();
            this.UnitOfWork.Setup(u => u.GetCompanyRepository()).Returns(companyRepository.Object);

            companyRepository.Setup(x => x.IsCompanyAlreadyRegistered(It.IsAny<CompanyRequest>()))
                   .Returns(false);



            var service = new CompanyController(this.UnitOfWork.Object, this._userService.Object);


            CompanyRequest company = new CompanyRequest()
            {
                UserId = "59cc8c06-319a-424f-843d-aa66deed3c00",
                Name = "Empresa Teste",
                CNPJ = "53.384.888/0001-70"

            };

            Company comp = new Company();


            await service.CreateCompany(company);


            companyRepository.Verify(x => x.AddAsync(It.IsAny<Company>()), Times.Once);

        }


        [TestMethod]
        public async Task CreateCompanyCNPJ_IsInvalid()
        {

            this._userService = new Mock<IUserService>();
            this.UnitOfWork = new Mock<IUnitOfWork>();
            var companyRepository = new Mock<ICompanyRepository>();
            this.UnitOfWork.Setup(u => u.GetCompanyRepository()).Returns(companyRepository.Object);

            companyRepository.Setup(x => x.IsCompanyAlreadyRegistered(It.IsAny<CompanyRequest>()))
                   .Returns(false);


            var service = new CompanyController(this.UnitOfWork.Object, this._userService.Object);

            CompanyRequest company = new CompanyRequest()
            {
                Name = "Empresa Teste",
                CNPJ = "111111111"
            };

           var result=  await service.CreateCompany(company);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.AreEqual(400, badRequestResult.StatusCode);

       

        }



        [TestMethod]

        public async Task CreateCompanyAlreadyExists()
        {


            try
            {

                this._userService = new Mock<IUserService>();
                this.UnitOfWork = new Mock<IUnitOfWork>();
                var companyRepository = new Mock<ICompanyRepository>();
                this.UnitOfWork.Setup(u => u.GetCompanyRepository()).Returns(companyRepository.Object);

                companyRepository.Setup(x => x.IsCompanyAlreadyRegistered(It.IsAny<CompanyRequest>()))
                       .Returns(true);


                var service = new CompanyController(this.UnitOfWork.Object, this._userService.Object);

                var company = new CompanyRequest()
                {
                    UserId = "59cc8c06-319a-424f-843d-aa66deed3c00",
                    Name = "Empresa Tester",
                    CNPJ = "36.160.011/0001-86",

                };

                var result = await service.CreateCompany(company);

                Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
                var badRequestResult = (BadRequestObjectResult)result;
                Assert.AreEqual(400, badRequestResult.StatusCode);

            }
            catch (Exception ex)
            {

                Assert.AreEqual("Company was already registered!", ex.Message);

            }


        }






        //[TestMethod]
        //public async Task DeleteCompanyIsValid()
        //{

        //    try
        //    {


        //        this._userService = new Mock<IUserService>();
        //        this.UnitOfWork = new Mock<IUnitOfWork>();
        //        var companyRepository = new Mock<ICompanyRepository>();
        //        this.UnitOfWork.Setup(u => u.GetCompanyRepository()).Returns(companyRepository.Object);

        //        companyRepository.Setup(x => x.IsCompanyAlreadyRegistered(It.IsAny<CompanyRequest>()))
        //               .Returns(true);

        //        var service = new CompanyController(this.UnitOfWork.Object, this._userService.Object);

        //        await service.Delete(Guid.Parse("d203f193-3268-4f38-9901-7059f82ab9fe"));

        //        Assert.IsFalse(this.context.Companies.Any(x => x.Id == Guid.Parse("d203f193-3268-4f38-9901-7059f82ab9fe")));





        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail(ex.Message);
        //    }
        //}


        //[TestMethod]

        //public async Task DeleteCompanyDoesntExist()
        //{

        //    try
        //    {

        //        var service = new CompanyRepository(this.context);

        //        await service.Delete(Guid.Parse("a6e6315b-addd-4997-bbef-0bb7ce8827c3"));

        //        Assert.Fail();



        //    }catch(Exception ex)
        //    {
        //        Assert.AreEqual(ex.Message, "Company not found!");
        //    }
        //}


        //[TestMethod]

        //public async Task GetUserCompaniesIsValid()
        //{

        //    try
        //    {
        //        await PrepareDatabase();


        //        var service = new CompanyRepository(this.context);

        //        var companies = await service.GetOwnedUserCompanies("59cc8c06-319a-424f-843d-aa66deed3c00");

        //        Assert.IsTrue(companies.Any(x => x.CNPJ == "36.160.011/0001-86"));


        //    }catch(Exception ex)
        //    {
        //        Assert.Fail(ex.Message);
        //    }

        //}

        //[TestMethod]

        //public async Task GetUserCompanies_UserDontExist()
        //{
        //    try
        //    {
        //        var service = new CompanyRepository(this.context);

        //        var companies = await service.GetOwnedUserCompanies("59cc8c06-319a-424f-843d-aa66deed3c00");

        //        Assert.Fail();

        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.AreEqual("User not found!", ex.Message);
        //    }


        //}


        private async Task PrepareDatabase()
        {

            var company = new Company()
            {
                Id = Guid.Parse("d203f193-3268-4f38-9901-7059f82ab9fe"),
                UserId = "59cc8c06-319a-424f-843d-aa66deed3c00",
                Name = "Empresa Test",
                CNPJ = "36.160.011/0001-86",

            };




            this.context.Companies.Add(company);
            await this.context.SaveChangesAsync();
        }

    }
}

