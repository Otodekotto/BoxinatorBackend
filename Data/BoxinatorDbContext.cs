using BoxinatorBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BoxinatorBackend.Data
{
    public class BoxinatorDbContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Country> Countrys { get; set; }

        public BoxinatorDbContext(DbContextOptions options) : base(options) { }
    }
}
