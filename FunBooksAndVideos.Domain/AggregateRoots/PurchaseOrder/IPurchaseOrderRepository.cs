namespace FunBooksAndVideos.Domain.AggregateRoots.PurchaseOrder;

public interface IPurchaseOrderRepository
{
    public Task<PurchaseOrder?> GetAsync(int id, CancellationToken cancellationToken);
    public Task CreateAsync(PurchaseOrder purchaseOrder, CancellationToken cancellationToken);
}
