using MediatR;

namespace FunBooksAndVideos.Application.Commands;

public class CreatePurchaseOrderCommandHandler : IRequestHandler<CreatePurchaseOrderCommandRequest, Unit>
{
    public Task<Unit> Handle(CreatePurchaseOrderCommandRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new Unit());
    }
}

public record CreatePurchaseOrderCommandRequest : IRequest<Unit>
{
    public int PurchaseOrderId { get; set; }
    public decimal TotalPrice { get; set; }
    public int CustomerId { get; set; }
    public List<string> ItemLines { get; set; } = new();
}