using Microsoft.EntityFrameworkCore;
using GenericRepository.Domain;

namespace GenericRepository.Data.Context
{
  public class GRContext : DbContext
  {
    public GRContext(DbContextOptions<GRContext> options)
        : base(options) { }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Application> Applications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //modelBuilder.Entity<PermissionUser>()
      //  .HasKey(Pe => new { Pe.UserId, Pe.PermissionId});
      //modelBuilder.Entity<User>().HasMany<Permission>(b => b.Permissions);
              
    }

  }
}