using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppContex(DbContextOptions<AppContex> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(x => x.Id);
        modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(100);
        modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(50);
        base.OnModelCreating(modelBuilder);
    }
}