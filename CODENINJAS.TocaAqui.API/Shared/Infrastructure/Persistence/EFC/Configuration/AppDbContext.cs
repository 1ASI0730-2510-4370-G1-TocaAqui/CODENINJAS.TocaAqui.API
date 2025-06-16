using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregates;
using CODENINJAS.TocaAqui.API.Events.Domain.Model.Entities;
using CODENINJAS.TocaAqui.API.IAM.Domain.Model.Aggregates;                // + IAM
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
        builder.Entity<EventApplicant>().HasOne<Event>()
            .WithMany()
            .HasForeignKey(ea => ea.EventId)
            .IsRequired();
        
        // Contract Configuration
        builder.Entity<Contract>().HasKey(c => c.Id);
        builder.Entity<Contract>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Contract>().Property(c => c.Content).IsRequired().HasMaxLength(5000);
        builder.Entity<Contract>().Property(c => c.Signature).HasMaxLength(1000);
        builder.Entity<Contract>().HasOne<EventApplicant>()
            .WithOne()
            .HasForeignKey<Contract>(c => c.EventApplicationId)
            .IsRequired();

        // RiderTechnical Configuration
        builder.Entity<RiderTechnical>().HasKey(r => r.Id);
        builder.Entity<RiderTechnical>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<RiderTechnical>().Property(r => r.Content).IsRequired().HasMaxLength(5000);
        builder.Entity<RiderTechnical>().HasOne<EventApplicant>()
            .WithOne()
            .HasForeignKey<RiderTechnical>(r => r.EventApplicationId)
            .IsRequired();

        // Invitation Configuration
        builder.Entity<Invitation>().HasKey(i => i.Id);
        builder.Entity<Invitation>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Invitation>().Property(i => i.Status).IsRequired().HasMaxLength(50);
        builder.Entity<Invitation>().Property(i => i.Message).HasMaxLength(1000);

        // ---------- IAM – USER ---------------------------------------------
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id)          .IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Name)        .IsRequired().HasMaxLength(200);
        builder.Entity<User>().Property(u => u.Email)       .IsRequired().HasMaxLength(320);
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        builder.Entity<User>().Property(u => u.Role)        .IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(u => u.Genre)       .HasMaxLength(100);
        builder.Entity<User>().Property(u => u.Type)        .HasMaxLength(50);
        builder.Entity<User>().Property(u => u.Description) .HasMaxLength(1000);
        builder.Entity<User>().Property(u => u.ImageUrl)    .HasMaxLength(500);


        // ---------- snake_case (opcional) ----------------------------------
        builder.UseSnakeCaseNamingConvention();
        builder.Entity<Invitation>().HasOne<Event>()
            .WithMany()
            .HasForeignKey(i => i.EventId)
            .IsRequired();
    }
}
