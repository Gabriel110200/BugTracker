using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Data;
using ProjectManagement.IServices;
using ProjectManagement.Models;
using ProjectManagement.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Threading.Tasks;
using ProjectManagement.Models.Request;
using ProjectManagement.Helper;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ICompanyRepository companyRepository;
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork unitOfWork;
        private IUserService UserService;

        public UserController(IUserService userService, ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            UserService = userService;
            this.companyRepository = companyRepository;
            this.unitOfWork = unitOfWork;
        }


        [HttpPost("[Action]")]
        public async Task<IActionResult> RegisterUser(UserRequest request)
        {
            try
            {

                using (var transaction = await this.unitOfWork.BeginTransactionAsync())
                {

                    var iUser = new IdentityUser
                    {
                        UserName = request.UserName,
                        Email = request.Mail,
                    };

                    var wasUserRegistered = await this.UserService.Register(iUser, request.Password);

                    if (wasUserRegistered.Succeeded)
                    {

                        var company = new CompanyRequest()
                        {
                            CNPJ = request.CNPJ,
                            Name = request.CompanyName,
                            UserId = iUser.Id
                        };

                        await this.CreateCompany(company);

                        await this.unitOfWork.Commit();
                        transaction.Commit();
                        return Created("~/api/CreateUser", new { User = iUser });
                    }


                    transaction.Rollback();
                    return BadRequest(wasUserRegistered);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [NonAction]
        public async Task CreateCompany(CompanyRequest request)
        {
            if (this.companyRepository.IsCompanyAlreadyRegistered(request))
            {

                throw new Exception("Empresa já registrada");

            }

            if (!Helpers.ValidateCnpj(request.CNPJ))
            {
                throw new Exception("CNPJ inválido");
            }

            var company = new Company()
            {
                Name = request.Name,
                Description = request.Description,
                CNPJ = request.CNPJ,
                CorporateName = request.CorporateName,
                Image = request.Image,
                UserId = request.UserId

            };

            await this.companyRepository.AddAsync(company);

        }



        [HttpPost("[Action]")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {

            var result = await this.UserService.SignIn(request);

            var jwtToken = this.GenerateJwtToken(request.Mail);

            if (result.Result.Succeeded)
            {

                return Ok(new
                {
                    Result = result,
                    Jwt = jwtToken
                });

            }
            else
            {
                return BadRequest("Usuário não encontrado");
            }



        }

        private string GenerateJwtToken(string username)
        {

            string key = "this is my custom Secret key for authentication"; // Your key as a string
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var securityKey = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: new[] { new Claim(ClaimTypes.Name, username) },
                expires: DateTime.Now.AddMinutes(90),
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }


    }
}
