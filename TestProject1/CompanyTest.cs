using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectManagement.Controllers;
using ProjectManagement.Data;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using ProjectManagement.Models.Request;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class CompanyTest
    {

        private ApplicationDbContext context;

        private Mock<ICompanyRepository> CompanyRepository;
        private Mock<IUserService> _userService;
        private Mock<IUnitOfWork> UnitOfWork;


        private CompanyController CompanyController;

        public CompanyTest()
        {
            this._userService = new Mock<IUserService>();
            this.UnitOfWork = new Mock<IUnitOfWork>();
            this.CompanyRepository = new Mock<ICompanyRepository>();
            this.UnitOfWork.Setup(u => u.GetCompanyRepository()).Returns(CompanyRepository.Object);
            this.CompanyController = new CompanyController(this.UnitOfWork.Object, this._userService.Object);
        }




        [TestMethod]
        public async Task CreateCompanyIsValid()
        {

            this.CompanyRepository.Setup(x => x.IsCompanyAlreadyRegistered(It.IsAny<CompanyRequest>()))
                   .Returns(false);


            CompanyRequest company = new CompanyRequest()
            {
                UserId = "59cc8c06-319a-424f-843d-aa66deed3c00",
                Name = "Empresa Teste",
                CNPJ = "53.384.888/0001-70"

            };

            Company comp = new Company();


            await this.CompanyController.CreateCompany(company);


            CompanyRepository.Verify(x => x.AddAsync(It.IsAny<Company>()), Times.Once);

        }


        [TestMethod]
        public async Task CreateCompanyCNPJ_IsInvalid()
        {

            this.CompanyRepository.Setup(x => x.IsCompanyAlreadyRegistered(It.IsAny<CompanyRequest>()))
                   .Returns(false);

            CompanyRequest company = new CompanyRequest()
            {
                Name = "Empresa Teste",
                CNPJ = "111111111"
            };

           var result=  await this.CompanyController.CreateCompany(company);

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.AreEqual(400, badRequestResult.StatusCode);

       

        }



        [TestMethod]
        public async Task CreateCompanyAlreadyExists()
        {

                this.CompanyRepository.Setup(x => x.IsCompanyAlreadyRegistered(It.IsAny<CompanyRequest>()))
                       .Returns(true);

                var company = new CompanyRequest()
                {
                    UserId = "59cc8c06-319a-424f-843d-aa66deed3c00",
                    Name = "Empresa Tester",
                    CNPJ = "36.160.011/0001-86",

                };

                var result = await this.CompanyController.CreateCompany(company);

                Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
                var badRequestResult = (BadRequestObjectResult)result;
                Assert.AreEqual(400, badRequestResult.StatusCode);


        }


        [TestMethod]
        public async Task GetUserCompanyIsValid()
        {


            var user = new IdentityUser();
            List<Company> company = new List<Company>() { new Company() };

            // this.CompanyRepository.Setup(x => x.IsCompanyAlreadyRegistered(It.IsAny<CompanyRequest>())).Returns(false);


            this._userService.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(user);

            // this.CompanyRepository.Setup(x => x.GetOwnedUserCompanies(It.IsAny<string>())).ReturnsAsync(company);

            var result = await this.CompanyController.GetUserCompanies("b95b3400-787f-493a-bdd7-3eed4897e441");


            Assert.IsInstanceOfType(result, typeof(OkObjectResult));


        }


    }
}

