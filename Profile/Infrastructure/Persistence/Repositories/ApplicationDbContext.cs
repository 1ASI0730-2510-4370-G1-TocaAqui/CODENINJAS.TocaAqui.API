using Microsoft.EntityFrameworkCore;

namespace tocaaqui_backend.Profile.Infrastructure.Persistence.Repositories;

public class ApplicationDbContext : DbContext
{
    public DbSet<Domain.Model.Aggregates.Profile> Profiles { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}