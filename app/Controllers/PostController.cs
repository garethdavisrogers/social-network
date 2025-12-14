using Microsoft.AspNetCore.Mvc;
using SocialNetworkV1.Models;
using SocialNetworkV1.Services;
using SocialNetworkV1.DTOs.Requests.Users;
using SocialNetworkV1.DTOs.Responses.Users;
using SocialNetworkV1.DTOs.Requests.Auth;

namespace SocialNetworkV1.Controllers
{
    [ApiController]
    [Route("post")]
    public class PostController : Controller
    {
        private readonly IAuthService _authService;
        public PostController(IAuthService authService) => _authService = authService;

        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] CreateUserRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.email) || string.IsNullOrWhiteSpace(req.password))
            {
                return BadRequest("Email, and Password are required.");
            }
            var (success, errors, user) = await _authService.RegisterUserAsync(req.email, req.password);
            if (!success || user == null)
            {
                return BadRequest(new { errors });
            }

            var resp = new GetUserResponse(user.Id, user.Name, user.Email!, user.Posts);
            return CreatedAtRoute("GetUserById", new { id = user.Id }, resp);
        }

    }
}
