using Ardalis.ApiEndpoints;
using FunBooksAndVideos.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos_eCommerceShop.Endpoints.PurchaseOrder;

public class Create : EndpointBaseAsync
    .WithRequest<CreatePurchaseOrderRequest>
    .WithActionResult
{
    private readonly IMediator _mediator;

    public Create(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/api/purchase-order")]
    public override async Task<ActionResult> HandleAsync(CreatePurchaseOrderRequest request, CancellationToken cancellationToken = default)
    {
        var commandRequest = new CreatePurchaseOrderCommandRequest
        {
            PurchaseOrderId = request.Purchaseorder,
            TotalPrice = request.Total,
            CustomerId = request.Customer,
            ItemLines = request.ItemLines
        };

        await _mediator.Send(commandRequest);

        return Created($"/api/purchase-order/{request.Purchaseorder}", default);  
    }
}
