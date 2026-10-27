using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Features.Products.CreateProduct;

[ApiController]
[Route("api/products")]
public class CreateProductController : ControllerBase
{
    private readonly ISender _sender;

    public CreateProductController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<CreateProductResponse>> Create(CreateProductCommand command,CancellationToken cancellationToken)
    {
        var response = await _sender.Send(command, cancellationToken);

        return Created(
            $"/api/products/{response.Id}",
            response);
    }
}
