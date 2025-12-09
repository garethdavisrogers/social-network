using SocialNetworkV1.Models;
using SocialNetworkV1.Data;
using Microsoft.AspNetCore.Identity;

namespace SocialNetworkV1.Services
{
    public interface IPostService
    {
        Task<(bool Success, IEnumerable<string> Errors, Post? post)> CreatePostAsync(Guid userId, string body);
    }
    public class PostService : IPostService
    {
        private readonly UserManager<User> _userManager;

        public PostService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        public async Task<(bool Success, IEnumerable<string> Errors, Post? post)> CreatePostAsync(Guid userId, string body)
        {
            var post = new Post(userId, body);

            return (true, Enumerable.Empty<string>(), post);
        }

    }
}
