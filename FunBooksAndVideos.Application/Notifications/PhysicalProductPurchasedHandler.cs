using FunBooksAndVideos.Domain.DomainEvents;
using MediatR;

namespace FunBooksAndVideos.Application.Notifications;

public class PhysicalProductPurchasedHandler : INotificationHandler<PhysicalProductPurchasedEvent>
{
    public Task Handle(PhysicalProductPurchasedEvent notification, CancellationToken cancellationToken)
    {
        ;
        return Task.CompletedTask;
    }
}
