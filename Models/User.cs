namespace SocialNetworkV1.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public User() { }
        public User(string? name, string? email) 
        {
            Id = Guid.Empty;
            Name = string.IsNullOrEmpty(name) ? "NewUser": name;
            Email = string.IsNullOrEmpty(email) ? "user@example.com": email;
        }

    }
}
