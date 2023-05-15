using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos.Domain.Tests.Entities;

public class ProductTests
{
    [TestCase("book \"test Book\"", ProductType.Book, true)]
    [TestCase("video \"test Video\"", ProductType.Video, false)]
    public void ProductConstructor__Should_CreateIstance_WithProperlyAssigned_ProductType(string productName, ProductType productType, bool shouldEmitEvent)
    {
        // Arrange + Act
        var product = new Product(productName);

        // Assert
        product.ProductType.Should().Be(productType);
        product.ProductName.Should().Be($"\"test {productType}\"");

        if (shouldEmitEvent)
        {
            product.Events.Should().ContainSingle();
        }
    }
}
