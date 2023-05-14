using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos.Domain.DomainEvents;

internal class MembershipPurchasedEvent : BaseDomainEvent
{
    public string MemebrshipName { get; }

    public MembershipPurchasedEvent(string membershipName)
    {
        MemebrshipName = membershipName;
    }
}