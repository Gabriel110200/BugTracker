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

        //[TestMethod]

        //public async Task GetOwnedUserCompanies_IsValid(Guid userId)
        //{

        //    try
        //    {

            

        //    CompanyService service = new CompanyService(this.context);

        //    var companies = service.GetOwnedUserCompanies(userId);

        //    if (companies == null)
        //        Assert.Fail(); 
        //    else
        //    {
        //        var isUserAdmin = this.context.Companies.Any(x => x.Admins.Any(x => x.Id == userId));

        //        Assert.IsTrue(isUserAdmin);
        //    }

        //    }
        //    catch(Exception e)
        //    {
        //        Assert.Fail();
        //    }



        //}


        [TestMethod]
        public async Task CompanyAlreadyRegistered()
        {
            CompanyService service = new CompanyService(this.context);

           


        }


    }
}
