using Microsoft.AspNetCore.Mvc;
using SocialNetworkV1.Models;
using SocialNetworkV1.Services;
using SocialNetworkV1.DTOs.Requests.Users;
using SocialNetworkV1.DTOs.Responses.Users;

namespace SocialNetworkV1.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;

        [HttpGet("{id:guid}")]
        public ActionResult<GetUserResponse> GetUser(Guid id)
        {
            var user = _userService.GetUser(id);
            if (user == null) return NotFound();

            return Ok(new GetUserResponse(user.Name, user.Email, user.Posts));
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            var user = _userService.CreateUser(createUserRequest.Name, createUserRequest.Email);
            if(user == null) return NotFound();
            return Ok("User Created");
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
