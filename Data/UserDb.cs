using Microsoft.EntityFrameworkCore;
using SocialNetworkV1.Models;

namespace SocialNetworkV1.Data
{
    public class UserDb: DbContext
    {
        public UserDb(DbContextOptions options): base(options) { }
        public DbSet<User> users { get; set; } = null!;
    }
}
