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



        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>()))
                .ReturnsAsync(IdentityResult.Success);


            mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success)
                .Callback<TUser, string>((x, y) => ls.Add(x));


            mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

            return mgr;
        }


        //public static Mock<UserManager<IdentityUser>> MockUserManager(ApplicationDbContext context)
        //{

        //    var userStore = new Mock<IUserStore<IdentityUser>>();

        //    var userManager = new Mock<UserManager<IdentityUser>>(userStore.Object, null, null, null, null, null, null, null, null);


        //    userManager.Object.UserValidators.Add(new UserValidator<IdentityUser>()); 
        //    userManager.Object.PasswordValidators.Add(new PasswordValidator<IdentityUser>());

        //    userManager.Setup(x => x.DeleteAsync(It.IsAny<IdentityUser>()))
        //               .ReturnsAsync(IdentityResult.Success);

        //    mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));


        //    userManager.Setup(x => x.CreateAsync(It.IsAny<IdentityUser>()))
        //               .ReturnsAsync(IdentityResult.Success)
        //               .Callback<User>(x =>
        //               {

        //                   context.Users.Add(x);
        //                   context.SaveChangesAsync().ConfigureAwait(false).GetAwaiter().GetResult();

        //               }
        //               );


        //    return userManager; 

        //}

    }
}
