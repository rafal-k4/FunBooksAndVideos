using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos.Domain.AggregateRoots.Customer;

public class Customer : BaseEntity<int>, IAggregateRoot
{
    private HashSet<MembershipType> MembershipTypes { get; set; }

    public IEnumerable<MembershipType> Memberships => MembershipTypes.AsEnumerable();
    public bool IsPremiumMemberShip
        =>  MembershipTypes.Any(x => x == MembershipType.Premium) ||
            (MembershipTypes.Any(x => x == MembershipType.BookClub) && MembershipTypes.Any(x => x == MembershipType.VideoClub));

    public Customer(int customerId)
    {
        Id = customerId;
        MembershipTypes = new HashSet<MembershipType>();
    }

    private Customer() { } // EF required

    public void UpdateMembership(string membershipName)
    {
        if (membershipName.Contains("book club", StringComparison.OrdinalIgnoreCase))
            MembershipTypes.Add(MembershipType.BookClub);

        if (membershipName.Contains("video club", StringComparison.OrdinalIgnoreCase))
            MembershipTypes.Add(MembershipType.VideoClub);
    }
}
