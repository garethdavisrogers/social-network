using Microsoft.AspNetCore.Mvc;
using SocialNetworkV1.Models;
using SocialNetworkV1.Services;

namespace SocialNetworkV1.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        [HttpGet("{name}")]
        public ActionResult<User> GetUser()
        {
            var user = _userService.GetUser();
            return user;
        }
        [HttpPost("{name}")]
        public IActionResult AddUser(string name, string email)
        {
            var user = _userService.AddUser(name, email);
            return Ok(user);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, User user)
        {
            _userService.UpdateUser(id, user);
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
