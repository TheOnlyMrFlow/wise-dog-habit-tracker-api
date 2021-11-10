using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TWD.HabitTracker.Domain.Entities.Habits;

namespace TWD.HabitTracker.Infra.Persistence.EFCore;

public abstract class Context : DbContext
{
    public DbSet<Habit> Habits { get; set; }

    // public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    // {
    //     foreach (var entry in ChangeTracker.Entries())
    //     {
    //         if (entry.State is not (EntityState.Added or EntityState.Modified)) 
    //             continue;
    //
    //         if (entry.Entity is not ITimestampEntity entity) 
    //             continue;
    //
    //         if (entry.State == EntityState.Added)
    //             entity.CreatedAt = DateTime.UtcNow;
    //             
    //         entity.UpdatedAt = DateTime.UtcNow;
    //     }
    //
    //     return base.SaveChangesAsync(cancellationToken);
    // }
}