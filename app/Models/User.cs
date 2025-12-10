using Microsoft.AspNetCore.Identity;

namespace SocialNetworkV1.Models
{
    public class User: IdentityUser<Guid>
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public ICollection<Friendship> Friendships { get; set; } = new List<Friendship>();

        public ICollection<Friendship> FriendedBy { get; set; } = new List<Friendship>();

        public User() : base() { }
        public User(string name, string email) : base() 
        {
            Name = name;
            Email = email;
            UserName = email;
        }

    }
}
