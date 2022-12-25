using Microsoft.AspNetCore.Identity;
using Moq;
using ProjectManagement.Data;
using ProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    public class MockHelper
    {
        public static Mock<UserManager<User>> MockUserManager(ApplicationDbContext context)
        {

            var userStore = new Mock<IUserStore<User>>();

            var userManager = new Mock<UserManager<User>>(userStore.Object, null, null, null, null, null, null, null, null);


            userManager.Object.UserValidators.Add(new UserValidator<User>()); 
            userManager.Object.PasswordValidators.Add(new PasswordValidator<User>());

            userManager.Setup(x => x.DeleteAsync(It.IsAny<User>()))
                       .ReturnsAsync(IdentityResult.Success);


            userManager.Setup(x => x.CreateAsync(It.IsAny<User>()))
                       .ReturnsAsync(IdentityResult.Success)
                       .Callback<User>(x =>
                       {
                           
                           context.Users.Add(x);
                           context.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                       }
                       );


            return userManager; 

        }

    }
}
