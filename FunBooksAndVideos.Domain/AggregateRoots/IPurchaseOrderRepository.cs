namespace FunBooksAndVideos.Domain.AggregateRoots;

public interface IPurchaseOrderRepository
{
    public Task<PurchaseOrder> Get(int id);
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}
