using MediatR;

namespace ProductManagement.Features.Products.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest;
 