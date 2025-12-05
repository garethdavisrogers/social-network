using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using SocialNetworkV1.Data;
using SocialNetworkV1.Models;
using SocialNetworkV1.Services;
using Xunit;

namespace SocialNetworkV1.Tests.Services
{
    public class UserServiceTests
    {
        private static Mock<UserManager<User>> CreateUserManagerMock() 
        { 
            var store =  new Mock<IUserStore<User>>();
            return new Mock<UserManager<User>>(
                store.Object,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
                );
        }

        [Fact]
        public async Task GetUserAsync_ReturnsUser_WhenUserExists() 
        {
            var userManagerMock = CreateUserManagerMock();

            var userId = Guid.NewGuid();
            var user = new User { Id = userId, Email = "test@example.com" };

            userManagerMock.Setup(m => m.FindByIdAsync(userId.ToString())).ReturnsAsync(user);

            // UserDb is never used, so this is fine:
            var userDbMock = new Mock<UserDb>(new DbContextOptions<UserDb>());

            var sut = new UserService(userManagerMock.Object, userDbMock.Object);

            // Act
            var result = await sut.GetUserAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result!.Id);

        }

    }
}
