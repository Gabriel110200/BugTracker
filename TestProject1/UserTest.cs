using Microsoft.AspNetCore.Identity;
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
    public class UserTest
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager; 
        public ApplicationDbContext context;


        public UserTest(UserManager<User> userManager)
        {
            _userManager = userManager;

            Connect connect = new Connect();

            this.context = connect.CriarContextInMemory();
            
        }


        public async Task RegisterUserIsValid()
        {


            try
            {

           
                UserService service = new UserService();

                User user = new User()
                {
                    UserName = "UserTest",
                    Email = "teste@hotmail.com",
                    Password = "123456"
                };

              service.Register(user);

              var registeredUser = _userManager.FindByEmailAsync(user.Email);

              Assert.IsNotNull(registeredUser);


            }catch(Exception ex)
            {
                throw ex;
            }

        }

        public void PrepareDatabase()
        {
           



        }

    }
}
