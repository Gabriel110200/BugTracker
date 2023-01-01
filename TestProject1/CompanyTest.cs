using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagement.Data;
using ProjectManagement.Models;
using ProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject1
{
    [TestClass]
    public class CompanyTest
    {

        private ApplicationDbContext context;

        public CompanyTest()
        {
            Connect connect = new Connect();
            this.context = connect.CriarContextInMemory();
            this.context.Database.EnsureDeleted();
        }



        [TestMethod]
        public async Task CreateCompanyIsValid()
        {

            var service = new CompanyService(this.context);

            Company company = new Company()
            {
                UserId = "59cc8c06-319a-424f-843d-aa66deed3c00",
                Name = "Empresa Teste",
                CNPJ = "53.384.888/0001-70"

            };
            await  service.Create(company);

            var wasCompanyRegistered = this.context.Companies.Any(x => x.CNPJ == "53.384.888/0001-70");

            Assert.IsTrue(wasCompanyRegistered);


        }


        [TestMethod]
        public async Task CreateCompanyCNPJ_IsInvalid()
        {


            try
            {


                CompanyService service = new CompanyService(this.context);

                Company company = new Company()
                {
                    Name = "Empresa Teste",
                    CNPJ = "111111111"
                };

                await service.Create(company);

            }
            catch (Exception ex)
            {
                Assert.AreEqual("CNPJ is invalid!", ex.Message);
            }


        }



        [TestMethod]

        public async Task CreateCompanyAlreadyExists()
        {


            try
            {

                await PrepareDatabase();


                var service = new CompanyService(this.context);

                var company = new Company()
                {
                    UserId = "59cc8c06-319a-424f-843d-aa66deed3c00",
                    Name = "Empresa Tester",
                    CNPJ = "111111111",

                };

                await service.Create(company);

                Assert.Fail();

            }
            catch (Exception ex)
            {

                Assert.AreEqual("Company was already registered!", ex.Message);

            }


        }

        private async Task PrepareDatabase()
        {

            var company = new Company()
            {
                UserId = "59cc8c06-319a-424f-843d-aa66deed3c00",
                Name = "Empresa Test",
                CNPJ = "111111111",

            };


            this.context.Companies.Add(company);
            await this.context.SaveChangesAsync();
        }

    }
}

