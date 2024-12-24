using Event.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Event.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Event.Persistence.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Domain.Entities.Event> Events { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entities.Event>().OwnsOne(e => e.Location);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var data = ChangeTracker.Entries<EntityBase>();
        foreach (var entry in data)
        {
            if (entry.State == EntityState.Added)
                entry.Entity.CreatedDate = DateTimeOffset.Now;
            else if (entry.State == EntityState.Modified)
                entry.Entity.ModifiedDate = DateTimeOffset.Now;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}