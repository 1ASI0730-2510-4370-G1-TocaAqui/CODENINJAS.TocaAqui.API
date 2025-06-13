using CODENINJAS.TocaAqui.API.Events.Domain.Model.Aggregate;
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
        builder.Entity<Event>(e =>
        {
            e.ToTable("event");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            e.Property(x => x.Name).IsRequired().HasMaxLength(200);
            e.Property(x => x.Description).HasMaxLength(1000);
            e.Property(x => x.Equipment).HasMaxLength(500);
            e.Property(x => x.Requirements).HasMaxLength(500);
            e.Property(x => x.ImageUrl).HasMaxLength(500);
            e.Property(x => x.Location).HasMaxLength(500);
            
            // Configure EventAdmin as owned type
            e.OwnsOne(x => x.Admin, admin =>
            {
                admin.Property(a => a.Name).HasColumnName("admin_name").HasMaxLength(100);
                admin.Property(a => a.Contact).HasColumnName("admin_contact").HasMaxLength(200);
                admin.Property(a => a.Id).HasColumnName("admin_id");
            });

            // Configure value objects
            e.OwnsOne(x => x.EventTime);
            e.OwnsOne(x => x.SoundcheckTime);
            e.OwnsOne(x => x.Payment);
        });

        // EventApplicant Configuration
        builder.Entity<EventApplicant>(ea =>
        {
            ea.ToTable("event_applicant");
            ea.HasKey(x => x.Id);
            ea.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            ea.Property(x => x.Status).IsRequired().HasMaxLength(50);
        });
        
        // Invitation Configuration
        builder.Entity<Invitation>(i =>
        {
            i.ToTable("invitation");
            i.HasKey(x => x.Id);
            i.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            i.Property(x => x.EventName).IsRequired().HasMaxLength(100);
            i.Property(x => x.EventLocation).IsRequired().HasMaxLength(200);
            i.Property(x => x.EventImageUrl).HasMaxLength(500);
            i.Property(x => x.PromoterName).IsRequired().HasMaxLength(100);
            i.Property(x => x.ArtistName).IsRequired().HasMaxLength(100);
            i.Property(x => x.Message).HasMaxLength(1000);
            i.Property(x => x.Status).IsRequired().HasMaxLength(50);
        });

        // Contract Configuration
        builder.Entity<Contract>(c =>
        {
            c.ToTable("contract");
            c.HasKey(x => x.Id);
            c.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            c.Property(x => x.Content).HasMaxLength(5000);
        });

        // RiderTechnical Configuration
        builder.Entity<RiderTechnical>(r =>
        {
            r.ToTable("rider_technical");
            r.HasKey(x => x.Id);
            r.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            r.Property(x => x.FilePath).IsRequired().HasMaxLength(500);
        });
    }
} 
