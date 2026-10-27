using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Features.Products.GetProduct;

[ApiController]
[Route("api/products")]
public class GetProductController : ControllerBase
{
    private readonly ISender _sender;

    public GetProductController(ISender sender)
    {
        _sender = sender;
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetProductResponse>> Get(int id,CancellationToken cancellationToken)
    {
        var response = await _sender.Send(
            new GetProductQuery(id),
            cancellationToken);

        return Ok(response);
    }
}
