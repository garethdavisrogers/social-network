namespace SocialNetworkV1.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<Guid> Connects { get; set; } = new List<Guid>();

        public List<Guid> Posts { get; set; } = new List<Guid>();

        public List<Guid> Messages { get; set; } = new List<Guid>();
        public User(string name, string email) 
        {
            Id = Guid.Empty;
            Name = name;
            Email = email;
        }

    }
}
