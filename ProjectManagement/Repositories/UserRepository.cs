using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data;
using ProjectManagement.IServices;
using ProjectManagement.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Repositories
{
    public class UserRepository : RepositoryBase<IdentityUser>, IUserRepository
    {
        public ApplicationDbContext Context { get; }
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }

        public async Task<List<UserWithRolesDto>> GetUsers()  
        {
            var usersWithRoles = await Context.Users
                .Select(user => new UserWithRolesDto
                {
                    UserId = user.Id,
                    Email =  user.Email,
                    UserName = user.UserName,
                    Roles = (from userRole in Context.UserRoles
                             join role in Context.Roles on userRole.RoleId equals role.Id
                             where userRole.UserId == user.Id
                             select role.Name).ToList()
                }).ToListAsync();

            return usersWithRoles;
        }

        public class UserWithRolesDto
        {
            public string UserId { get; set; }
            public string UserName { get; set; }

            public string? Email { get; set; }

            public List<string> Roles { get; set; }
        }
    }
}
