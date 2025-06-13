using CODENINJAS.TocaAqui.API.Evaluations.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CODENINJAS.TocaAqui.API.Evaluations.Infrastructure.Configuration;

public class EvaluationEntityTypeConfiguration : IEntityTypeConfiguration<Evaluation>
{
    public void Configure(EntityTypeBuilder<Evaluation> builder)
    {
        builder.ToTable("Evaluations");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(e => e.EntityType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.EntityId)
            .IsRequired();

        builder.Property(e => e.Score)
            .IsRequired();

        builder.Property(e => e.Comment)
            .HasMaxLength(500);

        builder.Property(e => e.CreatedAt)
            .IsRequired();
    }
}