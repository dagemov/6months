using Dagemov.Domain.Entities;
using Dagemov.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dagemov.Persistence;

public class DagemovDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<WorkShift> Shifts { get; set; }
    public DagemovDbContext(DbContextOptions<DagemovDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //fluent API (configurations)
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //Index entities

        //Securyti
        //modelBuilder.Entity<RefreshTokenEntity>().HasIndex(rt => rt.Token).IsUnique();
        //Important to don't delete our entities in cascade
        DisableCascadingDelete(modelBuilder);
    }

    private void DisableCascadingDelete(ModelBuilder modelBuilder)
    {
        var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
        foreach (var relationship in relationships)
        {
            if (relationship.DeleteBehavior == DeleteBehavior.Cascade)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
    private void ApplyAudit()
    {
        var now = DateTime.UtcNow;
        // Implement at service on the Infrastructure week
        var userName = "dagemov@defaultUserTest.com";

        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
        {
            if (entry.State == EntityState.Added)
                entry.Entity.MarkCreated(now, userName);

            if (entry.State == EntityState.Modified)
                entry.Entity.MarkUpdated(now, userName);
        }
    }

}
