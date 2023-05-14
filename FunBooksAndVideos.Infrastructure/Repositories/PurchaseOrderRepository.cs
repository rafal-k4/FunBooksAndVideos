using FunBooksAndVideos.Domain.AggregateRoots.PurchaseOrder;

namespace FunBooksAndVideos.Infrastructure.Repositories;

public class PurchaseOrderRepository : IPurchaseOrderRepository
{
    private readonly OrdersDbContext _dbContext;

    public PurchaseOrderRepository(OrdersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(PurchaseOrder purchaseOrder, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(purchaseOrder, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<PurchaseOrder?> GetAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.FindAsync<PurchaseOrder>(id, cancellationToken);
    }
}
