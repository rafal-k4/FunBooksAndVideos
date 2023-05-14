using FunBooksAndVideos.Domain.DomainEvents;
using FunBooksAndVideos.Domain.SharedKernel;
using System.Text.RegularExpressions;

namespace FunBooksAndVideos.Domain.Entities;

public class Product : BaseEntity<int>
{
    public string ProductName { get; private set; }
    public ProductType ProductType { get; private set; }

    private static Regex ProductNameRegexPattern = new Regex(@""".*""", RegexOptions.Compiled);

    public Product(string productName)
    {
        CreateProduct(productName);
    }

    private Product() { } // EF required

    private void CreateProduct(string item)
    {
        if (item.Contains("video", StringComparison.OrdinalIgnoreCase))
        {
            ProductName = ProductNameRegexPattern.Match(item).Value;
            ProductType = ProductType.Video;

            return;
        }

        if (item.Contains("book", StringComparison.OrdinalIgnoreCase))
        {
            var bookName = ProductNameRegexPattern.Match(item).Value;
            Events.Add(new PhysicalProductPurchasedEvent(bookName, ProductType.Book));
            ProductName = bookName;
            ProductType = ProductType.Book;

            return;
        }
    }
}
