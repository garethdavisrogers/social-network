using SocialNetworkV1.Models;
using SocialNetworkV1.Data;
using Microsoft.AspNetCore.Identity;

namespace SocialNetworkV1.Services
{
    public interface IAuthService
    {
        Task<(bool Success, IEnumerable<string> Errors, User? User)> RegisterUserAsync(string name, string email, string password);
        Task<(bool success, string? token, IEnumerable<string> errors, User? user)> LoginUserAsync(string userNameOrEmail, string password);

    }
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<(bool Success, IEnumerable<string> Errors, User? User)> RegisterUserAsync(string name, string email, string password)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                UserName = email
            };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return (false, errors, null);
            }

            return (true, Enumerable.Empty<string>(), user);
        }

        public async Task<(bool success, string? token, IEnumerable<string> errors, User? user)> LoginUserAsync(string userNameOrEmail, string password)
        {
            var user =  await _userManager.FindByEmailAsync(userNameOrEmail) ?? await _userManager.FindByNameAsync(userNameOrEmail);

            if (user == null) return (false, null, new[] { "Invalid UserName or Email" }, null);

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded)
            {
                return (false, null, new[] { "Invalid Password" }, null);
            }

            //TODO: Create JWT token
            var token = "SomeToken";
            return (true, token, Array.Empty<string>(), user);
        }

    }
}
