using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos.Domain.AggregateRoots.Customer;

public class Customer : BaseEntity<int>, IAggregateRoot
{
    public List<Membership> Memberships = new();

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
                Memberships.Add(new Membership { MembershipType = MembershipType.BookClub });

            return;
        }
            

        if (membershipName.Contains("video club", StringComparison.OrdinalIgnoreCase))
        {
            if (!Memberships.Any(x => x.MembershipType == MembershipType.VideoClub))
                Memberships.Add(new Membership { MembershipType = MembershipType.VideoClub });

            return;
        }
    }
}
