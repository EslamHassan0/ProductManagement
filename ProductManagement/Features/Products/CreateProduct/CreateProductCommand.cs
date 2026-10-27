using MediatR;

namespace ProductManagement.Features.Products.CreateProduct;

public record CreateProductCommand(string Name,
    decimal Price) : IRequest<CreateProductResponse>;

