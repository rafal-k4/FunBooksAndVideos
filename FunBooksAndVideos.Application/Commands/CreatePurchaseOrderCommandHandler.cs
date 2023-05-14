using FunBooksAndVideos.Domain.AggregateRoots.PurchaseOrder;
using MediatR;

namespace FunBooksAndVideos.Application.Commands;

public class CreatePurchaseOrderCommandHandler : IRequestHandler<CreatePurchaseOrderCommandRequest>
{
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public CreatePurchaseOrderCommandHandler(IPurchaseOrderRepository purchaseOrderRepository)
    {
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task Handle(CreatePurchaseOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var purchaseOrder = new PurchaseOrder(
            request.PurchaseOrderId,
            request.TotalPrice,
            request.CustomerId);

        purchaseOrder.ProcessOrder(request.ItemLines);

        await _purchaseOrderRepository.CreateAsync(purchaseOrder, cancellationToken);
    }
}
