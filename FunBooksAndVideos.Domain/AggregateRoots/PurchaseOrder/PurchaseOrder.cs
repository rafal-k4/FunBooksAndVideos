using FunBooksAndVideos.Domain.DomainEvents;
using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos.Domain.AggregateRoots.PurchaseOrder;

public class PurchaseOrder : BaseEntity<int>, IAggregateRoot
{
    public decimal TotalPrice { get; private set; }
    public int CustomerId { get; set; }
    public Membership Membership { get; set; }
    public List<Product> ItemLines { get; set; } = new();

    public PurchaseOrder(int id, decimal totalPrice, int customerId)
    {
        Id = id;
        TotalPrice = totalPrice;
        CustomerId = customerId;
    }

    private PurchaseOrder() { } // EF required

    public void ProcessOrder(List<string> itemLines)
    {
        foreach (var item in itemLines)
        {
            if (item.Contains("membership", StringComparison.OrdinalIgnoreCase))
            {
                Events.Add(new MembershipPurchasedEvent(item));
                continue;
            }

            ItemLines.Add(new Product(item));
        }
    }
}
