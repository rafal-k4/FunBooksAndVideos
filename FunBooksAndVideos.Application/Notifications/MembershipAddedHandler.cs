using MediatR;
using FunBooksAndVideos.Domain.DomainEvents;
using FunBooksAndVideos.Domain.AggregateRoots.Customer;
using FunBooksAndVideos.Application.Commands;

namespace FunBooksAndVideos.Application.Notifications;

public class MembershipAddedHandler : INotificationHandler<MembershipPurchasedEvent>
{
    private readonly IRequestHandler<UpdateCustomerMembershipCommandRequest> _commandHandler;

    public MembershipAddedHandler(IRequestHandler<UpdateCustomerMembershipCommandRequest> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public async Task Handle(MembershipPurchasedEvent notification, CancellationToken cancellationToken)
    {
        var commandRequest = new UpdateCustomerMembershipCommandRequest
        {
            CustomerId = notification.CustomerId,
            MembershipName = notification.MembershipName
        };

        await _commandHandler.Handle(commandRequest, cancellationToken);
    }
}
