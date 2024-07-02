using BasePlatform.API.Operation.Domain.Model.Aggregates;
using BasePlatform.API.Operation.Domain.Model.Entities;
using BasePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BasePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
         base.OnModelCreating(builder);
         builder.Entity<Guardian>().ToTable("guardians");
         builder.Entity<Guardian>().HasKey(g => g.Id);
         builder.Entity<Guardian>().Property(g => g.Id).ValueGeneratedOnAdd();
         builder.Entity<Guardian>().Property(g => g.FirstName).IsRequired();
         builder.Entity<Guardian>().Property(g => g.LastName).IsRequired();
         builder.Entity<Guardian>().Property(g => g.Address).IsRequired();
         builder.Entity<Guardian>().Property(g => g.Username).IsRequired();
         builder.Entity<Guardian>().Property(g => g.Gender).IsRequired();

         builder.Entity<Urgency>().ToTable("urgencies");
         builder.Entity<Urgency>().HasKey(u => u.Id);
         builder.Entity<Urgency>().Property(u => u.Id).ValueGeneratedOnAdd();
         builder.Entity<Urgency>().Property(u => u.Title).IsRequired();
         builder.Entity<Urgency>().Property(u => u.Latitude).IsRequired();
         builder.Entity<Urgency>().Property(u => u.Longitude).IsRequired();
         builder.Entity<Urgency>().Property(u => u.Summary).IsRequired();
         builder.Entity<Urgency>().Property(u => u.ReportedAt).IsRequired();
         
        builder.Entity<Urgency>().HasOne(u => u.Guardian).WithMany( g => g.Urgencies).HasForeignKey(u => u.GuardianId);
            
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}