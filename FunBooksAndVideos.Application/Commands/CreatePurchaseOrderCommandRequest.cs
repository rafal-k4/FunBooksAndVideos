using MediatR;

namespace FunBooksAndVideos.Application.Commands;

public record CreatePurchaseOrderCommandRequest : IRequest
{
    public int PurchaseOrderId { get; set; }
    public decimal TotalPrice { get; set; }
    public int CustomerId { get; set; }
    public List<string> ItemLines { get; set; } = new();
}