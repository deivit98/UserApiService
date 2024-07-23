using Moq;
using UserApplication.Service.Services;
using UserData.DataAccess.Models;
using UserData.DataAccess.Repositories;
using UserData.Service.Services;

namespace UserData.Service.UnitTests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepo;
        private readonly IUserService _sut;

        public UserServiceTests()
        {
            _userRepo = new Mock<IUserRepository>();

            _sut = new UserService(_userRepo.Object);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task GetUsers_WithEmtyStringInput_ReturnEmptyList(string? input)
        {
            // Arrange

            // Act
            var result = await _sut.GetUsers(input);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetUsers_WithFullName_ShouldReturnOneResult()
        {
            // Arrange
            var input = "g";

            var serviceResult = new List<User>();

            var expectedModelToBeReturned = new User()
            {
                Id = Guid.NewGuid(),
                DisplayName = "Georgi",
                Email = "g.someone@example.com",
                UserName = "gsomeone"
            };

            serviceResult.Add(expectedModelToBeReturned);

            _userRepo.Setup(x => x.GetUsers(input)).ReturnsAsync(serviceResult);

            // Act
            var result = await _sut.GetUsers(input);

            var listResult = result.ToList();

            // Arrange
            Assert.NotNull(result);
            Assert.Equal(serviceResult.Count, listResult.Count);
            Assert.Equal(serviceResult[0].DisplayName, listResult[0].DisplayName);
        }
    }
}
