using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using UserData.Api.Controllers;
using UserData.Service.Models;
using UserData.Service.Services;

namespace UserData.Api.UnitTests
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userService;
        private readonly UserController _sut;

        public UserControllerTests()
        {
            _userService = new Mock<IUserService>();
            _sut = new UserController(_userService.Object);
        }

        [Fact]
        public async Task GetUsers_WithQueryParam_ReturnsOK()
        {
            // Arrange
            var input = "input";
            var serviceResult = new List<UserModel>();

            _userService.Setup(x => x.GetUsers(It.IsAny<string>())).ReturnsAsync(serviceResult);

            // Act
            var result = await _sut.GetUsers(input);


            // Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<IEnumerable<UserModel>>>(result);
        }

        [Fact]
        public async Task GetUsers_WithoutQueryParam_ReturnsOK()
        {
            // Arrange
            var input = string.Empty;
            var serviceResult = new List<UserModel>();

            _userService.Setup(x => x.GetUsers(It.IsAny<string>())).ReturnsAsync(serviceResult);

            // Act
            var result = await _sut.GetUsers(input);


            // Assert
            Assert.NotNull(result);
            Assert.IsType<ActionResult<IEnumerable<UserModel>>>(result);
        }
    }
}
