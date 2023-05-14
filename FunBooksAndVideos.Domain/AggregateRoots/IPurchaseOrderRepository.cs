namespace FunBooksAndVideos.Domain.AggregateRoots;

public interface IPurchaseOrderRepository
{
    public Task<PurchaseOrder?> GetAsync(int id, CancellationToken cancellationToken);
    public Task CreateAsync(PurchaseOrder purchaseOrder, CancellationToken cancellationToken);
}
