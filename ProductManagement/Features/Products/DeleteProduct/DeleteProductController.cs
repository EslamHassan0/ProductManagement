using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Features.Products.DeleteProduct;

[ApiController]
[Route("api/products")]
public class DeleteProductController : ControllerBase
{
    private readonly ISender _sender;

    public DeleteProductController(ISender sender)
    {
        _sender = sender;
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(
       int id,
       CancellationToken cancellationToken)
    {
        await _sender.Send(
            new DeleteProductCommand(id),
            cancellationToken);

        return NoContent();
    }
}
