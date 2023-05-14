using FunBooksAndVideos.Domain.AggregateRoots.Customer;
using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Infrastructure;
using FunBooksAndVideos_eCommerceShop.Endpoints.PurchaseOrder;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Text;
using System.Text.Json;

using Microsoft.EntityFrameworkCore;
using FunBooksAndVideos.Application.MessagesContracts;
using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos_eCommerceShop.Tests.Integration.Endpoints.PurchaseOrder;

public class CreateTests : IClassFixture<CustomWebApiFactory>
{
    private readonly ITestHarness _messageQueueTestHarness;
    private readonly OrdersDbContext _ordersDbContext;
    private readonly HttpClient _client;

    public CreateTests(CustomWebApiFactory webApiFactory)
    {
        _messageQueueTestHarness = webApiFactory.Services.GetTestHarness();

        var scope = webApiFactory.Services.CreateScope();
        _ordersDbContext = scope.ServiceProvider.GetService<OrdersDbContext>()!;

        _client = webApiFactory.CreateClient();
    }

    private CreatePurchaseOrderRequest GetExamplePurchaseOrderRequest()
    {
        return new CreatePurchaseOrderRequest
        {
            Purchaseorder = AutoFaker.Generate<int>(),
            Total = 48.50m,
            Customer = AutoFaker.Generate<int>(),
            ItemLines = new List<string>
            {

                 "Video \"Comprehensive First Aid Training\"",
                 "Book \"The Girl on the train\"",
                 "Book Club Membership"
            }
        };
    }

    [Fact]
    public async Task CreatePurchaseOrderEndpoint__Should_ReturnCreatedResponse()
    {
        // Arrange
        var createPurchaseOrderRequest = GetExamplePurchaseOrderRequest();
        var serializedRequest = JsonSerializer.Serialize(createPurchaseOrderRequest);
        var requestContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/purchase-order", requestContent);

        // Assert
        using var _ = new AssertionScope();
        response.Content.ReadAsStringAsync().Result.Should().BeNullOrEmpty();
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task CreatePurchaseOrderEndpoint__Should_Publish_Queue_Message__When_Membership_Is_InItemLines_Request()
    {
        // Arrange
        var createPurchaseOrderRequest = GetExamplePurchaseOrderRequest();
        var serializedRequest = JsonSerializer.Serialize(createPurchaseOrderRequest);
        var requestContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

        // Act
        await _client.PostAsync("/api/purchase-order", requestContent);

        // Assert
        using var _ = new AssertionScope();

        var purchaseOrder = await _messageQueueTestHarness.Published
            .Any<PhysicalProductOrdered>(x => ((PhysicalProductOrdered)x.MessageObject).ProductName == "\"The Girl on the train\"");
        purchaseOrder.Should().BeTrue();
    }

    [Fact]
    public async Task CreatePurchaseOrderEndpoint__Should_CreatePoperlyProducts__WhenProductsAre_In_ItemLines_Request()
    {
        // Arrange
        var expectedProducts = new List<Product>
        {
            new Product("Video \"Comprehensive First Aid Training\""),
            new Product("Book \"The Girl on the train\"")
        };
        var createPurchaseOrderRequest = GetExamplePurchaseOrderRequest();
        var serializedRequest = JsonSerializer.Serialize(createPurchaseOrderRequest);
        var requestContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

        // Act
        await _client.PostAsync("/api/purchase-order", requestContent);

        // Assert
        using var _ = new AssertionScope();
        var purchaseOrder = _ordersDbContext.PurchaseOrders.Include(x => x.ItemLines).ToList()
            .Where(x => x.Id == createPurchaseOrderRequest.Purchaseorder)
            .Should()
            .ContainSingle().Subject;
        purchaseOrder.ItemLines.Should().BeEquivalentTo(expectedProducts, options => options
            .Excluding(x => x.Id)
            .Excluding(x => x.Events));
    }

    [Fact(Skip = "Need to fix including Membership collection")]
    public async Task CreatePurchaseOrderEndpoint__Should_UpdateCustomer_Membership__When_ItemLines_Contains_Membership()
    {
        // Arrange
        var createPurchaseOrderRequest = GetExamplePurchaseOrderRequest() with
        {
            ItemLines = new List<string>
            {
                 "Book Club Membership",
                 "Video Club Membership"
            }
        };
        var serializedRequest = JsonSerializer.Serialize(createPurchaseOrderRequest);
        var requestContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/purchase-order", requestContent);

        // Assert
        using var _ = new AssertionScope();
        var customer = _ordersDbContext.Customers
            .Where(x => x.Id == createPurchaseOrderRequest.Customer)
            .Include(x => x.Memberships).ToList()
            .Should()
            .ContainSingle().Subject;
        customer.IsPremiumMemberShip.Should().BeTrue();
        customer.Memberships.Select(x => x.MembershipType).Should().Contain(new[] { MembershipType.BookClub, MembershipType.VideoClub });
    }
}
