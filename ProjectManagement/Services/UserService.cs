using Microsoft.AspNetCore.Identity;
using ProjectManagement.Models;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Services
{
    public class UserService
    {

        private readonly UserManager<User> userManager;

        public UserService()
        {
                
        }


        public async Task  Register(User user)
        {
         
            var result = await userManager.CreateAsync(user, user.Password);

            
           

        }
}
}
