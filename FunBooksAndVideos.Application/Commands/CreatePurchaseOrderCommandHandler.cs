using MediatR;

namespace FunBooksAndVideos.Application.Commands;

public class CreatePurchaseOrderCommandHandler : IRequestHandler<CreatePurchaseOrderCommandRequest, Unit>
{
    public Task<Unit> Handle(CreatePurchaseOrderCommandRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new Unit());
    }
}
