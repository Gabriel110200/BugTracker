using Microsoft.AspNetCore.Identity;
using ProjectManagement.Models.Request;
using System.Threading.Tasks;

namespace ProjectManagement.IServices
{
    public interface IUserService 
    {

        Task<IdentityResult> Register(IdentityUser user, string password);

        Task<IdentityUser> Get(string id);

        Task<SignInResult> SignIn(LoginRequest request);


    }
}
