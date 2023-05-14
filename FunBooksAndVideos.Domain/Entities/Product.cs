using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos.Domain.Entities;

public class Product : BaseEntity<int>
{
    public string ProductName { get; private set; }
    public ProductType ProductType { get; private set; }

    public Product(int id, string productName, ProductType productType)
    {
        Id = id;
        ProductName = productName;
        ProductType = productType;
    }
}
