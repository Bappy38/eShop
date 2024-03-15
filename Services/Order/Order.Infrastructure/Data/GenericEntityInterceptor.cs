using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Order.Domain.Entities;

namespace Order.Infrastructure.Data;

public class GenericEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var context = eventData.Context;

        if (context is not null)
        {
            Handle(context);
        }

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;

        if (context is not null)
        {
            Handle(context);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    #region Private Methods

    private static void Handle(DbContext context)
    {
        var entries = context.ChangeTracker.Entries();

        foreach (var entry in entries)
        {
            if (entry.Entity is not EntityBase)
            {
                continue;
            }

            switch (entry.State)
            {
                case EntityState.Added:
                    HandleNewlyCreatedEntity(entry);
                    break;
                case EntityState.Modified:
                    HandleUpdatedEntity(entry);
                    break;
                default:
                    break;
            }
        }
    }

    private static void HandleNewlyCreatedEntity(EntityEntry entity)
    {
        //TODO:: Fix this CreatedBy property later
        entity.Property("CreatedBy").CurrentValue = "TODO";
        entity.Property("CreatedOnUtc").CurrentValue = DateTime.UtcNow;
        entity.Property("LastModifiedBy").CurrentValue = "TODO";
        entity.Property("LastModifiedOnUtc").CurrentValue = DateTime.UtcNow;
    }

    private static void HandleUpdatedEntity(EntityEntry entity)
    {
        entity.Property("LastModifiedBy").CurrentValue = "TODO";
        entity.Property("LastModifiedOnUtc").CurrentValue = DateTime.UtcNow;
    }

    #endregion
}
