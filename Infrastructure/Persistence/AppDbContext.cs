using Microsoft.EntityFrameworkCore;
using tocaaqui_backend.Domain.Users.Entities;

namespace tocaaqui_backend.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<User>(cfg =>
        {
            cfg.HasKey(u => u.Id);
            cfg.Property(u => u.Name).IsRequired();

            cfg.OwnsOne(u => u.Email,
                e => e.Property(p => p.Value).HasColumnName("Email").IsRequired());

            cfg.OwnsOne(u => u.Password,
                p => p.Property(h => h.Value).HasColumnName("PasswordHash").IsRequired());

            cfg.OwnsOne(u => u.Image,
                i => i.Property(v => v.Value).HasColumnName("ImageUrl"));
        });
    }
}
