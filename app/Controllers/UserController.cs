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

            return Ok(new GetUserResponse(user.Id, user.Name, user.Email, user.Posts));
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Name) || string.IsNullOrWhiteSpace(req.Email)) 
            {
                return BadRequest("Name and email are required.");
            }
            var user = _userService.CreateUser(req.Name, req.Email);

            var resp = new GetUserResponse(user.Id, user.Name, user.Email, user.Posts);
            return CreatedAtAction(nameof(GetUser), new {id = user.Id }, resp);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequest updateUserRequest)
        {
            var updatedUser = _userService.UpdateUser(id, updateUserRequest.Name, updateUserRequest.Email);
            if(updatedUser == null) return NotFound();

            var resp = new GetUserResponse(updatedUser.Id, updatedUser.Name, updatedUser.Email, updatedUser.Posts);
            return Ok(resp);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var deletedSuccessfully = _userService.DeleteUser(id);
            if (deletedSuccessfully == false) 
            {
                return BadRequest("Something went wrong.");
            }
            return Ok();
        }
    }
}
