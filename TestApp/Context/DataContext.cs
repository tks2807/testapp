using Microsoft.EntityFrameworkCore;
using TestApp.EFCore;

namespace TestApp.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserPermission>()
            .HasKey(x => new { x.UserId, x.PermissionId });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; } 
        public DbSet<UserPermission> UserPermissions { get; set; }
    }
}
