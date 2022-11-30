using Microsoft.AspNetCore.Identity;
using ProjectManagement.Models;
using System.Threading.Tasks;
using System;

namespace ProjectManagement.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> userManager;


        async Task<Guid> Register(ApplicationUser applicationUser)
        {
            var user = applicationUser;
            var result = await userManager.CreateAsync(user, Guid.NewGuid().ToString());
            var RolesDoUsuario = applicationUser.UserRoles;
            var RolesSelecionadas = applicationUser.SelectedRoles;
            
            if (result.Succeeded)
            {
                if (applicationUser.Admin) await userManager.AddToRoleAsync(user, "Admin");

                if (RolesSelecionadas != null || RolesDoUsuario != null)
                {
                    await userManager.RemoveFromRolesAsync(user, RolesDoUsuario);

                    if (RolesSelecionadas != null)
                    {
                        await userManager.AddToRolesAsync(user, RolesSelecionadas);
                    }

                }
             
                return user.Id;
            }
            else
            {
                throw new Exception("Ocorreu um erro ao criar usuário");
            }
        }

    }
}
