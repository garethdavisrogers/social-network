using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using SocialNetworkV1.Models;
using SocialNetworkV1.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SocialNetworkV1.Tests.Services
{
    public class AuthServiceTests
    {
        private static Mock<UserManager<User>> CreateUserManagerMock()
        {
            var store = new Mock<IUserStore<User>>();

            return new Mock<UserManager<User>>(
                store.Object,
                null, // IOptions<IdentityOptions>
                null, // IPasswordHasher<User>
                null, // IEnumerable<IUserValidator<User>>
                null, // IEnumerable<IPasswordValidator<User>>
                null, // ILookupNormalizer
                null, // IdentityErrorDescriber
                null, // IServiceProvider
                null  // ILogger<UserManager<User>>
            );
        }

        private static Mock<SignInManager<User>> CreateSignInManagerMock(UserManager<User> userManager)
        {
            var contextAccessor = new Mock<IHttpContextAccessor>();
            var claimsFactory = new Mock<IUserClaimsPrincipalFactory<User>>();
            var options = new Mock<IOptions<IdentityOptions>>();
            var logger = new Mock<ILogger<SignInManager<User>>>();
            var schemes = new Mock<IAuthenticationSchemeProvider>();
            var confirmation = new Mock<IUserConfirmation<User>>();

            return new Mock<SignInManager<User>>(
                userManager,
                contextAccessor.Object,
                claimsFactory.Object,
                options.Object,
                logger.Object,
                schemes.Object,
                confirmation.Object
            );
        }

        [Fact]
        public async Task RegisterUserAsync_RegistersUser_WithValidInput()
        {
            // Arrange
            var userManagerMock = CreateUserManagerMock();
            var signInManagerMock = CreateSignInManagerMock(userManagerMock.Object);

            var name = "TestUser";
            var email = "TestUser@example.com";
            var password = "Password123!@#";

            // Make CreateAsync succeed
            userManagerMock
                .Setup(m => m.CreateAsync(It.IsAny<User>(), password))
                .ReturnsAsync(IdentityResult.Success);

            var sut = new AuthService(userManagerMock.Object, signInManagerMock.Object);

            // Act
            var (success, errors, createdUser) = await sut.RegisterUserAsync(email, password);

            // Assert
            Assert.True(success);
            Assert.Empty(errors);
            Assert.NotNull(createdUser);
            Assert.Equal(email, createdUser.Email);

            userManagerMock.Verify(m =>
                m.CreateAsync(
                    It.Is<User>(u => u.Email == email && u.UserName == email && u.Name == name),
                    password),
                Times.Once);
        }
    }
}
