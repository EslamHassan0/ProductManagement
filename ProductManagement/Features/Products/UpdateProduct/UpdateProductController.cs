using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Features.Products.UpdateProduct;

[ApiController]
[Route("api/products")]
public class UpdateProductController : ControllerBase
{
    private readonly ISender _sender;

    public UpdateProductController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult>Update(int id ,
        UpdateProductCommand command, 
        CancellationToken cancellationToken)
    {
        if(id != command.Id)
        {
            return BadRequest(new
            {
                status = 400,
                title = "Route ID does not match the request ID."
            });
        }

        await _sender.Send(command, cancellationToken);
        return NoContent();
    }

}
