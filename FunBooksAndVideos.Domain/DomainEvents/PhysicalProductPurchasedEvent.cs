using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos.Domain.DomainEvents;

public class PhysicalProductPurchasedEvent : BaseDomainEvent
{
    public string ProductName { get; }
    public ProductType ProductType { get; }

    public PhysicalProductPurchasedEvent(string productName, ProductType productType)
    {
        ProductName = productName;
        ProductType = productType;
    }
}
