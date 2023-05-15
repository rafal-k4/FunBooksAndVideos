using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos.Domain.Entities;

public class Membership : BaseEntity<int>
{
    public MembershipType MembershipType { get; set; }
}
