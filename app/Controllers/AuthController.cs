using Microsoft.AspNetCore.Mvc;
using SocialNetworkV1.Models;
using SocialNetworkV1.Services;
using SocialNetworkV1.DTOs.Requests.Users;
using SocialNetworkV1.DTOs.Responses.Users;
using SocialNetworkV1.DTOs.Requests.Auth;

namespace SocialNetworkV1.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService) => _userService = userService;

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Name) || string.IsNullOrWhiteSpace(req.Email) || string.IsNullOrWhiteSpace(req.Password))
            {
                return BadRequest("Name, email, and password are required.");
            }
            var (success, errors, user) = await _userService.RegisterUserAsync(req.Name, req.Email, req.Password);
            if (!success || user == null)
            {
                return BadRequest(new { errors });
            }

            var resp = new GetUserResponse(user.Id, user.Name, user.Email!, user.Posts);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, resp);
        }

        [HttpPost]

        public async Task<ActionResult> LoginUser([FromBody] LoginUserRequest req) 
        {
            if ((string.IsNullOrWhiteSpace(req.Name) && string.IsNullOrWhiteSpace(req.Email)) || string.IsNullOrWhiteSpace(req.Password))
            {
                return BadRequest("Name, email, and password are required.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var deletedSuccessfully = await _userService.DeleteUserAsync(id);
            if (!deletedSuccessfully)
            {
                return BadRequest("Something went wrong.");
            }
            return Ok();
        }
    }
}
