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
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Email) || string.IsNullOrWhiteSpace(req.Password))
            {
                return BadRequest("Email, and Password are required.");
            }
            var (success, errors, user) = await _authService.RegisterUserAsync(req.Email, req.Password);
            if (!success || user == null)
            {
                return BadRequest(new { errors });
            }

            var resp = new GetUserResponse(user.Id, user.Name, user.Email!, user.Posts);
            return CreatedAtRoute("GetUserById", new { id = user.Id }, resp);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginUserResponse>> LoginUser([FromBody] LoginUserRequest req) 
        {
            if (string.IsNullOrWhiteSpace(req.UserNameOrEmail) || string.IsNullOrWhiteSpace(req.Password))
            {
                return BadRequest("Name or email, and password are required.");
            }
            var (success, token, errors, user) = await _authService.LoginUserAsync(req.UserNameOrEmail, req.Password);
            if (!success || token == null || user == null) 
            {
                return BadRequest(new { errors });
            }
            var resp = new LoginUserResponse(user.Id, user.Name, user.Email!, token);
            return resp;
        }

    }
}
