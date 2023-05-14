using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos.Domain.Entities;

public class Membership : BaseEntity<int>
{
    public MembershipType MembershipType { get; private set; }
    
    public Membership(int id, MembershipType productType)
    {
        Id = id;
        MembershipType = productType;
    }

    private Membership() { } // EF required
}
