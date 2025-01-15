using Microsoft.EntityFrameworkCore;
using WALogin.Models;

namespace WALogin.Data
{
    public class AppDbContext: DbContext
    {
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Entity
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
