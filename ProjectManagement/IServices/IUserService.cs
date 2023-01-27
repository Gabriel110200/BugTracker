using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ProjectManagement.IServices
{
    public interface IUserService 
    {

        Task<IdentityResult> Register(IdentityUser user, string password);

        Task<IdentityUser> Get(string id);
        


    }
}
