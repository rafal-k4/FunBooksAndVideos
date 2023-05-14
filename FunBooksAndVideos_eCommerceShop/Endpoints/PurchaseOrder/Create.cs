using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos_eCommerceShop.Endpoints.PurchaseOrder;

public class Create : EndpointBaseAsync
    .WithRequest<CreatePurchaseOrderRequest>
    .WithActionResult
{
    [HttpPost("/api/purchase-order")]
    public override Task<ActionResult> HandleAsync(CreatePurchaseOrderRequest request, CancellationToken cancellationToken = default)
    {
        return Task.FromResult<ActionResult>(Ok(request));
    }
}
