using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos.Domain.AggregateRoots;

public class PurchaseOrder : BaseEntity<int>, IAggregateRoot
{
    public decimal TotalPrice { get; private set; }
    public int CustomerId { get; set; }
    public Membership Membership { get; set; }
    public List<Product> ItemLines { get; set; } = new();

    public PurchaseOrder(int id, decimal totalPrice, int customerId, Membership membership, List<Product> itemLines)
    {
        Id = id;
        TotalPrice = totalPrice;
        CustomerId = customerId;
        Membership = membership;
        ItemLines = itemLines;
    }

    private PurchaseOrder() { } // EF required
}
