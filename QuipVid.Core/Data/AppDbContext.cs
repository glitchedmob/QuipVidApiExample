using Microsoft.EntityFrameworkCore;
using QuipVid.Core.Models;

namespace QuipVid.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Quip> Quips { get; set; }
    }
}
