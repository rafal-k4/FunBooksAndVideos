using FunBooksAndVideos.Domain.AggregateRoots.PurchaseOrder;

namespace FunBooksAndVideos.Domain.Tests.AggregateRoots.PurchaseOrders;

public class PurchaseOrderTests
{
    [Test]
    public void ProcessOrder__Should_AddUnderlyingItems_ToItemLines()
    {
        // Arrange
        var purchaseOrder = new PurchaseOrder(420, 42.42m, 100);
        var newItems = new List<string>
        {
            "Book \"test book\"",
            "Video \"test video\""
        };

        // Act
        purchaseOrder.ProcessOrder(newItems);

        //Assert
        purchaseOrder.ItemLines.Count.Should().Be(2);
        purchaseOrder.ItemLines.Select(x => x.ProductName).Should().BeEquivalentTo(new[] { "\"test book\"", "\"test video\"" });
    }

    [Test]
    public void ProcessOrder__Should_ThrowException__WhenInvalidItems_Input()
    {
        // Arrange
        var purchaseOrder = new PurchaseOrder(420, 42.42m, 100);
        var newItems = new List<string>
        {
            "aaa",
            "bbb"
        };

        // Act
        var act = () => purchaseOrder.ProcessOrder(newItems);

        //Assert
        act.Should().ThrowExactly<ArgumentException>();
    }
}
