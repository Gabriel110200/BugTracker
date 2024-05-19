using Microsoft.AspNetCore.Identity;
using ProjectManagement.Models;

namespace ProjectManagement.Services
{
    public class SignInResultWithUser
    {

        public SignInResult Result { get; set; }

        public IdentityUser User { get; set; }

    }
}