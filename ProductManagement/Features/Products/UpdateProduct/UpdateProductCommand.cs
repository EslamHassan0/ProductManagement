using MediatR;

namespace ProductManagement.Features.Products.UpdateProduct;

public record UpdateProductCommand(int Id, string Name, decimal Price) : IRequest;