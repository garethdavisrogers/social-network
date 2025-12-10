namespace SocialNetworkV1.Models
{
    public class Friendship
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;

        public Guid FriendId { get; set; }
        public User Friend { get; set; } = default!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
