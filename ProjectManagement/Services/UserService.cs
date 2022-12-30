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

        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext _context;


        public UserService( ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            _context = context;
        }


        public bool  Register(IdentityUser user,string password)
        {

            try
            {

           
                return true;

              
            }catch(Exception ex)
            {
                throw ex;
            }



        }
}
}
