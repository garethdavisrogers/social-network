using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SocialNetworkV1.Models;

namespace SocialNetworkV1.Data
{
    public class UserDb: IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public UserDb(DbContextOptions options): base(options) { }
    }
}
