using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagement.Data;
using ProjectManagement.Models;
using ProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            PrepareDatabase();
        }

     

        [TestMethod]
        public async Task CreateCompanyIsValid()
        {



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
            catch(Exception ex)
            {
                Assert.AreEqual("CNPJ is invalid!", ex.Message);
            }


        }



        [TestMethod]

        public async Task CreateCompanyAlreadyExists()
        {
            PrepareDatabase();

            try
            {
                var service =new CompanyService(this.context);

                var company = new Company()
                {
                    UserId = "59cc8c06-319a-424f-843d-aa66deed3c00",
                    Name = "Empresa Tester",
                    CNPJ = "111111111",

                };

                await service.Create(company);

                Assert.Fail();

            }catch(Exception ex)
            {

                Assert.AreEqual("Company already Registered", ex.Message);

            }


        }

        private  void PrepareDatabase()
        {

            var company = new Company()
            {
                UserId = "59cc8c06-319a-424f-843d-aa66deed3c00",
                Name = "Empresa Test",
                CNPJ = "111111111",

            };


             this.context.Companies.Add(company);
        }

    }
}
