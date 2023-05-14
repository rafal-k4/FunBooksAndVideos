using FunBooksAndVideos.Domain.Entities;
using FunBooksAndVideos.Domain.SharedKernel;

namespace FunBooksAndVideos.Domain.AggregateRoots;

public class PurchaseOrder : BaseEntity<int>, IAggregateRoot
{
    public decimal TotalPrice { get; private set; }
    public int CustomerId { get; set; }
    public List<OrderItem> ItemLines { get; set; } = new();
}
