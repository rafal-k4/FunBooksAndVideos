using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos.Domain.DomainEvents;

public class MembershipPurchasedEvent : BaseDomainEvent
{
    public string MembershipName { get; }
    public int CustomerId { get; set; }

    public MembershipPurchasedEvent(string membershipName, int customerId)
    {
        MembershipName = membershipName;
        CustomerId = customerId;
    }
}