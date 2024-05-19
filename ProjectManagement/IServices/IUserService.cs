using Microsoft.AspNetCore.Identity;
using ProjectManagement.Models.Request;
using ProjectManagement.Services;
using System.Threading.Tasks;

namespace ProjectManagement.IServices
{
    public interface IUserService 
    {

        Task<IdentityResult> Register(IdentityUser user, string password);

        Task<IdentityUser> Get(string id);

        Task<SignInResultWithUser> SignIn(LoginRequest request);


    }
}
