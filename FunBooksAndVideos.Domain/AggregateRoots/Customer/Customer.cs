using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos.Domain.AggregateRoots.Customer;

public class Customer : BaseEntity<int>, IAggregateRoot
{
    private List<Membership> _memberships { get; set; } = new();
    public IEnumerable<Membership> Memberships => _memberships.AsEnumerable();

    public bool IsPremiumMemberShip
        => Memberships.Any(x => x.MembershipType == MembershipType.Premium) ||
            (Memberships.Any(x => x.MembershipType == MembershipType.BookClub) && Memberships.Any(x => x.MembershipType == MembershipType.VideoClub));

    public Customer(int customerId)
    {
        Id = customerId;
    }

    private Customer() { } // EF required

    public void UpdateMembership(string membershipName)
    {
        if (membershipName.Contains("book club", StringComparison.OrdinalIgnoreCase))
        {
            if (!Memberships.Any(x => x.MembershipType == MembershipType.BookClub))
                _memberships.Add(new Membership { MembershipType = MembershipType.BookClub });

            return;
        }
            

        if (membershipName.Contains("video club", StringComparison.OrdinalIgnoreCase))
        {
            if (!Memberships.Any(x => x.MembershipType == MembershipType.VideoClub))
                _memberships.Add(new Membership { MembershipType = MembershipType.VideoClub });

            return;
        }
    }
}
