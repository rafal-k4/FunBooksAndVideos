namespace FunBooksAndVideos.Domain.AggregateRoots;

public interface IPurchaseOrderRepository
{
    public Task<PurchaseOrder> Get(int id);
    public Task CreateAsync(PurchaseOrder purchaseOrder, CancellationToken cancellationToken);
}
