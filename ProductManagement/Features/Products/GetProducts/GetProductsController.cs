using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Features.Products.GetProducts;

[ApiController]
[Route("api/products")]
public class GetProductsController : ControllerBase
{
    private readonly ISender _sender;

    public GetProductsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<GetProductsResponse>> Get(CancellationToken cancellationToken)
    {
        var response = await _sender.Send(
            new GetProductsQuery(),
            cancellationToken);

        return Ok(response);
    }
}
