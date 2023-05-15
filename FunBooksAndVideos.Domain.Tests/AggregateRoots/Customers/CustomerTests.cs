using FunBooksAndVideos.Domain.AggregateRoots.Customers;
using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos.Domain.Tests.AggregateRoots.Customers;

public class CustomerTests
{
    private Customer _sut;

    [SetUp]
    public void Initialize()
    {
        _sut = new Customer(420);
    }

    [Test]
    public void UpdateMembership__Should_Correctly_Assign_NewMemberships()
    {
        // Arrange
        var newMembership = "Book Club Membership";

        // Act
        _sut.UpdateMembership(newMembership);

        // Assert
        _sut.IsPremiumMemberShip.Should().BeFalse();
        _sut.Memberships.Select(x => x.MembershipType).Should().BeEquivalentTo(new[] { MembershipType.BookClub });
    }

    [Test]
    public void UpdateMembership__Should_Correctly_IndicatePremiumMembership__When_CustomerHas_Both_Memberships()
    {
        // Arrange
        var bookClubMemberhsip = "Book Club Membership";
        var videoClubMemberhsip = "Video Club Membership";

        // Act
        _sut.UpdateMembership(bookClubMemberhsip);
        _sut.UpdateMembership(videoClubMemberhsip);

        // Assert
        _sut.IsPremiumMemberShip.Should().BeTrue();
        _sut.Memberships.Select(x => x.MembershipType).Should().BeEquivalentTo(new[] { MembershipType.VideoClub, MembershipType.BookClub });
    }
}
