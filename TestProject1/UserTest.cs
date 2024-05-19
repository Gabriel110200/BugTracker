using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectManagement.Controllers;
using ProjectManagement.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ProjectManagement.Models.Request;
using ProjectManagement.Models;

namespace ProjectManagement.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public async Task RegisterUser_ValidUserRequest_ReturnsCreatedResult()
        {
            //var userServiceMock = new Mock<IUserService>();
            //userServiceMock.Setup(u => u.Register(It.IsAny<IdentityUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            //var controller = new UserController(userServiceMock.Object);
            //var request = new UserRequest
            //{
            //    UserName = "TestUser",
            //    Mail = "test@example.com",
            //    Password = "Password123",
            //};


            //var result = await controller.RegisterUser(request) as CreatedResult;


            //Assert.IsNotNull(result);
            //Assert.AreEqual(201, result.StatusCode);
        }

        [TestMethod]
        public async Task Login_ValidLoginRequest_ReturnsOkResultWithJwtToken()
        {

            //var userServiceMock = new Mock<IUserService>();
            //userServiceMock.Setup(u => u.SignIn(It.IsAny<LoginRequest>())).ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);
            //var controller = new UserController(userServiceMock.Object);
            //var request = new LoginRequest
            //{
            //    Mail = "test@example.com",
            //    Password = "Password123",
            //};


            //var result = await controller.Login(request) as OkObjectResult;


            //Assert.IsNotNull(result);
            //Assert.AreEqual(200, result.StatusCode);

        }


    }
}
