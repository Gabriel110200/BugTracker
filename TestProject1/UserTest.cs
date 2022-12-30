using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagement.Data;
using ProjectManagement.Models;
using ProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]

    public class UserTest
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager; 
        public ApplicationDbContext context;


        public UserTest()
        {

            Connect connect = new Connect();

            this.context = connect.CriarContextInMemory();
     

        }

        [TestMethod]
        public async Task RegisterUserIsValid()
        {


            try
            {

                var users = new List<IdentityUser>
                {
                    new IdentityUser() { UserName = "teste", Email = "teste@hotmail.com" },
                    new IdentityUser() { UserName = "teste3", Email = "teste@gmail.com" }
                };

                var userManager = MockHelper.MockUserManager<IdentityUser>(users).Object;

                var user = new IdentityUser()
                {
                    UserName = "GabrielTeste",
                    Email = "tt@gmail.com"
                };


                UserService service = new UserService(this.context,userManager);
               

                var wasUserRegistered = service.Register(user,"Abc@123456");


                Assert.IsTrue(wasUserRegistered); 


            }catch(Exception ex)
            {
                Assert.Fail();
            }

        }









       



    }
}
