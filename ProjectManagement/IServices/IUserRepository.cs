using Microsoft.AspNetCore.Identity;
using ProjectManagement.Models;
using static ProjectManagement.Repositories.UserRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManagement.IServices
{
    public interface IUserRepository : IRepositoryBase<IdentityUser>
    {

         Task<List<UserWithRolesDto>> GetUsers();
    }
}
