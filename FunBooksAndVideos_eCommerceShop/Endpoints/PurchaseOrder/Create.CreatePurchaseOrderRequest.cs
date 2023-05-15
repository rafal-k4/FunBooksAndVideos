using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos_eCommerceShop.Endpoints.PurchaseOrder;

public record CreatePurchaseOrderRequest
{
    public int Purchaseorder { get; set; }
    public decimal Total { get; set; }
    public int Customer { get; set; }
    public List<string> ItemLines { get; set; } = null!;
}