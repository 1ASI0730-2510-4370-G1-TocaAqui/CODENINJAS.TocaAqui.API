using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Evaluations.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CODENINJAS.TocaAqui.API.Evaluations.Infrastructure.Context;

public class EvaluationDbContext : AppDbContext
{
    public DbSet<Evaluation> Evaluations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configuration.EvaluationEntityTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}