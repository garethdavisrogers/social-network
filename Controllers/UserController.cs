using Microsoft.AspNetCore.Mvc;
using SocialNetworkV1.Models;
using SocialNetworkV1.Services;
using SocialNetworkV1.DTOs.Requests.Users;

namespace SocialNetworkV1.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;

        [HttpGet("{id:guid}")]
        public ActionResult<User> GetUser(Guid id)
        {
            var user = _userService.GetUser(id);
            return user;
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            var user = _userService.CreateUser(createUserRequest.Name, createUserRequest.Email);
            return Ok(user);
        }
        [HttpPut("{id:guid}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest updateUserRequest)
        {
            _userService.UpdateUser(id, updateUserRequest.Name, updateUserRequest.Email);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
