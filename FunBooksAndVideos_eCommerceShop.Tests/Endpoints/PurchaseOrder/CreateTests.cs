using FunBooksAndVideos_eCommerceShop.Endpoints.PurchaseOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos_eCommerceShop.Tests.Endpoints.PurchaseOrder;

public class CreateTests
{
    private Mock<IMediator> _mediatorMock;
    private Create _sut;

    [SetUp]
    public void Initialize()
    {
        _mediatorMock = new Mock<IMediator>();
        _sut = new Create(_mediatorMock.Object);
    }

    [Test]
    public async Task Handle__Should_Return_Created__When_Command_HandlesCorrectly()
    {
        // Arrange
        var apiRequest = AutoFaker.Generate<CreatePurchaseOrderRequest>();

        // Act
        var result = await _sut.HandleAsync(apiRequest);

        // Assert
        using (new AssertionScope())
        {
            var createdResult = result.Should().BeOfType<CreatedResult>().Subject;
            createdResult.StatusCode.Should().Be(201);
            createdResult.Location.Should().Be($"/api/purchase-order/{apiRequest.Purchaseorder}");
        }
    }
}
