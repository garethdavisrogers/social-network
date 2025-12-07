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

        [HttpGet("{id:guid}", Name = "GetUserById")]
        public async Task<ActionResult<GetUserResponse>> GetUser(Guid id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null) return NotFound();

            var resp = new GetUserResponse(user.Id, user.Name, user.Email!, user.Posts);
            return Ok(resp);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest updateUserRequest)
        {
            var updatedUser = await _userService.UpdateUserAsync(id, updateUserRequest.Name, updateUserRequest.Email);
            if(updatedUser == null) return NotFound();

            var resp = new GetUserResponse(updatedUser.Id, updatedUser.Name, updatedUser.Email!, updatedUser.Posts);
            return Ok(resp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var deletedSuccessfully = await _userService.DeleteUserAsync (id);
            if (!deletedSuccessfully) 
            {
                return BadRequest("Something went wrong.");
            }
            return Ok();
        }
    }
}
