using FunBooksAndVideos.Application.MessagesContracts;
using FunBooksAndVideos.Domain.DomainEvents;
using MassTransit;
using MediatR;

namespace FunBooksAndVideos.Application.Notifications;

public class PhysicalProductPurchasedHandler : INotificationHandler<PhysicalProductPurchasedEvent>
{
    private readonly IBus _bus;

    public PhysicalProductPurchasedHandler(IBus bus)
    {
        _bus = bus;
    }

    public async Task Handle(PhysicalProductPurchasedEvent notification, CancellationToken cancellationToken)
    {
        await _bus.Publish(new PhysicalProductOrdered { ProductName = notification.ProductName }, cancellationToken);
    }
}
