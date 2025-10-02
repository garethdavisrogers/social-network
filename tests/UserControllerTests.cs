using SocialNetworkV1.Models;
using SocialNetworkV1.Services;
using SocialNetworkV1.Controllers;

using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkV1.DTOs.Responses.Users;

namespace SocialNetworkV1.Tests
{
    public class UserControllerTests
    {
        private static UserController SUT(Mock<IUserService> userService) => new UserController(userService.Object);

        public class Get : UserControllerTests 
        {
            [Fact]
            public void Get_returns_404_when_user_does_not_exist() 
            {
                var userService = new Mock<IUserService>();
                userService.Setup(s => s.GetUser(It.IsAny<Guid>())).Returns((User?)null);

                var sut = SUT(userService);
                ActionResult<GetUserResponse> res = sut.GetUser(Guid.NewGuid());

                res.Result.Should().BeOfType<NotFoundResult>();
                res.Value.Should().BeNull();
            }

            [Fact]
            public void Get_returns_200_when_user_exists() 
            {
                var user = new User("Alice", "alice@example.com");
                var userService = new Mock<IUserService>();
                userService.Setup(s=>s.GetUser(user.Id)).Returns(user);

                var sut = SUT(userService);
                ActionResult<GetUserResponse> res = sut.GetUser(user.Id);

                res.Result.Should().BeOfType<OkObjectResult>();
                var ok = (OkObjectResult)res.Result!;
                ok.StatusCode.Should().Be(200);

                ok.Value.Should().BeOfType<GetUserResponse>()
                   .Which.Email.Should().Be("alice@example.com");

            }
        }
    }
}
