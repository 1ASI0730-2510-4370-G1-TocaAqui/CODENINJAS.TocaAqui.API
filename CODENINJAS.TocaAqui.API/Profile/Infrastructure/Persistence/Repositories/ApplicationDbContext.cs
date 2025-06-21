using Microsoft.EntityFrameworkCore;

namespace CODENINJAS.TocaAqui.API.Profile.Infrastructure.Persistence.Repositories;

public class ApplicationDbContext : DbContext
{
    public DbSet<CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates.Profile> Profiles { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}