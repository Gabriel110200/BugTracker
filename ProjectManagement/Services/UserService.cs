using Microsoft.AspNetCore.Identity;
using ProjectManagement.Models;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using ProjectManagement.IServices;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<IdentityUser> userManager;

        private readonly ApplicationDbContext _context;


        public UserService(ApplicationDbContext context, UserManager<IdentityUser> userManager) 
        {
            this.userManager = userManager;
            _context = context;
            this.userManager = userManager;
        }

        public Task<IdentityUser> Get(string id)
        {

            return  this._context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IdentityResult> Register(IdentityUser user, string password)
        {


            try
            {
                var wasUserRegistered = await this.userManager.CreateAsync(user, "temp123465");

                return wasUserRegistered;


            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
    }
}
