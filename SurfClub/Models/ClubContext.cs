using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SurfClub.Models
{
    public class ClubContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Post> Posts { get; set; }

        public ClubContext(DbContextOptions<ClubContext> options)
           : base(options)
        {
        }

    }
}
