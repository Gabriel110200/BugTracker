using Microsoft.AspNetCore.Identity;
using ProjectManagement.Models;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;

namespace ProjectManagement.Services
{
    public class UserService
    {

        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext _context;


        public UserService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }


        public async Task  Register()
        {

            try
            {

              //  var teste = new User() { Id = Guid.Parse("4986ef8d-5110-44b8-9e1c-70e4847b74a9"), UserName = "Teste" }; 

              //   var r =  await userManager.CreateAsync(teste, "123456");

            }catch(Exception ex)
            {
                throw ex;
            }



        }
}
}
