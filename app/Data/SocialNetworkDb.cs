using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SocialNetworkV1.Models;

namespace SocialNetworkV1.Data
{
    public class SocialNetworkDb : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public SocialNetworkDb(DbContextOptions<SocialNetworkDb> options) : base(options) { }

        public DbSet<Post> Posts { get; set; } = default!;

        public DbSet<Friendship> Friendships {  get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Friendship>().HasKey(f => new {f.UserId, f.FriendId});

            builder.Entity<Friendship>()
                .HasOne(f => f.User)
                .WithMany(u => u.Friendships)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Friendship>()
                .HasOne(f => f.Friend)
                .WithMany(u => u.FriendedBy)
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
