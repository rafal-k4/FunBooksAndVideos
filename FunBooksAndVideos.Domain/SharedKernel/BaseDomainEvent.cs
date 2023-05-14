using MediatR;

namespace FunBooksAndVideos.Domain.SharedKernel;

public abstract class BaseDomainEvent : INotification
{
    public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;

}
