using Microsoft.AspNetCore.Identity;
using ProjectManagement.Models;
using System.Threading.Tasks;
using System;
using ProjectManagement.Data;
using ProjectManagement.IServices;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models.Request;

namespace ProjectManagement.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<IdentityUser> userManager;

        private readonly SignInManager<IdentityUser> SignInManager;

        private readonly ApplicationDbContext _context;


        public UserService(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            _context = context;
            this.userManager = userManager;
            SignInManager = signInManager;
        }

        public Task<IdentityUser> Get(string id)
        {

            return  this._context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IdentityResult> Register(IdentityUser user, string password)
        {
          

            try
            {
                user.LockoutEnabled = false;
                user.EmailConfirmed = true;
                var wasUserRegistered = await this.userManager.CreateAsync(user, password);

                return wasUserRegistered;


            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public async Task<SignInResult> SignIn(LoginRequest request)
        {
            
            var user = await this._context.Users.Where(x => x.Email == request.Mail).FirstOrDefaultAsync();

            if (user != null)
            {
                
                var result = await this.SignInManager.CheckPasswordSignInAsync(user, request.Password, true);

                if (result.Succeeded)
                {
                    
                    await this.SignInManager.SignInAsync(user, isPersistent: false);
                    return result;
                }
            }

            return SignInResult.Failed; 
        }

    }
}
