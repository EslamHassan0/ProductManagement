using MediatR;

namespace ProductManagement.Features.Products.GetProduct;

public record GetProductQuery(int Id) : IRequest<GetProductResponse>;