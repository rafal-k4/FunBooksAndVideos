using FunBooksAndVideos.Domain.AggregateRoots.Customers;
using FunBooksAndVideos.Domain.AggregateRoots.PurchaseOrder;
using FunBooksAndVideos.Domain.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FunBooksAndVideos.Infrastructure;

public class OrdersDbContext : DbContext
{
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    private IMediator _mediator;

    public OrdersDbContext(DbContextOptions<OrdersDbContext> options, IMediator mediator)
        :base(options)
    {
        _mediator = mediator;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_mediator == null) return result;

        var entitiesWithEvents = ChangeTracker
            .Entries()
            .Select(e => e.Entity as BaseEntity<int>)
            .Where(e => e?.Events != null && e.Events.Any())
            .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.Events.ToArray();
            entity.Events.Clear();
            foreach (var domainEvent in events)
            {
                await _mediator.Publish(domainEvent).ConfigureAwait(false);
            }
        }

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
