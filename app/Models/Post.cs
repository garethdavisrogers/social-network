namespace SocialNetworkV1.Models
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string Body { get; set; }

        public Post(Guid userId, string body) 
        {
            UserId = userId;
            Body = body;
        }
    }
}
