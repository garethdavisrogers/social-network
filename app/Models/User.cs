using Microsoft.AspNetCore.Identity;

namespace SocialNetworkV1.Models
{
    public class User: IdentityUser<Guid>
    {
        public string Name { get; set; }

        public List<Guid> Connects { get; set; } = new List<Guid>();

        public List<Guid> Posts { get; set; } = new List<Guid>();

        public List<Guid> Messages { get; set; } = new List<Guid>();

        public User() : base() { }
        public User(string name, string email) : base() 
        {
            Name = name;
            Email = email;
            UserName = email;
        }

    }
}
