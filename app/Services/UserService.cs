using SocialNetworkV1.Models;
using SocialNetworkV1.Data;
using Microsoft.AspNetCore.Identity;

namespace SocialNetworkV1.Services
{
    public interface IUserService 
    {
        Task<User?> GetUserAsync(Guid id);
        Task<User?> UpdateUserAsync(Guid id, string? name, string? email);
        Task<bool> DeleteUserAsync(Guid id);
    }
    public class UserService: IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User?> GetUserAsync(Guid id) 
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<User?> UpdateUserAsync(Guid id, string? name, string? email) 
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return null;

            if (!string.IsNullOrWhiteSpace(name)) 
            {
                user.Name = name;
            }

            if (!string.IsNullOrWhiteSpace(email)) 
            {
                user.Email = email;
                user.UserName = email;
            }

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded) 
            {
                return null;
            }
            return user;
        }

        public async Task<bool> DeleteUserAsync(Guid id) 
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) 
            {
                return false;
            }
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

    }
}
