using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos_eCommerceShop.Endpoints.PurchaseOrder;

public class CreatePurchaseOrderRequest
{
    public int Purchaseorder { get; set; }
    public decimal Total { get; set; }
    public int Customer { get; set; }
    public List<string> ItemLines { get; set; } = null!;
}