using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Profile.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CODENINJAS.TocaAqui.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context for Toca Aquí Events platform
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Event Configuration
        builder.Entity<Event>().HasKey(e => e.Id);
        builder.Entity<Event>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Event>().Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Entity<Event>().Property(e => e.Description).HasMaxLength(1000);
        builder.Entity<Event>().Property(e => e.Location).IsRequired().HasMaxLength(300);
        builder.Entity<Event>().Property(e => e.Genre).HasMaxLength(100);
        builder.Entity<Event>().Property(e => e.Payment).HasPrecision(10, 2);

        // EventApplicant Configuration
        builder.Entity<EventApplicant>().HasKey(ea => ea.Id);
        builder.Entity<EventApplicant>().Property(ea => ea.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<EventApplicant>().Property(ea => ea.Status).IsRequired().HasMaxLength(50);
        
        // Contract Configuration
        builder.Entity<Contract>().HasKey(c => c.Id);
        builder.Entity<Contract>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Contract>().Property(c => c.Content).HasMaxLength(5000);

        // RiderTechnical Configuration
        builder.Entity<RiderTechnical>().HasKey(r => r.Id);
        builder.Entity<RiderTechnical>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<RiderTechnical>().Property(r => r.FilePath).IsRequired().HasMaxLength(500);

        // Invitation Configuration
        builder.Entity<Invitation>().HasKey(i => i.Id);
        builder.Entity<Invitation>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Invitation>().Property(i => i.Status).IsRequired().HasMaxLength(50);
        builder.Entity<Invitation>().Property(i => i.Message).HasMaxLength(1000);
        
        builder.Entity<Profile.Domain.Model.Aggregates.Profile>(b =>
        {
            b.ToTable("user");
            b.HasKey(p => p.Id);
            b.Property(p => p.Id)
                .HasConversion(
                    id => id.Value,
                    value => new CODENINJAS.TocaAqui.API.Profile.Domain.Model.ValueObjects.ProfileId(value))
                .IsRequired()
                .ValueGeneratedOnAdd();

            b.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            b.Property(p => p.Email)
                .HasConversion(
                    email => email.Value,
                    value => new CODENINJAS.TocaAqui.API.Profile.Domain.Model.ValueObjects.Email(value))
                .IsRequired()
                .HasMaxLength(320);

            b.Property(p => p.Genre)
                .IsRequired()
                .HasMaxLength(100);

            b.Property(p => p.Type)
                .IsRequired()
                .HasMaxLength(100);

            b.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000);

            b.Property(p => p.ProfileImagePath)
                .HasMaxLength(500);
        });
    }
} 
