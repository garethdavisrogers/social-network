namespace SocialNetworkV1.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public User() 
        {
            Id = Guid.NewGuid();
            Name = "NewUser";
            Email = "user@example.com";
        }

    }
}
