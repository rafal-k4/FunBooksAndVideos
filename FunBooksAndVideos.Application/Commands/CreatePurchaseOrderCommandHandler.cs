using FunBooksAndVideos.Domain.AggregateRoots;
using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.SharedKernel;
using MediatR;

namespace FunBooksAndVideos.Application.Commands;

public class CreatePurchaseOrderCommandHandler : IRequestHandler<CreatePurchaseOrderCommandRequest, Unit>
{
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public CreatePurchaseOrderCommandHandler(IPurchaseOrderRepository purchaseOrderRepository)
    {
        _purchaseOrderRepository = purchaseOrderRepository;
    }

    public async Task<Unit> Handle(CreatePurchaseOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var purchaseOrder = new PurchaseOrder(
            request.PurchaseOrderId,
            request.TotalPrice,
            request.CustomerId,
            new Membership(1, MembershipType.BookClub),
            new List<Product>
            {
                new Product(0, "book", ProductType.Physical),
                new Product(1, "video", ProductType.Digital)
            });

        await _purchaseOrderRepository.CreateAsync(purchaseOrder, cancellationToken);

        return new Unit();
    }
}
